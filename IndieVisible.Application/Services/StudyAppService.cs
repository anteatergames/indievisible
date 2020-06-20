using AutoMapper;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Study;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Services;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Domain.ValueObjects.Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Application.Services
{
    public class StudyAppService : ProfileBaseAppService, IStudyAppService
    {
        private readonly IStudyDomainService studyDomainService;
        private readonly IGamificationDomainService gamificationDomainService;

        public StudyAppService(IMapper mapper, IUnitOfWork unitOfWork,
            ICacheService cacheService,
            IProfileDomainService profileDomainService,
            IStudyDomainService studyDomainService,
            IGamificationDomainService gamificationDomainService) : base(mapper, unitOfWork, cacheService, profileDomainService)
        {
            this.studyDomainService = studyDomainService;
            this.gamificationDomainService = gamificationDomainService;
        }

        public OperationResultVo GetMyMentors(Guid currentUserId)
        {
            try
            {
                IEnumerable<Guid> mentors = studyDomainService.GetMentorsByUserId(currentUserId);

                List<ProfileViewModel> finalList = new List<ProfileViewModel>();

                foreach (Guid mentorId in mentors)
                {
                    if (!finalList.Any(x => x.UserId == mentorId))
                    {
                        UserProfile profile = GetCachedProfileByUserId(mentorId);

                        if (profile != null)
                        {
                            ProfileViewModel vm = mapper.Map<ProfileViewModel>(profile);

                            vm.ProfileImageUrl = UrlFormatter.ProfileImage(vm.UserId, 84);
                            vm.CoverImageUrl = UrlFormatter.ProfileCoverImage(vm.UserId, vm.Id, vm.LastUpdateDate, profile.HasCoverImage, 300);

                            finalList.Add(vm);
                        }
                    }
                }

                return new OperationResultListVo<ProfileViewModel>(finalList);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetMyStudents(Guid currentUserId)
        {
            try
            {
                IEnumerable<Guid> students = studyDomainService.GetStudentsByUserId(currentUserId);

                List<ProfileViewModel> finalList = new List<ProfileViewModel>();

                foreach (Guid studentId in students)
                {
                    if (!finalList.Any(x => x.UserId == studentId))
                    {
                        UserProfile profile = GetCachedProfileByUserId(studentId);

                        if (profile != null)
                        {
                            ProfileViewModel vm = mapper.Map<ProfileViewModel>(profile);

                            vm.ProfileImageUrl = UrlFormatter.ProfileImage(vm.UserId, 84);
                            vm.CoverImageUrl = UrlFormatter.ProfileCoverImage(vm.UserId, vm.Id, vm.LastUpdateDate, profile.HasCoverImage, 300);

                            finalList.Add(vm);
                        }
                    }
                }

                return new OperationResultListVo<ProfileViewModel>(finalList);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        #region Course
        public OperationResultVo GetMyCourses(Guid currentUserId)
        {
            try
            {
                StudyCoursesOfUserVo courses = studyDomainService.GetCoursesForUserId(currentUserId);

                List<StudyCourseListItemVo> finalList = new List<StudyCourseListItemVo>();

                foreach (UserCourseVo course in courses.Courses)
                {
                    if (!finalList.Any(x => x.Id == course.CourseId))
                    {
                        StudyCourseListItemVo vm = new StudyCourseListItemVo
                        {
                            Id = course.CourseId,
                            Name = course.CourseName
                        };

                        finalList.Add(vm);
                    }
                }

                return new OperationResultListVo<StudyCourseListItemVo>(finalList);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetCoursesByMe(Guid currentUserId)
        {
            try
            {
                List<StudyCourseListItemVo> courses = studyDomainService.GetCoursesByUserId(currentUserId);

                return new OperationResultListVo<StudyCourseListItemVo>(courses);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GenerateNewCourse(Guid currentUserId)
        {
            try
            {
                StudyCourse model = studyDomainService.GenerateNewCourse(currentUserId);

                StudyCourseViewModel newVm = mapper.Map<StudyCourseViewModel>(model);

                return new OperationResultVo<StudyCourseViewModel>(newVm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> SaveCourse(Guid currentUserId, StudyCourseViewModel vm)
        {
            int pointsEarned = 0;

            try
            {
                StudyCourse model;

                StudyCourse existing = studyDomainService.GetCourseById(vm.Id);
                if (existing != null)
                {
                    model = mapper.Map(vm, existing);
                }
                else
                {
                    model = mapper.Map<StudyCourse>(vm);
                }

                if (vm.Id == Guid.Empty)
                {
                    studyDomainService.AddCourse(model);
                    vm.Id = model.Id;

                    pointsEarned += gamificationDomainService.ProcessAction(currentUserId, PlatformAction.CourseAddition);
                }
                else
                {
                    studyDomainService.UpdateCourse(model);
                }

                unitOfWork.Commit();

                vm.Id = model.Id;

                return new OperationResultVo<Guid>(model.Id, pointsEarned);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }


        public OperationResultVo RemoveCourse(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                studyDomainService.RemoveCourse(id);

                unitOfWork.Commit();

                return new OperationResultVo(true, "That Course is gone now!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetCourseById(Guid currentUserId, Guid id)
        {
            try
            {
                StudyCourse existing = studyDomainService.GetCourseById(id);

                StudyCourseViewModel vm = mapper.Map<StudyCourseViewModel>(existing);

                SetAuthorDetails(vm);

                SetPermissions(currentUserId, vm);

                return new OperationResultVo<StudyCourseViewModel>(vm);

            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetPlans(Guid currentUserId, Guid courseId)
        {
            try
            {
                IEnumerable<StudyPlan> plans = studyDomainService.GetPlans(courseId);

                List<StudyPlanViewModel> vms = mapper.Map<IEnumerable<StudyPlan>, IEnumerable<StudyPlanViewModel>>(plans).ToList();

                vms = vms.OrderBy(x => x.Order).ToList();

                return new OperationResultListVo<StudyPlanViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo SavePlans(Guid currentUserId, Guid courseId, IEnumerable<StudyPlanViewModel> plans)
        {
            try
            {
                List<StudyPlan> entities = mapper.Map<IEnumerable<StudyPlanViewModel>, IEnumerable<StudyPlan>>(plans).ToList();

                foreach (StudyPlan term in entities)
                {
                    term.UserId = currentUserId;
                }

                bool result = Task.Run(async () => await studyDomainService.SavePlans(courseId, entities)).Result;

                Task<bool> task = unitOfWork.Commit();

                task.Wait();

                return new OperationResultVo(true, "Plans Updated!");
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        private void SetAuthorDetails(StudyCourseViewModel vm)
        {
            UserProfile authorProfile = GetCachedProfileByUserId(vm.UserId);
            if (authorProfile != null)
            {
                vm.AuthorPicture = UrlFormatter.ProfileImage(vm.UserId, 40);
                vm.AuthorName = authorProfile.Name;
            }
        }
        private void SetPermissions(Guid currentUserId, StudyCourseViewModel vm)
        {
            SetBasePermissions(currentUserId, vm);
        }
        #endregion
    }
}

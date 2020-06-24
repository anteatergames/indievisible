using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Services;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Domain.ValueObjects.Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class StudyDomainService : IStudyDomainService
    {
        protected readonly IProfileDomainService profileDomainService;
        protected readonly IStudyCourseRepository studyCourseRepository;
        protected readonly IStudyGroupRepository studyGroupRepository;

        public StudyDomainService(IProfileDomainService profileDomainService, IStudyCourseRepository studyCourseRepository, IStudyGroupRepository studyGroupRepository)
        {
            this.profileDomainService = profileDomainService;
            this.studyCourseRepository = studyCourseRepository;
            this.studyGroupRepository = studyGroupRepository;
        }

        #region General


        public IEnumerable<Guid> GetMentorsByUserId(Guid userId)
        {
            IEnumerable<UserConnection> mentorsIAdded = profileDomainService.GetConnectionByUserId(userId, UserConnectionType.Mentor);
            IEnumerable<UserConnection> mentorsAddedMe = profileDomainService.GetConnectionByTargetUserId(userId, UserConnectionType.Pupil);

            List<Guid> finalList = new List<Guid>();

            foreach (UserConnection connection in mentorsIAdded)
            {
                finalList.Add(connection.TargetUserId);
            }

            foreach (UserConnection mentor in mentorsAddedMe)
            {
                if (!finalList.Any(x => x == mentor.UserId))
                {
                    finalList.Add(mentor.UserId);
                }
            }

            return finalList;
        }

        public IEnumerable<Guid> GetStudentsByUserId(Guid userId)
        {
            IEnumerable<UserConnection> studentsIAdded = profileDomainService.GetConnectionByUserId(userId, UserConnectionType.Pupil);
            IEnumerable<UserConnection> studentsAddedMe = profileDomainService.GetConnectionByTargetUserId(userId, UserConnectionType.Mentor);

            List<Guid> finalList = new List<Guid>();

            foreach (UserConnection connection in studentsIAdded)
            {
                finalList.Add(connection.TargetUserId);
            }

            foreach (UserConnection student in studentsAddedMe)
            {
                if (!finalList.Any(x => x == student.UserId))
                {
                    finalList.Add(student.UserId);
                }
            }

            return finalList;
        }
        #endregion

        #region Course
        public List<StudyCourseListItemVo> GetCourses()
        {
            List<StudyCourseListItemVo> objs = studyCourseRepository.GetCourses();

            return objs;
        }

        public List<StudyCourseListItemVo> GetCoursesByUserId(Guid userId)
        {
            List<StudyCourseListItemVo> objs = studyCourseRepository.GetCoursesByUserId(userId);

            return objs;
        }

        public StudyCoursesOfUserVo GetCoursesForUserId(Guid userId)
        {
            List<UserCourseVo> objs = studyCourseRepository.Get().Where(x => x.Members.Any(y => y.UserId == userId)).Select(x => new UserCourseVo
            {
                CourseId = x.Id,
                CourseName = x.Name
            }).ToList();

            StudyCoursesOfUserVo result = new StudyCoursesOfUserVo
            {
                UserId = userId
            };

            if (objs.Any())
            {
                result.Courses = objs;
            }

            return result;
        }
        public StudyCourse GenerateNewCourse(Guid userId)
        {
            StudyCourse model = new StudyCourse
            {
                UserId = userId
            };

            return model;
        }

        public StudyCourse GetCourseById(Guid id)
        {
            Task<StudyCourse> task = Task.Run(async () => await studyCourseRepository.GetById(id));

            return task.Result;
        }

        public void AddCourse(StudyCourse model)
        {
            studyCourseRepository.Add(model);
        }

        public void UpdateCourse(StudyCourse model)
        {
            studyCourseRepository.Update(model);
        }

        public void RemoveCourse(Guid id)
        {
            studyCourseRepository.Remove(id);
        }

        public IEnumerable<StudyPlan> GetPlans(Guid courseId)
        {
            List<StudyPlan> entries = studyCourseRepository.GetPlans(courseId).ToList();

            return entries;
        }

        public async Task<bool> SavePlans(Guid courseId, List<StudyPlan> plans)
        {
            List<StudyPlan> existingPlans = studyCourseRepository.GetPlans(courseId).ToList();

            foreach (StudyPlan plan in plans)
            {
                StudyPlan existing = existingPlans.FirstOrDefault(x => x.Id == plan.Id);
                if (existing == null)
                {
                    await studyCourseRepository.AddPlan(courseId, plan);
                }
                else
                {
                    existing.Name = plan.Name;
                    existing.Description = plan.Description;
                    existing.ScoreToPass = plan.ScoreToPass;
                    existing.Order = plan.Order;

                    await studyCourseRepository.UpdatePlan(courseId, existing);
                }
            }

            IEnumerable<StudyPlan> plansToDelete = existingPlans.Where(x => !plans.Contains(x));

            // TODO check students with those plans and update them;

            if (plansToDelete.Any())
            {
                foreach (StudyPlan plan in plansToDelete)
                {
                    await studyCourseRepository.RemovePlan(courseId, plan.Id);
                }
            }

            return true;
        }

        public async Task<bool> EnrollCourse(Guid userId, Guid courseId)
        {
            var userAlreadyEnroled = studyCourseRepository.CheckStudentEnrolled(courseId, userId);

            if (userAlreadyEnroled)
            {
                return false;
            }

            var student = new CourseMember
            {
                UserId = userId
            };

            return await studyCourseRepository.AddStudent(courseId, student);
        }
        public async Task<bool> LeaveCourse(Guid userId, Guid courseId)
        {
            var userAlreadyEnroled = studyCourseRepository.CheckStudentEnrolled(courseId, userId);

            if (!userAlreadyEnroled)
            {
                return false;
            }

            return await studyCourseRepository.RemoveStudent(courseId, userId);
        }
        #endregion
    }
}

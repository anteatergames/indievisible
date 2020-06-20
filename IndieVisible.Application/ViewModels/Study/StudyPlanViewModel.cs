using System.Collections.Generic;

namespace IndieVisible.Application.ViewModels.Study
{
    public class StudyPlanViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal ScoreToPass { get; set; }

        public int Order { get; set; }

        public List<StudyActivityViewModel> Activities { get; set; }

        public StudyPlanViewModel()
        {
            Activities = new List<StudyActivityViewModel>();
        }
    }
}

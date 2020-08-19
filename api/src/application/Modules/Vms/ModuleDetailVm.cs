using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Modules.Vms
{
    public class LessonDetailVm
    {
        public int LessonNo { get; set; }
        public string Title { get; set; }
    }

    public class ModuleDetailVm
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public List<LessonDetailVm> Lessons { get; set; }

        public ModuleDetailVm(Module module)
        {
            Identifier = module.Identifier;
            Title = module.Title;
            Lessons = module.Lessons.Select(lesson =>
                new LessonDetailVm
                {
                    LessonNo = lesson.LessonNo,
                    Title = lesson.Title,
                }).ToList();
        }
    }
}

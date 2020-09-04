using Application.Products.Vms;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Modules.Vms
{
    public class ModuleDetailVm_Lesson
    {
        public int LessonNo { get; set; }
        public string Title { get; set; }
    }

    public class ModuleDetailVm_Product
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
    }

    public class ModuleDetailVm
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public ModuleDetailVm_Product Product { get; set; }
        public List<ModuleDetailVm_Lesson> Lessons { get; set; }

        public ModuleDetailVm(Module module)
        {
            Identifier = module.Identifier;
            Title = module.Title;

            Lessons = module.Lessons.Select(lesson =>
                new ModuleDetailVm_Lesson
                {
                    LessonNo = lesson.LessonNo,
                    Title = lesson.Title,
                }).ToList();

            Product = new ModuleDetailVm_Product
            {
                Identifier = module.Product.Identifier,
                Title = module.Product.Title,
                Thumbnail = module.Product.Thumbnail.Uri,
            };
        }
    }
}

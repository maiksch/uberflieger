using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Modules.Responses
{
    public class GetOneModuleLessons
    {
        public int LessonNo { get; set; }
        public string Title { get; set; }
    }

    public class GetOneModuleResponse
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public List<GetOneModuleLessons> Lessons { get; set; }

        public static GetOneModuleResponse FromModule(Module module)
        {

            var p = new GetOneModuleResponse
            {
                Identifier = module.Identifier,
                Title = module.Title,
                Lessons = module.Lessons.Select(lesson =>
                    new GetOneModuleLessons
                    {
                        LessonNo = lesson.LessonNo,
                        Title = lesson.Title,
                    }).ToList()
            };

            return p;
        }
    }
}

using Domain;
using HotChocolate.Types;

namespace Web.GraphQL.Types
{
    public class LessonType : ObjectType<Lesson>
    {
        protected override void Configure(IObjectTypeDescriptor<Lesson> descriptor)
        {
            descriptor
                .Field(l => l.Id)
                .Ignore();

            descriptor
                .Field(l => l.ModuleId)
                .Ignore();

            descriptor
                .Field(l => l.VideoId)
                .Ignore();

            descriptor
                .Field(l => l.LessonNo)
                .Type<NonNullType<IntType>>();

            descriptor
                .Field(l => l.Title)
                .Type<NonNullType<StringType>>();
        }
    }
}

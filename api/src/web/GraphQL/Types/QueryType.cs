using HotChocolate.Types;

namespace Web.GraphQL.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetProduct(default))
                      .Type<ProductType>()
                      .UseFirstOrDefault()
                      .UseSelection();

            descriptor.Field(t => t.GetProducts())
                      .Type<NonNullType<ListType<NonNullType<ProductType>>>>()
                      .UseSelection();

            descriptor.Field(t => t.GetModule(default))
                      .Type<ModuleType>()
                      .UseFirstOrDefault()
                      .UseSelection();

            descriptor.Field(t => t.GetLesson(default, default))
                      .Type<LessonType>()
                      .UseFirstOrDefault()
                      .UseSelection();
        }
    }
}

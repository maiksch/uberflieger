using Domain;
using HotChocolate.Types;

namespace Web.GraphQL.Types
{
    public class ModuleType : ObjectType<Module>
    {
        protected override void Configure(IObjectTypeDescriptor<Module> descriptor)
        {
            descriptor.Field(t => t.Id)
                      .Ignore();

            descriptor.Field(t => t.ProductId)
                      .Ignore();

            descriptor.Field(t => t.Identifier)
                      .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Title)
                      .Type<NonNullType<StringType>>();
        }
    }
}

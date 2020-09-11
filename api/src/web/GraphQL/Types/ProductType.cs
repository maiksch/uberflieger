using Domain;
using HotChocolate.Types;

namespace Web.GraphQL.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Field(t => t.Id)
                      .Ignore();

            descriptor.Field(t => t.ThumbnailId)
                      .Ignore();

            descriptor.Field(t => t.Identifier)
                      .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Title)
                      .Type<NonNullType<StringType>>();
        }
    }
}

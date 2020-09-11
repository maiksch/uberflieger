using Domain;
using HotChocolate.Types;

namespace Web.GraphQL.Types
{
    public class ImageType : ObjectType<Image>
    {
        protected override void Configure(IObjectTypeDescriptor<Image> descriptor)
        {
            descriptor
                .Field(i => i.Id)
                .Ignore();

            descriptor
                .Field(i => i.StorageId)
                .Ignore();
        }
    }
}

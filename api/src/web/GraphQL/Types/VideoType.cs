using Domain;
using HotChocolate.Types;

namespace Web.GraphQL.Types
{
    public class VideoType : ObjectType<Video>
    {
        protected override void Configure(IObjectTypeDescriptor<Video> descriptor)
        {
            descriptor
                .Field(v => v.Id)
                .Ignore();
        }
    }
}

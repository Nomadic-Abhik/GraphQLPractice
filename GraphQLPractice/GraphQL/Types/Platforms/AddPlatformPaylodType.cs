using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace GraphQLPractice.GraphQL.Types.Platforms
{
    public class AddPlatformPaylodType : ObjectType<AddPlatformPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddPlatformPayload> descriptor)
        {
           
            descriptor.Field(c => c.platform).Description("This is Returned Model which has been added");
        }
    }
}

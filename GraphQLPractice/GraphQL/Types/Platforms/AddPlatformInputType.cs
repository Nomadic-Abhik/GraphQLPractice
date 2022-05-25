using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace GraphQLPractice.GraphQL.Types.Platforms
{
    public class AddPlatformInputType :InputObjectType<AddPlatformInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddPlatformInput> descriptor)
        {
          
          //  descriptor.Field(c => c.name).Description("This is platform name to be entered");
            descriptor.Field(c => c.key).Description("This is License to be added");
            //base.Configure(descriptor);
        }
    }
}

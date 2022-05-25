using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors.Definitions;

namespace GraphQLPractice.GraphQL.Types.Commands
{
    public class AddCommandPayloadType :ObjectType<AddCommandPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddCommandPayload> descriptor)
        {
            descriptor.Field(c => c.Command).Description("This is Command Return Model");
            base.Configure(descriptor);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
namespace GraphQLPractice.GraphQL.Types.Commands
{
    public class AddCommandInputType :InputObjectType<AddCommandInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddCommandInput> descriptor)
        {
            descriptor.Field(c => c.command).Description("This is the command to execute");
            base.Configure(descriptor);
        }
    }
}

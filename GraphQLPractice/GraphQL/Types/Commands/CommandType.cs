using GraphQLPractice.DataAccess.Entity;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLPractice.GraphQL.Types.Commands
{
    public class CommandType: ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("This is command Type");
            descriptor.Field(p => p.HowTo).Description("This is Howto");
            descriptor.Field(p => p.CommandLine).Description("This is CommandLine ");
            descriptor.Field(p => p.Platform)
               .ResolveWith<Resolvers>(p => p.PlatformResolver(default!, default!))
                .UseDbContext<GraphQlDbContext>()
                .Description("This is Related Platform to the platform");
        }
        private class Resolvers
        {
            public Platform PlatformResolver(Command command, [ScopedService] GraphQlDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}

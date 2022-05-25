using GraphQLPractice.DataAccess.Entity;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLPractice.GraphQL.Types.Platforms
{
    public class PlatformType :ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("This is Platform Type");
            descriptor.Field(p => p.LicenseKey).Ignore();
            descriptor.Field(p => p.Name).Description("This is Platform Name");
            descriptor.Field(p=> p.Commands)
               .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<GraphQlDbContext>()
                .Description("This is Related COmmand to the platform");
        }
        private class Resolvers
        {
            public IQueryable<Command>GetCommands(Platform platform, [ScopedService] GraphQlDbContext context)
            {
                return context.commands.Where(p => p.PlatformId == platform.Id);
            }
        }
    }
}

using GraphQLPractice.DataAccess.Entity;
using GraphQLPractice.GraphQL.Types.Platforms;
using GraphQLPractice.GraphQL.Types.Commands;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLPractice.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(GraphQlDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, [ScopedService] GraphQlDbContext context,
            [Service] ITopicEventSender eventSender, CancellationToken cancellationtoken)
        {
            var platform = new Platform
            {
                Name = input.name,
                LicenseKey = input.key                
            };
            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cancellationtoken);
            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationtoken);
            return new AddPlatformPayload(platform);
        }
        [UseDbContext(typeof(GraphQlDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] GraphQlDbContext context)
        {
            var command = new Command
            {
                HowTo = input.way,
                CommandLine = input.command,
                PlatformId = input.Id
            };
            context.commands.Add(command);
            await context.SaveChangesAsync();
            return new AddCommandPayload(command);
        }
    }
}

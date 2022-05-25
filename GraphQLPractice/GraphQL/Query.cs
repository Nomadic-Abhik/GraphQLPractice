using GraphQLPractice.DataAccess.Entity;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLPractice.GraphQL
{
    public class Query
    { 
        [UseDbContext(typeof(GraphQlDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] GraphQlDbContext context)
        {
            return context.Platforms;
        }
        [UseDbContext(typeof(GraphQlDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] GraphQlDbContext context)
        {
            return context.commands;
        }

    }
}

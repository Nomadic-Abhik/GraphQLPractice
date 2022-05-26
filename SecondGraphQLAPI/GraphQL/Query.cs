using HotChocolate;
using HotChocolate.Data;
using SecondGraphQLAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondGraphQLAPI.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Employee> EmployeeList([ScopedService] AppDbContext context)
        {
            return context.employees;
        }
    }
}

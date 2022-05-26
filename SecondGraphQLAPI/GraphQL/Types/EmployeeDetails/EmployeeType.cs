using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using SecondGraphQLAPI.DataAccess;

namespace SecondGraphQLAPI.GraphQL.Types.EmployeeDetails
{
    public class EmployeeType :ObjectType<Employee>
    {
        protected override void Configure(IObjectTypeDescriptor<Employee> descriptor)
        {
            descriptor.Field(p => p.Name).Description("This is EmployeeName");
            base.Configure(descriptor);
        }
    }
}

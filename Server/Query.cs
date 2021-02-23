using BlazingChocolate.Shared;
using HotChocolate;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HotChocolate.Data;
using BlazingChocolate.Server.Extensions;
using System.Linq;
using System.Linq.Expressions;

namespace BlazingChocolate.Server
{
    public class Query
    {
        /// <summary>
        /// Gets all Customers.
        /// </summary>
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Application> GetApplications([ScopedService] AppDbContext appDbContext) => appDbContext.Applications;

    }
}

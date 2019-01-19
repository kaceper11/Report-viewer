using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PrepaidSystemContext.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddPrepaidSystemContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PrepaidSystemContext>(options => options.UseSqlServer(connectionString));
        }
    }
}

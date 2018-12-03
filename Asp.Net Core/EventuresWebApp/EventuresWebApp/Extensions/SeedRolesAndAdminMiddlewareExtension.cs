using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventuresWebApp.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace EventuresWebApp.Extensions
{
    public static  class SeedRolesAndAdminMiddlewareExtension
    {
        public static IApplicationBuilder UseSeedRolesAndAdmin(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedRolesAndAdminMiddleware>();
        }
    }
}

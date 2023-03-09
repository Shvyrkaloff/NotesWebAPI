using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace NotesApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicaton(this IServiceCollection service)
        {
            return service;
        }
    }
}

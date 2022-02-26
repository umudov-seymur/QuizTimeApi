using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizTime.Business.Profiles
{
    public static class MapperServiceExtensions
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddScoped(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapper());
            }).CreateMapper());
        }
    }
}

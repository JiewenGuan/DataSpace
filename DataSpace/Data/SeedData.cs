using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using DataSpace.Models;
using System.Collections.Generic;

namespace DataSpace.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            List<Role> roles = new List<Role>
            {
                    new Role
                    {
                        Title = "Principal Investigator",
                        RoleDescription = "investigate principle"
                    },

                    new Role
                    {
                        Title = "Researcher ",
                        RoleDescription = "research"
                    },

                    new Role
                    {
                        Title = "Flight Engineer",
                        RoleDescription = "Assist in Parabolic Flight"
                    }
            };
            List<Institution> institutions = new List<Institution>
            {
                new Institution
                {
                    ABN = "49 781 030 034",
                    Name = "RMIT"
                },
                new Institution
                {
                    ABN = "84 002 705 224",
                    Name = "University of Melbourne"
                }
            };
            List<Platform> platforms = new List<Platform>
            {
                new Platform {Name = "ISS",Type = PlatformType.Space_Station, Discription = "International Space Station"},
                new Platform {Name = "DeepSpace Gateway",Type = PlatformType.Space_Station},
                new Platform {Name = "MIR",Type = PlatformType.Space_Station},
                new Platform {Name = "Salyut",Type = PlatformType.Space_Station},
                new Platform {Name = "Skylab",Type = PlatformType.Space_Station},
                new Platform {Name = "Apollo",Type = PlatformType.Space_Station},
                new Platform {Name = "Columbia",Type = PlatformType.Space_Shuttle},
            };
            using (var context = new SpaceContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SpaceContext>>()))
            {
                // Look for any movies.
                if (context.Institutions.Any())
                {
                    return;   // DB has been seeded
                }

                context.Roles.AddRange();
                context.SaveChanges();
            }
        }
    }
}

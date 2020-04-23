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
            List<Mission> missions = new List<Mission>
            {
                new Mission{
                    Name = "ISS Increment 60",
                    Commancement = new DateTime(2019, 6,24,23,25,0,DateTimeKind.Utc),
                    Conclusion = new DateTime(2019, 10,3,7,37,0,DateTimeKind.Utc),
                    PlatformID = 1,
                },
                new Mission{
                    Name = "STS-107",
                    Commancement = new DateTime(2003, 1,16,15,39,0,DateTimeKind.Utc),
                    Conclusion = new DateTime(2003, 2,1,13,59,32,DateTimeKind.Utc),
                    PlatformID = 7,
                }
            };
            List<Person> people = new List<Person>
            {
                new Person
                {
                    FirstName = "Jane",
                    FamilyName = "Doe",
                    Affiliation = "Fake person for seed data",
                    City = "Melbourne",
                    State = "Victoria",
                    Country = "Australia",
                    Email = "example@email.com",
                    InstitutionID = "49 781 030 034"
                },
                new Person
                {
                    FirstName = "Jane2",
                    FamilyName = "Doe2",
                    Affiliation = "Fake person for seed data",
                    City = "Melbourne",
                    State = "Victoria",
                    Country = "Australia",
                    Email = "example2@email.com",
                    InstitutionID = "84 002 705 224"
                }
            };
            List<Experiment> experiments = new List<Experiment>{
                new Experiment
                {
                    Title = "Experiment 1",
                    DateOfSubmission = new DateTime(2019, 10,3,7,37,0,DateTimeKind.Utc),
                    TOA = ActivityType.Applied_research,
                    Aim = "Aim",
                    Objective = "Objective",
                    Summary = "Summary",
                    ModuleDrawing = "Fake.url",
                    Status = ExperimentStatus.Finished,
                    EvaluationStatus = EvaluationStatus.Approved,
                    FeildOfResearch = "000000",
                    SocialEconomicObjective = "000000",
                    LeadInstitutionID = "84 002 705 224",
                    MissionID = 1
                },
                new Experiment
                {
                    Title = "Experiment 2",
                    DateOfSubmission = new DateTime(2019, 10,3,7,37,0,DateTimeKind.Utc),
                    TOA = ActivityType.Applied_research,
                    Aim = "Aim",
                    Objective = "Objective",
                    Summary = "Summary",
                    ModuleDrawing = "Fake.url",
                    Status = ExperimentStatus.Finished,
                    EvaluationStatus = EvaluationStatus.Approved,
                    FeildOfResearch = "000000",
                    SocialEconomicObjective = "000000",
                    LeadInstitutionID = "84 002 705 224",
                    MissionID = 1
                }

            };
            List<Participation> participations = new List<Participation>
            {
                new Participation
                {
                    PersonID = 1,
                    RoleID = 1,
                    ExperimentID = 1
                },
                new Participation
                {
                    PersonID = 2,
                    RoleID = 2,
                    ExperimentID = 2
                }
            };
            List<ResultDataset> datasets = new List<ResultDataset>
            {
                new ResultDataset
                {
                    Name = "dummy dataset",
                    RepoUrl = " ",
                    ExperimentID = 1
                },
                new ResultDataset
                {
                    Name = "dummy dataset 2",
                    RepoUrl = " ",
                    ExperimentID = 2
                }
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

                context.Roles.AddRange(roles);
                context.SaveChanges();
                context.Platforms.AddRange(platforms);
                context.SaveChanges();
                context.Institutions.AddRange(institutions);
                context.SaveChanges();
                context.Missions.AddRange(missions);
                context.SaveChanges();
                context.People.AddRange(people);
                context.SaveChanges();
                context.Experiments.AddRange(experiments);
                context.SaveChanges();
                context.Participations.AddRange(participations);
                context.SaveChanges();
                context.ResultDatasets.AddRange(datasets);

                context.SaveChanges();
            }
        }
    }
}

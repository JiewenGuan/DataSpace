using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using DataSpace.Models;
using System.Collections.Generic;
using System.Security.Principal;
using SimpleHashing;

namespace DataSpace.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            List<ExpRole> roles = new List<ExpRole>
            {
                    new ExpRole
                    {
                        Title = "Principal Investigator",
                        RoleDescription = "investigate principle",
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved
                    },

                    new ExpRole
                    {
                        Title = "Researcher ",
                        RoleDescription = "research",
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved
                    },

                    new ExpRole
                    {
                        Title = "Flight Engineer",
                        RoleDescription = "Assist in Parabolic Flight",
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved
                    }
            };
            List<Institution> institutions = new List<Institution>
            {
                new Institution
                {
                    ABN = "49 781 030 034",
                    Name = "RMIT",
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved
                },
                new Institution
                {
                    ABN = "84 002 705 224",
                    Name = "University of Melbourne",
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved
                }
            };
            List<Platform> platforms = new List<Platform>
            {
                new Platform {Name = "ISS",Type = PlatformType.Space_Station, Discription = "International Space Station",
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved},
                new Platform {Name = "DeepSpace Gateway",Type = PlatformType.Space_Station,
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved},
                new Platform {Name = "MIR",Type = PlatformType.Space_Station,
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved},
                new Platform {Name = "Salyut",Type = PlatformType.Space_Station,
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved},
                new Platform {Name = "Skylab",Type = PlatformType.Space_Station,
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved},
                new Platform {Name = "Apollo",Type = PlatformType.Space_Station,
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved},
                new Platform {Name = "Columbia",Type = PlatformType.Space_Shuttle,
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved},
            };
            List<Mission> missions = new List<Mission>
            {
                new Mission{
                    Name = "ISS Increment 60",
                    Commancement = new DateTime(2019, 6,24,23,25,0,DateTimeKind.Utc),
                    Conclusion = new DateTime(2019, 10,3,7,37,0,DateTimeKind.Utc),
                    PlatformID = 1,
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved
                },
                new Mission{
                    Name = "STS-107",
                    Commancement = new DateTime(2003, 1,16,15,39,0,DateTimeKind.Utc),
                    Conclusion = new DateTime(2003, 2,1,13,59,32,DateTimeKind.Utc),
                    PlatformID = 7,
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved
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
                    InstitutionID = "49 781 030 034",
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved
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
                    InstitutionID = "84 002 705 224",
                        DateOfSubmission = DateTime.Now,
                        EvaluationStatus = EvaluationStatus.Approved
                }
            };
            List<Login> logins = new List<Login>
            {
                new Login
                {
                    LoginID = "Dataspace_1",
                    PasswordHash = PBKDF2.Hash("Asa2020"),
                    ModifyDate = DateTime.Now,
                    PersonID = 1
                },
                new Login
                {
                    LoginID = "Dataspace_2",
                    PasswordHash = PBKDF2.Hash("Asa2020"),
                    ModifyDate = DateTime.Now,
                    PersonID = 2
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
                    MissionID = 1,
                    AuthorId = 1
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
                    MissionID = 1,
                    AuthorId = 1
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
                    ExperimentID = 1,
                    DateOfSubmission = DateTime.Now,
                    EvaluationStatus = EvaluationStatus.Approved
                },
                new ResultDataset
                {
                    Name = "dummy dataset 2",
                    RepoUrl = " ",
                    ExperimentID = 2,
                    DateOfSubmission = DateTime.Now,
                    EvaluationStatus = EvaluationStatus.Approved
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

                context.ExpRoles.AddRange(roles);
                context.SaveChanges();
                context.Platforms.AddRange(platforms);
                context.SaveChanges();
                context.Institutions.AddRange(institutions);
                context.SaveChanges();
                context.Missions.AddRange(missions);
                context.SaveChanges();
                context.People.AddRange(people);
                context.SaveChanges();
                context.Logins.AddRange(logins);
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
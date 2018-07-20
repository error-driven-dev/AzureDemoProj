using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psappdemo.Models
{
    public class Course
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Module> Modules { get; set; }

    }

    public class Module
    {
        public string Name { get; set; }
        public ICollection<Clip> Clips { get; set; }
    }

    public class Clip
    {
        public string Name { get; set; }
        public int Length { get; set; }
    }

    public class SeedData
    {
        public IEnumerable<Course> CourseList()
        {
            yield return new Course
            {
                Name = "Azure for .NET Developers",
                Modules = new List<Module>
                {
                    new Module
                    {
                        Name = "Introduction to Azure",
                        Clips =  new List<Clip>
                        {
                            new Clip { Length = 30, Name = "Overview" },
                            new Clip { Length = 35, Name = "Azure Portal" },
                            new Clip { Length = 30, Name = "Virtual Machines" }
                        }
                    },
                    new Module
                    {
                        Name = "Cloud Databases",
                        Clips =  new List<Clip>
                        {
                            new Clip { Length = 30, Name = "Overview" },
                            new Clip { Length = 35, Name = "Azure SQL" },
                            new Clip { Length = 30, Name = "Cosmos DB" }
                        }
                    }
                }
            };

            yield return new Course
            {
                Name = "Building Secure Services in Azure",
                Modules = new List<Module>
                {
                    new Module
                    {
                        Name = "Azure AD",
                        Clips =  new List<Clip>
                        {
                            new Clip { Length = 30, Name = "Creating Apps" },
                            new Clip { Length = 35, Name = "Using OIDC" },
                            new Clip { Length = 30, Name = "Managing users" }
                        }
                    },

                    new Module
                    {
                        Name = "Azure Resource Manager",
                        Clips =  new List<Clip>
                        {
                            new Clip { Length = 30, Name = "Automation!" },
                            new Clip { Length = 35, Name = "ARM Templates" },
                        }
                    }
                }
            };
        }
    }
}

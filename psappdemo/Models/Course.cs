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
        public int Id { get; set; }
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
}

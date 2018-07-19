using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using psappdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psappdemo.Services
{
    public class CourseStore
    {
        private DocumentClient _client;
        private Uri _courseLink;
        public CourseStore()
        {
            var uri = new Uri("https://psappdemocosmos.documents.azure.com:443/");
            var key = "Nc272XjcVsJwCB4RJvt9o2MAv5Dqb6RSO7YhWQmviQvflA7uUc4gUVE9kEfuB91qHPddSgyrFt48AqzGUWFu3A==";
            _client = new DocumentClient(uri, key);

            _courseLink = UriFactory.CreateDocumentCollectionUri("psappdemo", "Courses");
         }

        public async Task InsertCourses(Course course)
        {
            
                await _client.CreateDocumentAsync(_courseLink, course);
            
        }

        public IEnumerable<Course> GetCourses()
        {
            var courses = _client.CreateDocumentQuery<Course>(_courseLink)
                .OrderBy(c => c.Name);
            return courses;
        }

        


    }
}

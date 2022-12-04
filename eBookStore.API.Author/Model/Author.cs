using System;
using System.Collections.Generic;

namespace eBookStore.API.Author.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

        public ICollection<AcademicDegree> AcademicDegrees { get; set; }
    }
}

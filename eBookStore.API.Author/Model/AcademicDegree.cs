using System;

namespace eBookStore.API.Author.Model
{
    public class AcademicDegree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CenterName { get; set; }
        public DateTimeOffset AchievedOn { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

using ResumeProjectDemo.Entities;

namespace ResumeProjectDemo.Dtos
{
    public class AboutModel
    {
        public List<Experience> Experiences { get; set; }
        public List<Education> Educations { get; set; }
        public About About { get; set; } 
    }
}

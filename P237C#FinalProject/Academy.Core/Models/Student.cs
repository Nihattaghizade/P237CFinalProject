using Academy.Core.Enums;
using Academy.Core.Models.BaseModels;

namespace Academy.Core.Models
{
    public class Student : BaseModel
    {
        static int _id;
        public string FullName { get; set; }
        public string Group { get; set; }
        public double Average { get; set; }
        public EducationType EducationType { get; set; }

        public Student(string fullName,string group,double average, EducationType educationType)
        {
            _id++;
            
            FullName = fullName;
            Group = group;
            Average = average;
            EducationType = educationType;
            Id = $"{EducationType.ToString()[0]}-{_id}";
        }
    }
}

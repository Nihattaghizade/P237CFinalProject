using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository=new StudentRepository();
        public async Task<string> CreateAsync(string fullName, string group, double avarage, EducationType educationType)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return "Fullname can't be empty";
            if (string.IsNullOrWhiteSpace(group))
                return "Group can't be empty";
            if (avarage <= 0 || avarage > 100)
                return "Avarage can be arrange of 1-100";

            Student student=new Student(fullName, group, avarage, educationType);
            student.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _studentRepository.CreateAsync(student);
            return "Successfully created";
        }

        public async Task GetAllAsync()
        {
            List<Student> students = await _studentRepository.GetAllAsync();
            foreach (Student student in students)
            {
                Console.WriteLine($"Id: {student.Id} Fullname: {student.FullName} Group: {student.Group} Avarage: {student.Average} EducationType: {student.EducationType} CreatedAt: {student.CreatedAt} UpdatedAt: {student.UpdatedAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found";

            Console.WriteLine($"Id: {student.Id} Fullname: {student.FullName} Group: {student.Group} Avarage: {student.Average} EducationType: {student.EducationType} CreatedAt: {student.CreatedAt} UpdatedAt: {student.UpdatedAt}");
            return "Success";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found";

            await _studentRepository.RemoveAsync(student);
            return "Removed successfully";
        }

        public async Task<string> UpdateAsync(string id, string fullName, string group, double avarage, EducationType educationType)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);

            if (student == null)
                return "Student not found";
            if (string.IsNullOrWhiteSpace(fullName))
                return "Fullname can't be empty";
            if (string.IsNullOrWhiteSpace(group))
                return "Group can't be empty";
            if (avarage < 0)
                return "Avarage cen't be less than 0";

            student.FullName = fullName;
            student.Group = group;
            student.Group = group;
            student.EducationType = educationType;
            student.UpdatedAt = DateTime.UtcNow.AddHours(4);
            return "Updated successfully";
        }
    }
}

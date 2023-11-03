using Academy.Core.Enums;
using Academy.Service.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Academy.Service.Services.Implementations
{
    public class MenuService
    {
        IStudentService studentService = new StudentService();

        public async Task RunApp()
        {
            await Menu();
            string request = Console.ReadLine();
            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        await CreateStudent();
                        break;
                    case "2":
                        await UpdateStudent();
                        break;
                    case "3":
                        await RemoveStudent();
                        break;
                    case "4":
                        await GetAllStudents();
                        break;
                    case "5":
                        await Get();
                        break;
                    default:
                        break;
                }
                await Menu();
                request = Console.ReadLine();
            }
        }

        async Task CreateStudent()
        {
            Console.WriteLine("Add fullname");
            string FullName = Console.ReadLine();
            Console.WriteLine("Add group");
            string Group = Console.ReadLine();
            Console.WriteLine("Add avarage");
            double.TryParse(Console.ReadLine(), out double Avarage);
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(EducationType)))
            {
                Console.WriteLine($"{i}.{item}");
                i++;
            }
            bool IsExist;
            int EnumIndex;
            do
            {
                int.TryParse(Console.ReadLine(), out EnumIndex);
                Console.WriteLine("Add EducationType");
                IsExist = Enum.IsDefined(typeof(EducationType), (EducationType)EnumIndex);
            } while (!IsExist);
            string result = await studentService.CreateAsync(FullName, Group, Avarage, (EducationType)EnumIndex);
            Console.WriteLine(result);
        }

        async Task UpdateStudent()
        {
            Console.WriteLine("Add id");
            string Id = Console.ReadLine();
            Console.WriteLine("Add fullname");
            string FullName = Console.ReadLine();
            Console.WriteLine("Add group");
            string Group = Console.ReadLine();
            Console.WriteLine("Add avarage");
            double.TryParse(Console.ReadLine(), out double Avarage);
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(EducationType)))
            {
                Console.WriteLine($"{i}.{item}");
                i++;
            }
            bool IsExist;
            int EnumIndex;
            do
            {
                int.TryParse(Console.ReadLine(), out EnumIndex);
                Console.WriteLine("Add EducationType");
                IsExist = Enum.IsDefined(typeof(EducationType), (EducationType)EnumIndex);
            } while (!IsExist);
            string result = await studentService.UpdateAsync(Id,FullName, Group, Avarage, (EducationType)EnumIndex);
            Console.WriteLine(result);
        }
        async Task RemoveStudent()
        {
            Console.WriteLine("Add id");
            string Id = Console.ReadLine();
            string result = await studentService.RemoveAsync(Id);
            Console.WriteLine(result);
        }

        async Task GetAllStudents()
        {
            await studentService.GetAllAsync();
        }

        async Task Get()
        {
            Console.WriteLine("Add id");
            string Id = Console.ReadLine();
            string result = await studentService.GetAsync(Id);
            Console.WriteLine(result);
        }

        async Task Menu()
        {
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. GetAll");
            Console.WriteLine("5. Get");
            Console.WriteLine("0. Close");
        }
    }
}

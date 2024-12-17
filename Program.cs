using System.Diagnostics.Metrics;
using System.Transactions;

namespace University_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // add Department 
            var csDepartment=new Department("Computer Science");
            var ItDepartment = new Department("Information technology");

            var DRzeyadYasser = new Professor("zeyad", 12345);
            var DRAhamdsaad = new Professor("Ahamd",23434);
            var DRmohamadossman = new Professor("mohamad", 32434);
            var DRsaadYasser= new Professor("Saad", 23456);

            csDepartment.professors.Add(DRsaadYasser);
            csDepartment.professors.Add(DRmohamadossman);
            ItDepartment.professors .Add(DRzeyadYasser);
            ItDepartment.professors.Add (DRAhamdsaad);

            var datastructr = new Course("Data structer");
            var database = new Course("Data base");
            var electronics = new Course("electroncs");
            var webapplication = new Course("web application");

            csDepartment.Course.Add(datastructr);
            csDepartment.Course.Add(database);
            ItDepartment.Course.Add(electronics);
            ItDepartment.Course.Add(webapplication);

            DRAhamdsaad.AssignCorses(database);
            DRmohamadossman.AssignCorses(database);
            DRsaadYasser.AssignCorses(electronics);
            DRzeyadYasser.AssignCorses(webapplication);
            DRzeyadYasser.AssignCorses (datastructr);

            var student1 = new Student("saad", 90080);
            var student2 = new Student("ahamd", 08889);
            var student3 = new Student("gana", 32434);
            var student4 = new Student("sama", 89786);

           student1.EnrollInCourses(webapplication);
            student1.EnrollInCourses(database);
            student1.EnrollInCourses (electronics);
            student1.EnrollInCourses(datastructr);

            student2.EnrollInCourses(webapplication);
            student2.EnrollInCourses(database);
            student2.EnrollInCourses(electronics);
            student2.EnrollInCourses(datastructr);

            student3.EnrollInCourses(webapplication);
            student3.EnrollInCourses(database);
            student3.EnrollInCourses(electronics);
            student3.EnrollInCourses(datastructr);

            student4.EnrollInCourses(webapplication);
            student4.EnrollInCourses(database);
            student4.EnrollInCourses(electronics);
            student4.EnrollInCourses(datastructr);
            ////////////////////////////////////////////
            Reports.TotalCoursesOffered(csDepartment);
            Reports.TotalCoursesOffered(ItDepartment);

            Reports.StudentsEnrolledInCourse(database);
            Reports.StudentsEnrolledInCourse(electronics);
            Reports.StudentsEnrolledInCourse(datastructr);
            Reports.StudentsEnrolledInCourse(webapplication);
            Reports.professorAndCorses(ItDepartment);
            Reports.professorAndCorses(csDepartment);


        }
    }
    public class person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public person(string Name, int id)
        {
            this.Name = Name;
            this.Id = id;
        }
    }
    public class Student : person
    {
        public List<Course> EnrollInCourse { get; set; } = new List<Course>();
        public string Name { get; set; }
        public int Id { get; set; }
        public Student(string Name, int Id) : base(Name, Id)
        {

            this.Name = Name;
            this.Id = Id;
        }
        public void EnrollInCourses(Course corse)
        {
            EnrollInCourse.Add(corse);
            corse.EnrollStudent(this);
        }
    }

    public class Course
    {
        public string CoursesName { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
        public Course(string coresesName)
        {
        

            this.CoursesName = coresesName;

        }
        public void EnrollStudent(Student student)
        {
            EnrolledStudents.Add(student);
        }

    }
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Professor>professors { get; set; }= new List<Professor>();
        public List<Course> Course { get; set; }=new List<Course>();
        public Department(string departmentName)
        {
           
            this.DepartmentName = departmentName;
        }

    }
    public class ManagerProfessors : person
    {
        public ManagerProfessors(string Name, int Id) : base(Name, Id) { }
        public void ManagePolicies()
        {
            Console.WriteLine($"{Name} is managing department policies.");
        }
    }
    public class Professor : person
    {
        public List<Course> Corses { get; set; } = new List<Course>();
        public Professor(string Name, int Id) : base(Name, Id) { }
        public void AssignCorses(Course courses)
        {
            Corses.Add(courses);
        }
    }
    public static class Reports
    {
        public static void TotalCoursesOffered(Department department)
        {
            Console.WriteLine($"TotalCoursesOffered by{department.DepartmentName}:{department.Course.Count}");
        }
        public static void professorAndCorses(Department department)
        {
            Console.WriteLine($"Professors and their assigned courses in {department.DepartmentName}:");
            foreach (var professer in department.professors)
            {
                Console.WriteLine($"professor:{professer.Name}");
                foreach (var courses in professer.Corses)
                {
                    Console.WriteLine($"\t {courses.CoursesName}");
                }
            }
        }
       
        public static void StudentsEnrolledInCourse(Course course)
        {
            Console.WriteLine($"Students enrolled in {course.CoursesName}:");
            foreach (var student in course.EnrolledStudents)
            {
                
                Console.WriteLine($"*: {student.Name}");
            }
        }
    }
}
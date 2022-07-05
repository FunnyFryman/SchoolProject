using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp56
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public string Age;
        public int Number = 1;

        public Student(string firstName, string lastName, string age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Student(string firstName, string lastName, string age, int number)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Number = number;
        }
    }
    public class School
    {
        public string Name;
        public string Age;
        public List<Student> Students;

        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }



        public void PrintStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine($"В школе {Name} пока нет учеников!");
            }
            else
                Console.WriteLine("{0, -10}{1, -10}{2, -10}{3, -10}", "Имя", "Фамилия", "Возраст", "Номер");
            {
                int cnt = 0;
                for (int i = 0; i < Students.Count; i++)
                {
                    cnt++;
                    Console.WriteLine("{0,-10} {1, -10} {2, -10} {3, -10}", Students[i].FirstName, Students[i].LastName, Students[i].Age, cnt);

                }
            }
        }
        public void DeductionStudent(int NumberOfStudents)
        {
            string nameOfRemovedfStudent = Students[NumberOfStudents - 1].FirstName;
            Students.RemoveAt(NumberOfStudents - 1);
            Console.WriteLine($"Студент {nameOfRemovedfStudent} отчислен!");

        }
        public int NumberOfStudents()
        {
            return Students.Count;
        }
        public void AddNewStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"Студент {student.FirstName} успешно добавлен в школу {Name}.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте введите название вашей школы");
            string schoolName = Console.ReadLine();

            School school = new School(schoolName);
            Console.WriteLine($"Школа {school.Name} успешно создана");
            while (true)
            {

                Console.WriteLine($"Хотите посмотреть список учеников школы {school.Name}? Введите да или нет. ");
                string userAnswer = Console.ReadLine();
                if (userAnswer.ToUpper() == "ДА")
                {
                    school.PrintStudents();
                }
                Console.WriteLine($"Хотите добавить нового ученика в школу {school.Name}? Введите да или нет. ");
                userAnswer = Console.ReadLine();
                if (userAnswer.ToUpper() == "ДА")
                {
                    Console.WriteLine($"Введите имя ученика");
                    string firstName = Console.ReadLine();
                    Console.WriteLine($"Введите фамилию ученика");
                    string lastName = Console.ReadLine();
                    Console.WriteLine($"Введите возраст ученика");
                    string age = Console.ReadLine();

                    Student student = new Student(firstName, lastName, age);
                    school.AddNewStudent(student);
                }
                Console.WriteLine($"Хотите отчислить ученика из школы {school.Name}? Введите да или нет. ");
                userAnswer = Console.ReadLine();
                if (userAnswer.ToUpper() == "ДА")
                {
                    try
                    {
                        int x = 10000;
                        Console.WriteLine($"Введите номер ученика");
                        int number = Convert.ToInt32(Console.ReadLine());
                        if (number <= x && number > 0)
                        {
                            school.DeductionStudent(number);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка 404");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("ошибка 404");
                    }
                }
            }
        }
    }
}
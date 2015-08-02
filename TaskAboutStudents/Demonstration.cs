using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAboutStudents.InfoAboutStudents;

namespace TaskAboutStudents
{
    class Demonstration
    {
        static void Main(string[] args)
        {
            Student[] student = Initialization();
            Marks marks = new Marks();

            Task(student, marks);
            
            Console.WriteLine();
            Console.WriteLine(" После изменения группы и оценок студента ");
            Console.WriteLine();

            Task(student, marks);
            
            Console.ReadKey();
        }

        /* Начальная инициализация
         * Выходные данные: массив студентов */
        static Student[] Initialization()
        {
            Student[] student = new Student[4];
            DataOfBirth dataOfBirth;
            UniversityGroup universityGroup;
            Marks marks;

            /* 1-ый студент */
            dataOfBirth = new DataOfBirth { Year = 1995, Month = 3, Day = 28, Town = "Запорожье" };
            universityGroup = new UniversityGroup { Name = "PZ10" };
            marks = new Marks { Scores = new int[] { 5, 5, 5} };
            student[0] = new Student("Жеваго", "Александр", dataOfBirth, universityGroup, marks);

            /* 2-ой студент */
            dataOfBirth = new DataOfBirth { Year = 1973, Month = 2, Day = 3, Town = "Житомир" };
            universityGroup = new UniversityGroup { Name = "PZ10" };
            marks = new Marks { Scores = new int[] { 5, 5, 5 } };
            student[1] = new Student("Жеваго", "Елена", dataOfBirth, universityGroup, marks);

            /* 3-ий студент */
            dataOfBirth = new DataOfBirth { Year = 1995, Month = 7, Day = 20, Town = "Самара" };
            universityGroup = new UniversityGroup { Name = "PZ12" };
            marks = new Marks { Scores = new int[] { 5, 5, 5 } };
            student[2] = new Student("Беляев", "Виталий", dataOfBirth, universityGroup, marks);

            /* 4-ый студент */
            dataOfBirth = new DataOfBirth { Year = 1994, Month = 12, Day = 13, Town = "Днепропетровск" };
            universityGroup = new UniversityGroup { Name = "PZ12" };
            marks = new Marks { Scores = new int[] { 5, 5, 5 } };
            student[3] = new Student("Файфер", "Сергей", dataOfBirth, universityGroup, marks);

            return student;
        }

        /* Выполнение задачи
         * Входные данные: массив студентов, объект класса Marks */
        static void Task(Student[] student, Marks marks)
        {
            foreach (var item in student)
            {
                Console.WriteLine(" Имя студента: {0}", item.GetFullName(item));
                Console.WriteLine(" Возраст: {0}", item.GetAge(item));
                Console.WriteLine(" Средний балл: {0:0.###}", item.GetAverageScore(item));
                Console.WriteLine(" Группа: {0}", item.GetGroup(item));
                Console.WriteLine("____________________________________________");
            }

            for (int i = 0; i < marks.Subjects.Length; i++)
            {
                Console.WriteLine(" Средний балл по предмету {0} = {1:0.###}", marks.Subjects[i], student[i].GetAverageScoreForSubject(student, i));
            }
            Console.WriteLine("____________________________________________");

            List<string> univerityGroups = student[0].GetAllUniversutyGroup(student);

            foreach (var item in univerityGroups)
            {
                Console.WriteLine(" Средний балл группы {0} = {1:0.###}", item, student[0].GetAverageScoreGroup(student, item));
                Console.WriteLine(" Средний возраст группы {0} = {1:0.##}", item, student[0].GetAverageAgeGroup(student, item));
                Console.WriteLine("____________________________________________");
            }

            student[0].EditGroupStudent(student[0], univerityGroups.Last());
            student[0].EditScores(student[3], new int[] { 4, 5, 4 });
                    
        }
    }
}

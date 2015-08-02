using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskAboutStudents.InfoAboutStudents;

namespace TaskAboutStudents
{
    /* Класс который представляет собой информацию о студенте */
    public class Student
    {
        private string firstName; // имя
        private string lastName; // фамилия
        private DataOfBirth dataOfBirth; // дата рождения
        private UniversityGroup universityGroup; // группа
        private Marks marks; // оценки по предметам

        /* Конструктор который инициализирует поля класса */
        public Student(string firstName, string lastName, DataOfBirth dataOfBirth, UniversityGroup universityGroup, Marks marks)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dataOfBirth = dataOfBirth;
            this.universityGroup = universityGroup;
            this.marks = marks;
        }
        
        /* Метод рассчета возраста
           Входные данные: информация о студенте
           Выходные данные: возраст студента
        */
        public int GetAge (Student student)
        {
            int age = 0;
            if (student.dataOfBirth.Year == DateTime.Today.Year) // если родился в этом году
            {
                return 0;
            }
            else if (student.dataOfBirth.Year > DateTime.Today.Year) // если еще не родился
            {
                return -1;
            }
            else
            {
                age = DateTime.Today.Year - student.dataOfBirth.Year;

                if (student.dataOfBirth.Month == DateTime.Today.Month) // если родился в текущем месяце
                {
                    if (student.dataOfBirth.Day <= DateTime.Today.Day) // если день рождения уже прошел
                    {
                        return age;
                    }
                    else
                    {
                        return age - 1;
                    }
                }
                else if (student.dataOfBirth.Month < DateTime.Today.Month) // если родился в месяце который уже прошел
                {
                    return age;
                }
                else
                {
                    return age - 1;
                }
            }
        }

        /* Метод который возвращает полное имя студента
           Входные данные: информация о студенте
           Выходные данные: полное имя студента
        */
        public string GetFullName(Student student)
        {
            return student.lastName + " " + student.firstName;
        }

        /* Метод который возвращает группу студента
           Входные данные: информация о студенте
           Выходные данные: группа студента
        */
        public string GetGroup(Student student)
        {
            return student.universityGroup.Name;
        }

        /* Метод который изменяет группу в которой учится студент
           Входные данные: информация о студенте, имя новой группы
        */
        public void EditGroupStudent(Student student, string nameNewGroup)
        {
            student.universityGroup.Name = nameNewGroup;
        }

        /* Метод который изменяет оценки студента
           Входные данные: информация о студенте, перечень оценок студента
        */
        public void EditScores(Student student, int[] scores)
        {
            student.marks.Scores = scores;
        }

        /* Метод который возвращает средний балл студента
           Входные данные: информация о студенте
           Выходные данные: средний балл
        */
        public double GetAverageScore(Student student)
        {
            double averageScore = student.marks.Scores.Sum() / student.marks.Scores.Length;
            return averageScore;
        }

        /* Метод который возвращает средний балл студентов по предмету
           Входные данные: массив студентов, id предмета
           Выходные данные: средний балл студентов по предмету
        */
        public double GetAverageScoreForSubject(Student[] student, int idSubject)
        {
            double averageScore = 0.0;
            foreach (var item in student)
            {
                averageScore += item.marks.Scores[idSubject];
            }
               
            return averageScore / student.Length;
        }

        /* Метод который возвращает список групп
           Входные данные: массив студентов
           Выходные данные: список групп
        */
        public List<string> GetAllUniversutyGroup(Student[] student)
        {
            List<string> listUniversityGroup = new List<string>();
            foreach (var item in student)
            {
                if (!listUniversityGroup.Contains(item.universityGroup.Name))
                {
                    listUniversityGroup.Add(item.universityGroup.Name);
                }
            }
            return listUniversityGroup;
        }

        /* Метод который возвращает средний балл группы
           Входные данные: массив студентов, имя группы
           Выходные данные: средний балл группы
        */
        public double GetAverageScoreGroup(Student[] student, string groupName)
        {
            int countStudents = 0;
            double averageScoreGroup = 0.0;

            foreach (var item in student)
            {
                if (item.universityGroup.Name.Equals(groupName))
                { 
                    averageScoreGroup += GetAverageScore(item);
                    countStudents++;
                }
            }
            return averageScoreGroup / countStudents;
        }

        /* Метод который возвращает средний возраст студентов группы
           Входные данные: массив о студенте, имя группы
           Выходные данные: средний возраст группы
        */
        public double GetAverageAgeGroup(Student[] student, string groupName)
        {
            int countStudents = 0;
            double averageAgeGroup = 0.0;

            foreach (var item in student)
            {
                if (item.universityGroup.Name.Equals(groupName))
                {
                    averageAgeGroup += item.GetAge(item);
                    countStudents++;
                }
            }
            return averageAgeGroup / countStudents;
        }
    }
}

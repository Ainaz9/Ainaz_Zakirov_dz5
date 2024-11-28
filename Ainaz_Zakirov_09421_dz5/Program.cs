// dz
using System;
using System.Drawing;
using System.Xml.Linq;
using System.Collections.Generic;
using static dz5.dz1;

namespace dz5
{
    public class dz1
    {
        // #2
        static List<Student> students = new List<Student>();
        // #3
        static Queue<Babulya> babulyaQueue = new Queue<Babulya>();
        static Stack<Hospital> hospitalStack = new Stack<Hospital>();
        public static void Main(string[] args)
        {
            /* #1 Создать List на 64 элемента, скачать из интернета 32 пары картинок (любых). В List
            должно содержаться по 2 одинаковых картинки. Необходимо перемешать List с
            картинками. Вывести в консоль перемешанные номера (изначальный List и полученный
            List). Перемешать любым способом. */
            Console.WriteLine("Номер 1: ");
            var images = new List<string>();
            for (int i = 0; i < 32; i++)
            {
                string imagePath = $"C:\\Ползователи\\Admin\\source\\repos\\Ainaz_Zakirov_09421_dz\\Картинки\\Image1.jpg{i + 1}.jpg";
                images.Add(imagePath);
                images.Add(imagePath);
            }
            Console.WriteLine("Исходный список:");
            PrintImages(images);
            Shuffle(images);
            Console.WriteLine("Перемешанный список:");
            PrintImages(images);
            Console.WriteLine();
            /* #2 Создать студента из вашей группы (фамилия, имя, год рождения, с каким экзаменом
            поступил, баллы). Создать словарь для студентов из вашей группы (10 человек).
            Необходимо прочитать информацию о студентах с файла. В консоли необходимо создать
            меню:
            a. Если пользователь вводит: Новый студент, то необходимо ввести
            информацию о новом студенте и добавить его в List
            b. Если пользователь вводит: Удалить, то по фамилии и имени удаляется
            студент
            c. Если пользователь вводит: Сортировать, то происходит сортировка по баллам
            (по возрастанию) */
            Console.WriteLine("Номер 2: ");
            LoadStudentsFromFile("Студент.txt");
            bool task2 = true;
            while (task2)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Новый студент");
                Console.WriteLine("2. Удалить студента");
                Console.WriteLine("3. Сортировать студентов по баллам");
                Console.WriteLine("4. Выход");
                Console.Write("Введите команду: ");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        AddNewStudent();
                        break;

                    case "2":
                        DeleteStudent();
                        break;

                    case "3":
                        SortStudents();
                        break;

                    case "4":
                        SaveStudentsToFile("students.txt");
                        task2 = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда. Попробуйте снова.");
                        break;
                }
            }
            Console.WriteLine();
            /* #3 Создать бабулю. У бабули есть Имя, возраст, болезнь и лекарство от этой болезни,
            которое она принимает (болезней может быть у бабули несколько). Реализуйте список
            бабуль. Также есть больница (у больницы есть название, список болезней, которые они
            лечат и вместимость). Больниц также, как и бабуль несколько. Бабули по очереди
            поступают (реализовать ввод с клавиатуры) и дальше идут в больницу, в зависимости от
            заполненности больницы и списка болезней, которые лечатся в данной больнице,
            реализовать функционал, который будет распределять бабулю в нужную больницу. Если
            бабуля не имеет болезней, то она хочет только спросить - она может попасть в первую
            свободную клинику. Если бабулю ни одна из больниц не лечит, то бабуля остаётся на
            улице плакать. На экран выводить список всех бабуль, список всех больниц, болезни,
            которые там лечат и сколько бабуль в данный момент находится в больнице, также
            вывести процент заполненности больницы. P.S. Бабуля попадает в больницу, если там
            лечат более 50% ее болезней. Больницы реализовать в виде стека, бабуль в виде
            очереди.  */
            Console.WriteLine("Номер 3: ");
            hospitalStack.Push(new Hospital("Больница 1", 3));
            hospitalStack.Peek().AddDisease("Грипп");
            hospitalStack.Push(new Hospital("Больница 2", 2));
            hospitalStack.Peek().AddDisease("ОРВИ");
            hospitalStack.Push(new Hospital("Больница 3", 1));
            hospitalStack.Peek().AddDisease("Диабет");
            bool task3 = true;
            while (task3)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить бабулю");
                Console.WriteLine("2. Распределить бабулю по больнице");
                Console.WriteLine("3. Показать список бабуль и больниц");
                Console.WriteLine("4. Выход");
                Console.Write("Введите команду: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        AddBabulyaFromInput();
                        break;

                    case "2":
                        AdmitBabulyaToHospital();
                        break;

                    case "3":
                        ShowBabulyaAndHospitals();
                        break;

                    case "4":
                        task3 = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда. Попробуйте снова.");
                        break;
                }
            }
            Console.WriteLine();
            /* #4 Написать метод для обхода графа в глубину или ширину - вывести на экран кратчайший
            путь. */
            Console.WriteLine("Номер 4: ");

            Console.WriteLine();
        }
        // #1
        public static void Shuffle(List<string> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static void PrintImages(List<string> images)
        {
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"Элемент {i + 1}: {images[i]}");
            }
        }
        // #2
        public class Student
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public int BirthYear { get; set; }
            public string Exam { get; set; }
            public int Score { get; set; }
            public Student(string lastName, string firstName, int birthYear, string exam, int score)
            {
                LastName = lastName;
                FirstName = firstName;
                BirthYear = birthYear;
                Exam = exam;
                Score = score;
            }
            public override string ToString()
            {
                return $"{LastName} {FirstName}, {BirthYear} г.р., Экзамен: {Exam}, Баллы: {Score}";
            }
        }
        static void AddNewStudent()
        {
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите год рождения: ");
            string year = Console.ReadLine();
            int birthYear;
            if (int.TryParse(year, out birthYear))
            {

            }
            else
            {
                Console.WriteLine("Ввведите год рождения в цифрах");
            }
            Console.Write("Введите экзамен: ");
            string exam = Console.ReadLine();
            Console.Write("Введите баллы: ");
            string bal = Console.ReadLine();
            int score;
            if (int.TryParse(bal, out score))
            {

            }
            else
            {
                Console.WriteLine("Ввведите ваш балл в цифрах");
            }
            students.Add(new Student(lastName, firstName, birthYear, exam, score));
            Console.WriteLine("Новый студент добавлен.");
        }
        static void DeleteStudent()
        {
            Console.Write("Введите фамилию для удаления: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя для удаления: ");
            string firstName = Console.ReadLine();
            var studentToRemove = students.FirstOrDefault(s => s.LastName == lastName && s.FirstName == firstName);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                Console.WriteLine("Студент удалён.");
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }
        static void SortStudents()
        {
            students.Sort((s1, s2) => s1.Score.CompareTo(s2.Score));
            Console.WriteLine("Студенты отсортированы по баллам:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        static void LoadStudentsFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        var lastName = parts[0].Trim();
                        var firstName = parts[1].Trim();
                        var birthYear = int.Parse(parts[2].Trim());
                        var exam = parts[3].Trim();
                        var score = int.Parse(parts[4].Trim());

                        students.Add(new Student(lastName, firstName, birthYear, exam, score));
                    }
                }
            }
        }
        static void SaveStudentsToFile(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.LastName}, {student.FirstName}, {student.BirthYear}, {student.Exam}, {student.Score}");
                }
            }
        }
        // #3
        public class Babulya
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Diseases { get; set; }
            public List<string> Medicines { get; set; }

            public Babulya(string name, int age)
            {
                Name = name;
                Age = age;
                Diseases = new List<string>();
                Medicines = new List<string>();
            }

            public void AddDisease(string disease, string medicine)
            {
                Diseases.Add(disease);
                Medicines.Add(medicine);
            }

            public override string ToString()
            {
                return $"{Name}, {Age} лет, Болезни: {string.Join(", ", Diseases)}, Лекарства: {string.Join(", ", Medicines)}";
            }
        }
        public class Hospital
        {
            public string Name { get; set; }
            public List<string> TreatedDiseases { get; set; }
            public int Capacity { get; set; }
            public int Occupancy { get; set; } 
            public Hospital(string name, int capacity)
            {
                Name = name;
                Capacity = capacity;
                Occupancy = 0;
                TreatedDiseases = new List<string>();
            }
            public void AddDisease(string disease)
            {
                TreatedDiseases.Add(disease);
            }
            public bool CanTreatBabulya(Babulya babulya)
            {
                if (babulya.Diseases.Count == 0) return true; 

                int treatableDiseases = 0;
                foreach (var disease in babulya.Diseases)
                {
                    if (TreatedDiseases.Contains(disease))
                    {
                        treatableDiseases++;
                    }
                }
                return (treatableDiseases * 2 >= babulya.Diseases.Count);
            }
            public bool AdmitBabulya()
            {
                if (Occupancy < Capacity)
                {
                    Occupancy++;
                    return true;
                }
                return false;
            }

            public string GetOccupancyPercentage()
            {
                return ((double)Occupancy / Capacity * 100).ToString("F2") + "%";
            }

            public override string ToString()
            {
                return $"{Name}, Лечит: {string.Join(", ", TreatedDiseases)}, Заполняемость: {GetOccupancyPercentage()}";
            }
        }
        static void AddBabulyaFromInput()
        {
            Console.Write("Введите имя бабушки: ");
            string name = Console.ReadLine();
            Console.Write("Введите возраст бабушки: ");
            int age = int.Parse(Console.ReadLine());

            var babulya = new Babulya(name, age);

            Console.Write("Есть ли у бабушки болезни? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                while (true)
                {
                    Console.Write("Введите болезнь (или пусто для завершения): ");
                    string disease = Console.ReadLine();
                    if (string.IsNullOrEmpty(disease)) break;
                    Console.Write("Введите лекарство для этой болезни: ");
                    string medicine = Console.ReadLine();
                    babulya.AddDisease(disease, medicine);
                }
            }

            babulyaQueue.Enqueue(babulya);
            Console.WriteLine("Бабушка добавлена в очередь.");
        }
        static void AdmitBabulyaToHospital()
        {
            if (babulyaQueue.Count == 0)
            {
                Console.WriteLine("Очередь бабушек пуста.");
                return;
            }

            var babulya = babulyaQueue.Dequeue();
            bool admitted = false;

            foreach (var hospital in hospitalStack)
            {
                if (hospital.CanTreatBabulya(babulya) && hospital.AdmitBabulya())
                {
                    Console.WriteLine($"{babulya.Name} была принята в больницу {hospital.Name}.");
                    admitted = true;
                    break;
                }
            }

            if (!admitted)
            {
                Console.WriteLine($"{babulya.Name} не была принята в больницу.");
            }
        }
        static void ShowBabulyaAndHospitals()
        {
            Console.WriteLine("\nСписок бабушек:");
            foreach (var babulya in babulyaQueue)
            {
                Console.WriteLine(babulya);
            }

            Console.WriteLine("\nСписок больниц:");
            foreach (var hospital in hospitalStack)
            {
                Console.WriteLine(hospital);
            }
        }
        // #4

    }   

}
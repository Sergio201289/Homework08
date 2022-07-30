using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Homework_08_01
{
    class Program
    {
        static Company company;
        /// <summary>
        /// Метод, создающий организацию
        /// </summary>
        /// <returns>Компания</returns>
        static Company CreateCompany(out string pathcompany)
        {
            Console.WriteLine("Добро пожаловать в программу базы данных структуры компании! \n"+
            "Выберете путь для хранения базы стуктуры компании:");
            pathcompany = Console.ReadLine();

            Console.WriteLine("Введите название компании");
            string title = Console.ReadLine();

            company = new Company(title);

            return company;
        }
        /// <summary>
        /// Метод, запускающий стартовый диалог с возможностью выбора действия
        /// </summary>
        /// <param name="company">Департамаент</param>
        /// <param name="pathcompany">Путь хранения департамента</param>
        static void StartDialog(ref Company company, string pathcompany)
        {
            Console.Clear();
            Console.WriteLine("Выберите номер действия: \n" +
                "1)Извлечь организацию из файла в формате JSON \n" +
                "2)Сохранить организацию в формате JSON \n" +
                "3)Извлечь оранизацию из файла в формате XML \n" +
                "4)Сохранить организацию в формате XML \n" +
                "5)Открыть Вашу организацию");

            string Choice = Console.ReadLine();

            switch (Choice)
            {
                case ("1"):
                    Console.WriteLine("Введите путь к файлу");
                    string PathDepartment = Console.ReadLine();

                    company.Department = JsonConvert.DeserializeObject<Department>(File.ReadAllText($"{PathDepartment}.json"));
                    StartDialog(ref company, pathcompany);

                    break;
                case ("2"): 
                    File.WriteAllText($"{pathcompany}.json", JsonConvert.SerializeObject(company.Department));
                    StartDialog(ref company, pathcompany);

                    break;
                case ("3"):
                    Console.WriteLine("Введите путь к файлу");
                    PathDepartment = Console.ReadLine();
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));

                    Stream stream = new FileStream($"{PathDepartment}.xml", FileMode.Open, FileAccess.Read);
                    company.Department = (Department)xmlSerializer.Deserialize(stream);

                    stream.Close();

                    StartDialog(ref company, pathcompany);

                    break;
                case ("4"):
                    xmlSerializer = new XmlSerializer(typeof(Department));

                    Stream fStream = new FileStream($"{pathcompany}.xml", FileMode.Create, FileAccess.Write);
                    xmlSerializer.Serialize(fStream, company.Department);

                    fStream.Close();
                    StartDialog(ref company, pathcompany);
                    break;
                case ("5"): break;
                default: Console.WriteLine("Приложение будет закрыто"); Console.ReadKey(); System.Environment.Exit(0); break;
            }
        }
        /// <summary>
        /// Метод, выводящий на экран диалог действий
        /// </summary>
        static void Dialog()
        {
            Console.WriteLine("Выберите действие: \n\n" +
                "1)Войти в департамент \n" +
                "2)Добавить департамент \n" +
                "3)Редактировать департамент \n" +
                "4)Удалить департамент \n" + 
                "5)Вернуться назад \n" +
                "6)Добавить работника \n" +
                "7)Редактировать работника \n" +
                "8)Удалить работника \n" +
                "9)Отсортировать департаменты \n" +
                "10)Вывести департамент на экран \n" +
                "11)Вернуться в стартовое меню \n" +
                "12)Закрыть программу \n");
        }
        /// <summary>
        /// Метод, запускающий цикл проверки введеного значения
        /// </summary>
        /// <returns>Значение</returns>
        static public int CheckChoice()
        {
            int choice = 0;
            bool flag = false;
            while (!flag)
            {
                flag = int.TryParse(Console.ReadLine(), out choice);
                if (!flag)
                {
                    Console.Clear();
                    Console.WriteLine("Введите корректное значение!");
                }
            }
            return choice;
        }
        /// <summary>
        /// Метод, проверяющий введеное число на соответствие индексу департаментов
        /// </summary>
        /// <param name="index">Число</param>
        /// <param name="department">Департамент</param>
        /// <returns>Число</returns>
        static int CheckIndexDepartment(int index, List<Department> department)
        {
            bool flag = false;
            while (!flag)
            {
                if (index > 0 && index <= department.Count) flag = true;
                else
                {
                    Console.WriteLine("Введите корректный индекс:");
                    index = CheckChoice();
                }
            }
            return index;
        }
        /// <summary>
        /// Метод, проверяющий введеное число на соответствие индексу работников
        /// </summary>
        /// <param name="index">Число</param>
        /// <param name="departament">Департамент</param>
        /// <returns>Число</returns>
        static int CheckIndexWorker(int index,List<Worker> worker)
        {
            bool flag = false;
            while (!flag)
            {
                if (index > 0 && index <= worker.Count) flag = true;
                else
                {
                    Console.WriteLine("Введите корректный индекс:");
                    index = CheckChoice();
                }
            }
            return index;
        }
        /// <summary>
        /// Основной цикл прораммы
        /// </summary>
        /// <param name="departament">Департамент</param>
        /// <param name="pathcompany">путь к департаменту</param>
        static void ProgramCicle(Department departament, string pathcompany)
        {
            bool Flag = true;
            while (Flag)
            {
                Console.Clear();
                Console.WriteLine($"Департамент: {departament.Title}");

                Dialog();
                int Choice = CheckChoice();

                switch (Choice)
                {
                    case (1):
                        Console.Clear();
                        
                        if (departament.departments.Count==0)
                        {
                            Console.WriteLine("В выбранном месте нет ни одного департамента!");
                            Console.ReadKey(); 

                            break;
                        }
                        else departament.PrintCurrentDepartament();
                        Console.WriteLine("Выберите департамент:");
                        int i = CheckChoice();

                        ProgramCicle(departament.departments[i - 1], pathcompany);
                        break;
                    case (2):
                        Console.Clear();
                        Console.WriteLine("Введите название департмента:");
                        Department Department = new Department(Console.ReadLine());

                        departament.AddDepartment(Department);
                        break;
                    case (3):
                        Console.Clear();
                        if (departament.departments.Count == 0)
                        {
                            Console.WriteLine("В выбранном месте нет ни одного департамента!");
                            Console.ReadKey();

                            break;
                        }
                        else departament.PrintCurrentDepartament();
                        Console.WriteLine("Введите индекс департамента:");
                        int Index = CheckChoice();
                        Index = CheckIndexDepartment(Index, departament.departments);

                        Console.WriteLine("Введите новое название:");
                        string Title = Console.ReadLine();

                        departament.EditDepartment(Title, Index);
                        break;
                    case (4):
                        Console.Clear();
                        if (departament.departments.Count == 0)
                        {
                            Console.WriteLine("В выбранном месте нет ни одного департамента!");
                            Console.ReadKey();

                            break;
                        }
                        else departament.PrintCurrentDepartament();

                        Console.WriteLine("Введите индекс департамента:");
                        Index = CheckChoice();
                        Index = CheckIndexDepartment(Index, departament.departments);

                        departament.DeleteDepartment(Index);
                        break;
                    case (5): Flag = false; break;
                    case (6):
                        Console.Clear();
                        Console.WriteLine("Введите имя работника:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Введите  фамилию работника:");
                        string surname = Console.ReadLine();

                        Console.WriteLine("Введите возраст работника:");
                        int age = CheckChoice();

                        Console.WriteLine("Введите зарплату работника:");
                        int salary = CheckChoice();

                        Console.WriteLine("Введите количество проектов:");
                        int numberofprojects = CheckChoice();

                        Worker worker = new Worker(name, surname, age, departament.Title, salary, numberofprojects);
                        departament.AddWorker(worker);
                        break;
                    case (7):
                        Console.Clear();
                        if (departament.workers.Count == 0)
                        {
                            Console.WriteLine("В выбранном месте нет ни одного работника!");
                            Console.ReadKey();

                            break;
                        }
                        else departament.PrintCurrentWorker();

                        Console.WriteLine("Введите индекс работника, которого хотите отредактировать");
                        Index = CheckChoice();
                        Index = CheckIndexWorker(Index, departament.workers);

                        Console.WriteLine("Введите новое имя работника:");
                        name = Console.ReadLine();

                        Console.WriteLine("Введите новую фамилию работника:");
                        surname = Console.ReadLine();

                        Console.WriteLine("Введите новый возраст работника:");
                        age = CheckChoice();

                        Console.WriteLine("Введите новую зарплату работника:");
                        salary = CheckChoice();

                        Console.WriteLine("Введите новое количество проектов:");
                        numberofprojects = CheckChoice();

                        departament.EditWorker(name, surname, age, salary, numberofprojects, Index);
                        break;
                    case (8):
                        Console.Clear();
                        if (departament.workers.Count == 0)
                        {
                            Console.WriteLine("В выбранном месте нет ни одного работника!");
                            Console.ReadKey();

                            break;
                        }
                        else departament.PrintCurrentWorker();

                        Console.WriteLine("Введите индекс работника, которого хотите удалить");
                        Index = CheckChoice();
                        Index = CheckIndexWorker(Index, departament.workers);

                        departament.DeleteWorker(Index);
                        break;
                    case (9): Console.Clear(); departament.SortDepartment(); break;
                    case (10):
                        if (departament.departments.Count == 0)
                        {
                            Console.WriteLine("В выбранном месте нет ни одного департамента!");
                            Console.ReadKey();

                            break;
                        }
                        else departament.PrintDToConsole("");
                        Console.ReadKey(); 
                        break;
                    case (11): StartDialog(ref company, pathcompany); break;
                    case (12): System.Environment.Exit(0); break;
                    default: break;
                }
            }
        }
        static void Main(string[] args)
        {
            company = CreateCompany(out string PathCompany);
            StartDialog(ref company, PathCompany);
            ProgramCicle(company.Department, PathCompany);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;

namespace Homework_08_01
{
    /// <summary>
    /// Сруктура департамента
    /// </summary>
    public class Department
    {
        #region Поля
        
        private string title;           //Название
        
        private DateTime dateofcreation; //Дата создания

        [JsonProperty("workers")]
        public List<Worker> workers;     //Коллекция работников

        [JsonProperty("departments")]
        public List<Department> departments; //Коллекция департаментов
        #endregion

        #region Конструктор
        /// <summary>
        /// Конструктор Департамента
        /// </summary>
        /// <param name="Title">Название департамента</param>
        public Department(string Title)
        {
            this.title = Title;
            this.dateofcreation = DateTime.Now;
            this.workers = new List<Worker>();
            this.departments = new List<Department>();
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, добавляющий работника в коллекцию
        /// </summary>
        /// <param name="worker">Работник</param>
        public void AddWorker(Worker worker)
        {
            this.workers.Add(worker);
        }
        /// <summary>
        /// Метод, удаляющий работника из коллекции
        /// </summary>
        /// <param name="index">Индекс работника</param>
        public void DeleteWorker(int index)
        {
            this.workers.RemoveAt(index - 1);
        }
        /// <summary>
        /// Метод, добавляющий департамент в коллекцию
        /// </summary>
        /// <param name="department">Департамент</param>
        public void AddDepartment(Department department)
        {
            this.departments.Add(department);
        }
        /// <summary>
        /// Метод, удаляющий департамент из коллекции
        /// </summary>
        /// <param name="index">Индекс департамента</param>
        public void DeleteDepartment(int index)
        {
            this.departments.RemoveAt(index - 1);
        }
        /// <summary>
        /// Метод, редактирующий работника в коллекции
        /// </summary>
        /// <param name="choice">Выбор параметра</param>
        /// <param name="index">Индекс работника</param>
        public void EditWorker(string name,string surname, int age, int salary, int numberofprojects, int index)
        {
            this.workers[index - 1].Name = name;
            this.workers[index - 1].Surname = surname;
            this.workers[index - 1].Age = age;
            this.workers[index - 1].Salary = salary;
            this.workers[index - 1].NumberOfProjects = numberofprojects;
        }
        /// <summary>
        /// Метод, редактирующий департамент в коллекции
        /// </summary>
        /// <param name="title">Новое название</param>
        /// <param name="dateTime">Новая дата возникновения</param>
        /// <param name="index">Номер в коллекции</param>
        public void EditDepartment(string title, int index)
        {
            this.departments[index - 1].Title = title;
        }
        /// <summary>
        /// Метод, выводящий структуру организации в консоль
        /// </summary>
        /// <param name="trim">отступ</param>
        public void PrintDToConsole(string trim)
        {
            foreach (var d in this.departments)
            {
                Console.WriteLine($"{trim}{d.title}");
                d.PrintDToConsole(trim + "  ");
            }
            foreach (var w in this.workers)
            {
                Console.WriteLine($"{trim}{w.Print()}");
            }
        }
        /// <summary>
        /// Метод, выводящий в консоль список текущих департаментов
        /// </summary>
        public void PrintCurrentDepartament()
        {
            int i = 1;
            foreach(var dep in this.departments) Console.WriteLine($"{i++}){dep.title}");
        }
        /// <summary>
        /// Метод, выводящий в консоль список текущих работников
        /// </summary>
        public void PrintCurrentWorker()
        {
            int i = 1;
            foreach (var work in this.workers) Console.WriteLine($"{i++}){work.Name} {work.Surname}");
        }
        /// <summary>
        /// Метод, сортирующий коллекцию департаментов
        /// </summary>
        public void SortDepartment()
        {
            departments = departments.OrderBy(i => i.title).ToList();
        }
        #endregion

        #region Свойства
        [JsonProperty("Title")]
        public string Title { get { return this.title; } set { this.title = value; } }              //Свойство "Название"
        [JsonProperty("DateOfCreation")]
        public DateTime DateOfCreation { get { return this.dateofcreation; } set { this.dateofcreation = value; } } //Свойство "Дата создания"        
        #endregion
    }
}
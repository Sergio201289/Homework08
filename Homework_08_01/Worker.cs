using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Homework_08_01
{
    /// <summary>
    /// Структура сотрудников организации
    /// </summary>
    public class Worker
    {
        #region Поля
        private string name;        //Имя

        private string surname;     //Фамилия

        private int age;            //Возраст

        private string department;  //Департамент

        private int salary;         //Зарплата

        private int numberofprojects; //Количество проектов
        #endregion

        #region Конструктор
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Department">Департамент</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="NumberOfProjects">Количество проектов</param>
        public Worker(string Name, string Surname, int Age, string Department, int Salary, int NumberOfProjects)
        {
            this.name = Name;
            this.surname = Surname;
            this.age = Age;
            this.department = Department;
            this.salary = Salary;
            this.numberofprojects = NumberOfProjects;
        }
        #endregion

        #region Метод
        /// <summary>
        /// Метод, печатающий поля структуры
        /// </summary>
        /// <returns>Поля</returns>
        public string Print()
        {
            return String.Format("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}",
                name,
                surname,
                age,
                department,
                age,
                numberofprojects);
        }
        #endregion

        #region Свойства
        [JsonProperty("Name")]
        public string Name { get { return this.name; } set { this.name = value; } }             //Свойство Имя
        [JsonProperty("Surname")]
        public string Surname { get { return this.surname; } set { this.surname = value; } }    //Свойство Фамилия
        [JsonProperty("Age")]
        public int Age { get { return this.age; } set { this.age = value; } }                   //Свойство Возраст
        [JsonProperty("Department")]
        public string Department { get { return this.department; } set { this.department = value; } } //Свойство Департамент
        [JsonProperty("Salary")]
        public int Salary { get { return this.salary; } set { this.salary = value; } }                  //Свойство Зарплата
        [JsonProperty("NumberOfProjects")]
        public int NumberOfProjects { get{ return this.numberofprojects; } set { this.numberofprojects = value; } } //Свойство Количество проектов
        #endregion
    }
}
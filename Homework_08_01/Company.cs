using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_08_01
{
    class Company
    {
        #region Поля
        private string title;

        private DateTime dateofcreation;

        private Department department;
        #endregion

        #region Конструктор
        /// <summary>
        /// Конструктор Компания
        /// </summary>
        /// <param name="Title">Название Компании</param>
        public Company(string Title)
        {
            this.title = Title;
            this.dateofcreation = DateTime.Now;
            this.department = new Department(Title);
        }
        #endregion

        #region Свойства
        public string Title { get { return this.title; } set { this.title = value; } }                      //Свойство "Название"
        public DateTime DateOfCreation { get { return this.dateofcreation; } private set { this.dateofcreation = value; } } //Свойство "Дата создания"
        public Department Department { get { return this.department; } set { this.department = value; } }   //Свойство "Департамент"
        #endregion
    }
}

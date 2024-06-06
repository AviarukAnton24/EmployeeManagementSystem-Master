using Cataloguer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();

            DisplayTotalEmployees();

            DisplayActiveEmployees();

            DisplayInactiveEmployees();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(RefreshData));

                return;
            }

            DisplayTotalEmployees();

            DisplayActiveEmployees();

            DisplayInactiveEmployees();
        }

        private void DisplayTotalEmployees()
        {
            // Создаем новый экземпляр подключения к базе данных
            DataBase database = new DataBase();

            // Открываем подключение к базе данных
            database.OpenConnection();

            // Создаем SQL-запрос для подсчета количества строк в таблице employees
            string countData = "SELECT COUNT(*) FROM employees";

            // Создаем команду SQL
            using (MySqlCommand command = new MySqlCommand(countData, database.GetConnection()))
            {
                // Используем ExecuteScalar, чтобы получить количество строк в таблице
                int totalCount = Convert.ToInt32(command.ExecuteScalar());

                // Записываем полученное значение в переменную DashBoard_TotalEmployeres.Text
                DashBoard_TotalEmployees.Text = totalCount.ToString();
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();

        }

        private void DisplayActiveEmployees()
        {
            // Создаем новый экземпляр подключения к базе данных
            DataBase database = new DataBase();

            // Открываем подключение к базе данных
            database.OpenConnection();

            // Создаем SQL-запрос для подсчета количества активных сотрудников в таблице employees
            string countData = "SELECT COUNT(*) FROM employees WHERE Status = 'Active'";

            // Создаем команду SQL
            using (MySqlCommand command = new MySqlCommand(countData, database.GetConnection()))
            {
                // Используем ExecuteScalar, чтобы получить количество активных сотрудников
                int activeCount = Convert.ToInt32(command.ExecuteScalar());

                // Записываем полученное значение в переменную DashBoard_ActiveEmployees.Text
                DashBoard_ActiveEmployees.Text = activeCount.ToString();
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();
        }

        private void DisplayInactiveEmployees()
        {
            // Создаем новый экземпляр подключения к базе данных
            DataBase database = new DataBase();

            // Открываем подключение к базе данных
            database.OpenConnection();

            // Создаем SQL-запрос для подсчета количества неактивных сотрудников в таблице employees
            string countData = "SELECT COUNT(*) FROM employees WHERE Status = 'Inactive'";

            // Создаем команду SQL
            using (MySqlCommand command = new MySqlCommand(countData, database.GetConnection()))
            {
                // Используем ExecuteScalar, чтобы получить количество неактивных сотрудников
                int inactiveCount = Convert.ToInt32(command.ExecuteScalar());

                // Записываем полученное значение в переменную DashBoard_InactiveEmployees.Text
                DashBoard_InactiveEmployees.Text = inactiveCount.ToString();
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();
        }
    }
}

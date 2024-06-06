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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            // Получение значений из полей ввода
            string username = login_username.Text;
            string password = login_password.Text;

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }

            // Создаем новый экземпляр подключения к базе данных
            DataBase database = new DataBase();

            // Открываем подключение к базе данных
            database.OpenConnection();

            try
            {
                // Создание SQL-запроса для поиска соответствующей строки в таблице accounts
                string query = "SELECT COUNT(*) FROM accounts WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(query, database.GetConnection());
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Авторизация успешно завершена");
                    
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Аккаунт не найден");
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибки при выполнении запроса
                MessageBox.Show("Ошибка при авторизации: " + ex.Message);
            }
            finally
            {
                // Закрываем подключение к базе данных
                database.CloseConnection();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cataloguer;
using MySql.Data.MySqlClient;

namespace EmployeeManagementSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signup_loginBtn_Click(object sender, EventArgs e)
        {
            Form1 loginform = new Form1();
            loginform.Show();
            this.Hide();
        }

        private void signup_showPass_CheckedChanged(object sender, EventArgs e)
        {
            signup_password.PasswordChar = signup_showPass.Checked ? '\0' : '*';
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            // Получение значений из полей ввода
            string username = signup_username.Text;
            string password = signup_password.Text;

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }

            // Проверка поля username на наличие только английских символов
            if (!Regex.IsMatch(username, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Поле 'Имя пользователя' должно содержать только английские символы");
                return;
            }

            // Проверка поля password на наличие только цифр
            if (!Regex.IsMatch(password, @"^\d+$"))
            {
                MessageBox.Show("Поле 'Пароль' должно содержать только цифры");
                return;
            }

            // Создаем новый экземпляр подключения к базе данных
            DataBase database = new DataBase();

            // Открываем подключение к базе данных
            database.OpenConnection();

            DateTime today = DateTime.Today;

            try
            {
                // Проверка наличия уже занятых логинов и паролей в базе данных
                string checkQuery = "SELECT COUNT(*) FROM accounts WHERE username = @username OR password = @password";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, database.GetConnection());
                checkCommand.Parameters.AddWithValue("@username", username);
                checkCommand.Parameters.AddWithValue("@password", password);
                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Указанный логин или пароль уже заняты");
                    return;
                }

                // Создание SQL-запроса для добавления записи в таблицу accounts
                string query = "INSERT INTO accounts (username, password, data) VALUES (@username, @password, @dataReg)";

                // Создание и выполнение команды для добавления записи
                MySqlCommand command = new MySqlCommand(query, database.GetConnection());
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@dataReg", today);

                command.ExecuteNonQuery();

                MessageBox.Show("Регистрация успешно завершена");
            }
            catch (Exception ex)
            {
                // Обработка ошибки при выполнении запроса
                MessageBox.Show("Ошибка при регистрации: " + ex.Message);
            }
            finally
            {
                // Закрываем подключение к базе данных
                database.CloseConnection();
            }
        }
    }
}

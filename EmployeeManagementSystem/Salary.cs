using Cataloguer;
using MySql.Data.MySqlClient;
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

namespace EmployeeManagementSystem
{
    public partial class Salary : UserControl
    {
        public Salary()
        {
            InitializeComponent();
            DisplayEmployeeData();

            DisplayFields();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(RefreshData));

                return;
            }

            DisplayEmployeeData();

            DisplayFields();
        }

        private void DisplayFields()
        {
            Salary_ID.Enabled = false;
            Salary_FullName.Enabled = false;
            Salary_Position.Enabled = false;
        }

        public void DisplayEmployeeData()
        {
            // Создаем новый экземпляр подключения к базе данных
            DataBase database = new DataBase();

            // Открываем подключение к базе данных
            database.OpenConnection();

            // Создаем SQL-запрос для выборки данных из таблицы
            string query = "SELECT * FROM employees";

            // Создаем команду SQL
            using (MySqlCommand command = new MySqlCommand(query, database.GetConnection()))
            {
                // Создаем объект MySqlDataReader для чтения данных
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Очищаем существующие столбцы в DataGridView
                    dataGridView2.Columns.Clear();

                    // Добавляем столбцы в DataGridView с использованием имен полей из таблицы
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataGridView2.Columns.Add(reader.GetName(i), reader.GetName(i));
                    }

                    // Изменяем стиль ячеек в DataGridView
                    dataGridView2.DefaultCellStyle.BackColor = Color.LightBlue; // Голубой цвет фона
                    dataGridView2.DefaultCellStyle.ForeColor = Color.Black; // Черный цвет текста
                    dataGridView2.DefaultCellStyle.Font = new Font("Times New Roman", 15, FontStyle.Bold); // Шрифт Times New Roman, размер 15, жирный стиль

                    // Изменяем стиль названий столбцов в DataGridView
                    foreach (DataGridViewColumn column in dataGridView2.Columns)
                    {
                        column.HeaderCell.Style.BackColor = Color.LightBlue; // Голубой цвет фона названия столбца
                        column.HeaderCell.Style.ForeColor = Color.Black; // Черный цвет текста названия столбца
                        column.HeaderCell.Style.Font = new Font("Times New Roman", 15, FontStyle.Bold); // Шрифт Times New Roman, размер 15, жирный стиль
                    }

                    // Читаем данные и добавляем их в DataGridView
                    while (reader.Read())
                    {
                        // Создаем массив объектов для хранения значений полей в текущей строке
                        object[] values = new object[reader.FieldCount];

                        // Заполняем массив значениями полей в текущей строке
                        reader.GetValues(values);

                        // Добавляем массив значений как новую строку в DataGridView
                        dataGridView2.Rows.Add(values);
                    }
                }
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
                DataGridViewCell selectedCell = selectedRow.Cells[e.ColumnIndex];

                if (dataGridView2.Columns[e.ColumnIndex].Name == "Employee_ID")
                {
                    Salary_ID.Text = selectedCell.Value.ToString(); // Заполнение поля Salary_ID
                }
                else if (dataGridView2.Columns[e.ColumnIndex].Name == "Full_Name")
                {
                    Salary_ID.Text = selectedRow.Cells["Employee_ID"].Value.ToString(); // Заполнение поля Salary_ID
                    Salary_FullName.Text = selectedCell.Value.ToString(); // Заполнение поля Salary_FullName
                    Salary_Position.Text = selectedRow.Cells["Position"].Value.ToString(); // Заполнение поля Salary_Position
                    Salary_Salary.Text = selectedRow.Cells["Salary"].Value.ToString(); // Заполнение поля Salary_Salary
                }
                else if (dataGridView2.Columns[e.ColumnIndex].Name == "Position")
                {
                    Salary_Position.Text = selectedCell.Value.ToString(); // Заполнение поля Salary_Position
                }
                else if (dataGridView2.Columns[e.ColumnIndex].Name == "Salary")
                {
                    Salary_Salary.Text = selectedCell.Value.ToString(); // Заполнение поля Salary_Salary
                }
            }
        }

        private void Salary_UpdateButton_Click(object sender, EventArgs e)
        {
            // Проверка, что все поля заполнены
            if (string.IsNullOrEmpty(Salary_ID.Text) || string.IsNullOrEmpty(Salary_FullName.Text) ||
                string.IsNullOrEmpty(Salary_Position.Text) || string.IsNullOrEmpty(Salary_Salary.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле Salary_ID содержит только цифры
            if (!Regex.IsMatch(Salary_ID.Text, @"^\d+$"))
            {
                MessageBox.Show("Поле Salary_ID должно содержать только цифры",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле Salary_FullName содержит только английские символы
            if (!Regex.IsMatch(Salary_FullName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Поле Salary_FullName должно содержать только английские символы",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Salary содержит только слова из списка
            List<string> validPositions = new List<string> {
                "Front-End Developer",
                "Back-End Developer",
                "Data Administrator",
                "UI/X Design",
                "Mobile Developer",
                "System Developer",
                "Game Developer"
            };

            if (!validPositions.Contains(Salary_Position.Text))
            {
                MessageBox.Show("Поле Salary_Position должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле Salary_Salary содержит только цифры
            if (!Regex.IsMatch(Salary_Salary.Text, @"^\d+$"))
            {
                MessageBox.Show("Поле Salary_Salary должно содержать только цифры",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Создаем новый экземпляр подключения к базе данных
            DataBase database = new DataBase();

            // Открываем подключение к базе данных
            database.OpenConnection();

            // Создаем SQL-запрос для проверки наличия строк в таблице
            string checkData = "SELECT COUNT(*) FROM employees";

            // Создаем команду SQL
            using (MySqlCommand checkCommand = new MySqlCommand(checkData, database.GetConnection()))
            {
                int rowCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                // Проверяем, что таблица не является пустой
                if (rowCount == 0)
                {
                    MessageBox.Show("Таблица пуста. Нет работников для изменения",
                        "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка наличия строки с указанными значениями Employee_ID, FullName и Position
                string selectData = "SELECT COUNT(*) FROM employees WHERE Employee_ID = @employeeID " +
                "AND Full_Name = @fullname AND Position = @position";

                using (MySqlCommand selectCommand = new MySqlCommand(selectData, database.GetConnection()))
                {
                    selectCommand.Parameters.AddWithValue("@employeeID", Salary_ID.Text.Trim());
                    selectCommand.Parameters.AddWithValue("@fullname", Salary_FullName.Text.Trim());
                    selectCommand.Parameters.AddWithValue("@position", Salary_Position.Text.Trim());

                    int rowQuantity = Convert.ToInt32(selectCommand.ExecuteScalar());

                    if (rowQuantity == 0)
                    {
                        MessageBox.Show("Работник не найден с указанными Employee_ID, Full_Name и Position",
                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Обновление строки в базе данных
                string updateData = "UPDATE employees SET Salary = @salary WHERE " +
                    "Employee_ID = @employeeID AND Full_Name = @fullname AND Position = @position";

                using (MySqlCommand updateCommand = new MySqlCommand(updateData, database.GetConnection()))
                {
                    updateCommand.Parameters.AddWithValue("@salary", Salary_Salary.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@employeeID", Salary_ID.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@fullname", Salary_FullName.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@position", Salary_Position.Text.Trim());

                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Информация о зарплате работнике успешно обновлена", "Information Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayEmployeeData();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить информацию о зарплате работника",
                                        "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();
        }

        private void Salary_ClearButton_Click(object sender, EventArgs e)
        {
            // Создаем новый экземпляр подключения к базе данных
            DataBase database = new DataBase();

            // Открываем подключение к базе данных
            database.OpenConnection();

            // Создаем SQL-запрос для проверки наличия строк в таблице
            string checkData = "SELECT COUNT(*) FROM employees";

            // Создаем команду SQL
            using (MySqlCommand checkCommand = new MySqlCommand(checkData, database.GetConnection()))
            {
                int rowCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                // Проверяем, что таблица не является пустой
                if (rowCount == 0)
                {
                    MessageBox.Show("Таблица уже пуста",
                        "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Создаем SQL-запрос для очистки таблицы employees
                string clearData = "TRUNCATE TABLE employees";

                // Создаем команду SQL
                using (MySqlCommand command = new MySqlCommand(clearData, database.GetConnection()))
                {
                    command.ExecuteNonQuery();

                    // Очищаем поля формы
                    Salary_ID.Text = string.Empty;
                    Salary_FullName.Text = string.Empty;
                    Salary_Position.Text = string.Empty;
                    Salary_Salary.Text = string.Empty;

                    // Обновляем отображаемые данные
                    DisplayEmployeeData();

                    MessageBox.Show("Данные успешно очищены", "Information Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();
        }
    }
}

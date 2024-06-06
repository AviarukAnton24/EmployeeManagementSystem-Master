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
    public partial class EmployeeInfo : UserControl
    {
        public EmployeeInfo()
        {
            InitializeComponent();

            DisplayEmployeeData();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(RefreshData));

                return;
            }

            DisplayEmployeeData();
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
                    dataGridView1.Columns.Clear();

                    // Добавляем столбцы в DataGridView с использованием имен полей из таблицы
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
                    }

                    // Изменяем стиль ячеек в DataGridView
                    dataGridView1.DefaultCellStyle.BackColor = Color.LightBlue; // Голубой цвет фона
                    dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Черный цвет текста
                    dataGridView1.DefaultCellStyle.Font = new Font("Times New Roman", 15, FontStyle.Bold); // Шрифт Times New Roman, размер 15, жирный стиль

                    // Изменяем стиль названий столбцов в DataGridView
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
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
                        dataGridView1.Rows.Add(values);
                    }
                }
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                DataGridViewCell selectedCell = selectedRow.Cells[e.ColumnIndex];

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Employee_ID")
                {
                    AddEmployee_ID.Text = selectedCell.Value.ToString(); // Заполнение поля AddEmployee_ID
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Full_Name")
                {
                    AddEmployee_ID.Text = selectedRow.Cells["Employee_ID"].Value.ToString(); // Заполнение поля AddEmployee_ID
                    AddEmployee_FullName.Text = selectedCell.Value.ToString(); // Заполнение поля AddEmployee_FullName
                    AddEmployee_Gender.Text = selectedRow.Cells["Gender"].Value.ToString(); // Заполнение поля AddEmployee_Gender
                    AddEmployee_PhoneNumber.Text = selectedRow.Cells["Contact"].Value.ToString(); // Заполнение поля AddEmployee_PhoneNumber
                    AddEmployee_Position.Text = selectedRow.Cells["Position"].Value.ToString(); // Заполнение поля AddEmployee_Position
                    AddEmployee_Status.Text = selectedRow.Cells["Status"].Value.ToString(); // Заполнение поля AddEmployee_Status
                    AddEmployee_Country.Text = selectedRow.Cells["Country"].Value.ToString(); // Заполнение поля AddEmployee_Country
                    AddEmployee_Age.Text = selectedRow.Cells["Age"].Value.ToString(); // Заполнение поля AddEmployee_Age
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Gender")
                {
                    AddEmployee_Gender.Text = selectedCell.Value.ToString(); // Заполнение поля AddEmployee_Gender
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Contact")
                {
                    AddEmployee_PhoneNumber.Text = selectedCell.Value.ToString(); // Заполнение поля AddEmployee_PhoneNumber
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Position")
                {
                    AddEmployee_Position.Text = selectedCell.Value.ToString(); // Заполнение поля AddEmployee_Position
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Status")
                {
                    AddEmployee_Status.Text = selectedCell.Value.ToString(); // Заполнение поля AddEmployee_Status
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Country")
                {
                    AddEmployee_Country.Text = selectedCell.Value.ToString(); // Заполнение поля AddEmployee_Country
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Age")
                {
                    AddEmployee_Age.Text = selectedCell.Value.ToString(); // Заполнение поля AddEmployee_Age
                }
            }
        }

        private void AddEmployee_AddButton_Click(object sender, EventArgs e)
        {
            // Проверка, что все поля заполнены
            if (string.IsNullOrEmpty(AddEmployee_ID.Text) || string.IsNullOrEmpty(AddEmployee_FullName.Text) ||
                string.IsNullOrEmpty(AddEmployee_Gender.Text) || string.IsNullOrEmpty(AddEmployee_PhoneNumber.Text) ||
                string.IsNullOrEmpty(AddEmployee_Position.Text) || string.IsNullOrEmpty(AddEmployee_Status.Text) ||
                string.IsNullOrEmpty(AddEmployee_Country.Text) || string.IsNullOrEmpty(AddEmployee_Age.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_ID содержит только цифры
            if (!Regex.IsMatch(AddEmployee_ID.Text, @"^\d+$"))
            {
                MessageBox.Show("Поле AddEmployee_ID должно содержать только цифры",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_FullName содержит только английские символы
            if (!Regex.IsMatch(AddEmployee_FullName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_FullName должно содержать только английские символы",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Gender содержит только слова из списка
            List<string> validGender = new List<string> {
                "Male",
                "Female",
                "Other"
            };

            if (!validGender.Contains(AddEmployee_Gender.Text))
            {
                MessageBox.Show("Поле AddEmployee_Gender должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_PhoneNumber содержит только цифры с символом '+' или пробелом
            if (!Regex.IsMatch(AddEmployee_PhoneNumber.Text, @"^[\d+\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_PhoneNumber должно содержать только цифры с символом '+' или пробелом",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Position содержит только слова из списка
            List<string> validPositions = new List<string> {
                "Front-End Developer",
                "Back-End Developer",
                "Data Administrator",
                "UI/X Design",
                "Mobile Developer",
                "System Developer",
                "Game Developer"
            };

            if (!validPositions.Contains(AddEmployee_Position.Text))
            {
                MessageBox.Show("Поле AddEmployee_Position должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Status содержит только слова из списка
            List<string> validStatus = new List<string> {
                "Active",
                "Inactive"
            };

            if (!validStatus.Contains(AddEmployee_Status.Text))
            {
                MessageBox.Show("Поле AddEmployee_Status должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Country содержит только английские символы
            if (!Regex.IsMatch(AddEmployee_Country.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_Country должно содержать только английские символы",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Age содержит только цифры от 0 до 100
            if (!Regex.IsMatch(AddEmployee_Age.Text, @"^[0-9\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_Age должно содержать только цифры и пробелы",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Создаем новый экземпляр подключения к базе данных
            DataBase database = new DataBase();

            // Открываем подключение к базе данных
            database.OpenConnection();

            // Создаем SQL-запрос для проверки, существует ли работник с указанным ID
            string checkEmployeeID = "SELECT COUNT(*) FROM employees WHERE Employee_ID = @employeeID";

            // Создаем команду SQL
            using (MySqlCommand checkEmployee = new MySqlCommand(checkEmployeeID, database.GetConnection()))
            {
                checkEmployee.Parameters.AddWithValue("@employeeID", AddEmployee_ID.Text.Trim());
                int count = Convert.ToInt32(checkEmployee.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Номер "+AddEmployee_ID.Text.Trim() + " уже занят",
                        "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Создаем SQL-запрос для проверки наличия существующей строки
            string checkExistingData = "SELECT COUNT(*) FROM employees WHERE Full_Name = @fullname " +
                "AND Gender = @gender AND Contact = @contact AND Position = @position AND Status = @status " +
                "AND Country = @country AND Age = @age";

            // Создаем команду SQL
            using (MySqlCommand checkData = new MySqlCommand(checkExistingData, database.GetConnection()))
            {
                checkData.Parameters.AddWithValue("@fullname", AddEmployee_FullName.Text.Trim());
                checkData.Parameters.AddWithValue("@gender", AddEmployee_Gender.Text.Trim());
                checkData.Parameters.AddWithValue("@contact", AddEmployee_PhoneNumber.Text.Trim());
                checkData.Parameters.AddWithValue("@position", AddEmployee_Position.Text.Trim());
                checkData.Parameters.AddWithValue("@status", AddEmployee_Status.Text.Trim());
                checkData.Parameters.AddWithValue("@country", AddEmployee_Country.Text.Trim());
                checkData.Parameters.AddWithValue("@age", AddEmployee_Age.Text.Trim());

                int count = Convert.ToInt32(checkData.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Такая запись уже существует",
                        "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Создаем SQL-запрос для вставки данных в таблицу
            string insertData = "INSERT INTO employees (Employee_ID,Full_Name,Gender,Contact," +
                "Position,Status,Country,Age,Salary) " +
                "VALUES(@employeeID,@fullname,@gender,@contact,@position,@status,@country,@age,@salary)";

            // Создаем команду SQL
            using (MySqlCommand command = new MySqlCommand(insertData, database.GetConnection()))
            {
                command.Parameters.AddWithValue("@employeeID", AddEmployee_ID.Text.Trim());
                command.Parameters.AddWithValue("@fullname", AddEmployee_FullName.Text.Trim());
                command.Parameters.AddWithValue("@gender", AddEmployee_Gender.Text.Trim());
                command.Parameters.AddWithValue("@contact", AddEmployee_PhoneNumber.Text.Trim());
                command.Parameters.AddWithValue("@position", AddEmployee_Position.Text.Trim());
                command.Parameters.AddWithValue("@status", AddEmployee_Status.Text.Trim());
                command.Parameters.AddWithValue("@country", AddEmployee_Country.Text.Trim());
                command.Parameters.AddWithValue("@age", AddEmployee_Age.Text.Trim());
                command.Parameters.AddWithValue("@salary", 0);

                command.ExecuteNonQuery();

                DisplayEmployeeData();

                MessageBox.Show("Работник успешно добавлен", "Information Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();
        }

        private void AddEmployee_UpdateButton_Click(object sender, EventArgs e)
        {
            // Проверка, что все поля заполнены
            if (string.IsNullOrEmpty(AddEmployee_ID.Text) || string.IsNullOrEmpty(AddEmployee_FullName.Text) ||
                string.IsNullOrEmpty(AddEmployee_Gender.Text) || string.IsNullOrEmpty(AddEmployee_PhoneNumber.Text) ||
                string.IsNullOrEmpty(AddEmployee_Position.Text) || string.IsNullOrEmpty(AddEmployee_Status.Text) ||
                string.IsNullOrEmpty(AddEmployee_Country.Text) || string.IsNullOrEmpty(AddEmployee_Age.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_ID содержит только цифры
            if (!Regex.IsMatch(AddEmployee_ID.Text, @"^\d+$"))
            {
                MessageBox.Show("Поле AddEmployee_ID должно содержать только цифры",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_FullName содержит только английские символы
            if (!Regex.IsMatch(AddEmployee_FullName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_FullName должно содержать только английские символы",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Gender содержит только слова из списка
            List<string> validGender = new List<string> {
                "Male",
                "Female",
                "Other"
            };

            if (!validGender.Contains(AddEmployee_Gender.Text))
            {
                MessageBox.Show("Поле AddEmployee_Gender должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_PhoneNumber содержит только цифры с символом '+' или пробелом
            if (!Regex.IsMatch(AddEmployee_PhoneNumber.Text, @"^[\d+\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_PhoneNumber должно содержать только цифры с символом '+' или пробелом",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Position содержит только слова из списка
            List<string> validPositions = new List<string> {
                "Front-End Developer",
                "Back-End Developer",
                "Data Administrator",
                "UI/X Design",
                "Mobile Developer",
                "System Developer",
                "Game Developer"
            };

            if (!validPositions.Contains(AddEmployee_Position.Text))
            {
                MessageBox.Show("Поле AddEmployee_Position должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Status содержит только слова из списка
            List<string> validStatus = new List<string> {
                "Active",
                "Inactive"
            };

            if (!validStatus.Contains(AddEmployee_Status.Text))
            {
                MessageBox.Show("Поле AddEmployee_Status должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Country содержит только английские символы
            if (!Regex.IsMatch(AddEmployee_Country.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_Country должно содержать только английские символы",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Age содержит только цифры от 0 до 100
            if (!Regex.IsMatch(AddEmployee_Age.Text, @"^[0-9\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_Age должно содержать только цифры и пробелы",
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

                // Создаем SQL-запрос для обновления данных в таблице
                string updateData = "UPDATE employees SET Full_Name = @fullname, Gender = @gender, " +
                "Contact = @contact, Position = @position, Status = @status, Country = @country, Age = @age " +
                "WHERE Employee_ID = @employeeID";

                // Создаем команду SQL
                using (MySqlCommand command = new MySqlCommand(updateData, database.GetConnection()))
                {
                    command.Parameters.AddWithValue("@fullname", AddEmployee_FullName.Text.Trim());
                    command.Parameters.AddWithValue("@gender", AddEmployee_Gender.Text.Trim());
                    command.Parameters.AddWithValue("@contact", AddEmployee_PhoneNumber.Text.Trim());
                    command.Parameters.AddWithValue("@position", AddEmployee_Position.Text.Trim());
                    command.Parameters.AddWithValue("@status", AddEmployee_Status.Text.Trim());
                    command.Parameters.AddWithValue("@country", AddEmployee_Country.Text.Trim());
                    command.Parameters.AddWithValue("@age", AddEmployee_Age.Text.Trim());
                    command.Parameters.AddWithValue("@employeeID", AddEmployee_ID.Text.Trim());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        DisplayEmployeeData();

                        MessageBox.Show("Информация о работнике успешно обновлена", "Information Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Нет совпадения с указанным Employee_ID",
                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();
        }

        private void AddEmployee_DeleteButton_Click(object sender, EventArgs e)
        {
            // Проверка, что все поля заполнены
            if (string.IsNullOrEmpty(AddEmployee_ID.Text) || string.IsNullOrEmpty(AddEmployee_FullName.Text) ||
                string.IsNullOrEmpty(AddEmployee_Gender.Text) || string.IsNullOrEmpty(AddEmployee_PhoneNumber.Text) ||
                string.IsNullOrEmpty(AddEmployee_Position.Text) || string.IsNullOrEmpty(AddEmployee_Status.Text) ||
                string.IsNullOrEmpty(AddEmployee_Country.Text) || string.IsNullOrEmpty(AddEmployee_Age.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_ID содержит только цифры
            if (!Regex.IsMatch(AddEmployee_ID.Text, @"^\d+$"))
            {
                MessageBox.Show("Поле AddEmployee_ID должно содержать только цифры",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_FullName содержит только английские символы
            if (!Regex.IsMatch(AddEmployee_FullName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_FullName должно содержать только английские символы",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Gender содержит только слова из списка
            List<string> validGender = new List<string> {
                "Male",
                "Female",
                "Other"
            };

            if (!validGender.Contains(AddEmployee_Gender.Text))
            {
                MessageBox.Show("Поле AddEmployee_Gender должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_PhoneNumber содержит только цифры с символом '+' или пробелом
            if (!Regex.IsMatch(AddEmployee_PhoneNumber.Text, @"^[\d+\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_PhoneNumber должно содержать только цифры с символом '+' или пробелом",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Position содержит только слова из списка
            List<string> validPositions = new List<string> {
                "Front-End Developer",
                "Back-End Developer",
                "Data Administrator",
                "UI/X Design",
                "Mobile Developer",
                "System Developer",
                "Game Developer"
            };

            if (!validPositions.Contains(AddEmployee_Position.Text))
            {
                MessageBox.Show("Поле AddEmployee_Position должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Status содержит только слова из списка
            List<string> validStatus = new List<string> {
                "Active",
                "Inactive"
            };

            if (!validStatus.Contains(AddEmployee_Status.Text))
            {
                MessageBox.Show("Поле AddEmployee_Status должно содержать только одно из допустимых значений",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Country содержит только английские символы
            if (!Regex.IsMatch(AddEmployee_Country.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_Country должно содержать только английские символы",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка, что поле AddEmployee_Age содержит только цифры от 0 до 100
            if (!Regex.IsMatch(AddEmployee_Age.Text, @"^[0-9\s]+$"))
            {
                MessageBox.Show("Поле AddEmployee_Age должно содержать только цифры и пробелы",
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
                    MessageBox.Show("Таблица пуста. Нет работников для удаления",
                        "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Создаем SQL-запрос для удаления строки из таблицы
                string deleteData = "DELETE FROM employees WHERE Employee_ID = @employeeID " +
                    "AND Full_Name = @fullname AND Gender = @gender AND Contact = @contact " +
                    "AND Position = @position AND Status = @status AND Country = @country " +
                    "AND Age = @age";

                // Создаем команду SQL
                using (MySqlCommand command = new MySqlCommand(deleteData, database.GetConnection()))
                {
                    command.Parameters.AddWithValue("@employeeID", AddEmployee_ID.Text.Trim());
                    command.Parameters.AddWithValue("@fullname", AddEmployee_FullName.Text.Trim());
                    command.Parameters.AddWithValue("@gender", AddEmployee_Gender.Text.Trim());
                    command.Parameters.AddWithValue("@contact", AddEmployee_PhoneNumber.Text.Trim());
                    command.Parameters.AddWithValue("@position", AddEmployee_Position.Text.Trim());
                    command.Parameters.AddWithValue("@status", AddEmployee_Status.Text.Trim());
                    command.Parameters.AddWithValue("@country", AddEmployee_Country.Text.Trim());
                    command.Parameters.AddWithValue("@age", AddEmployee_Age.Text.Trim());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        DisplayEmployeeData();

                        MessageBox.Show("Работник успешно удален", "Information Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Работник не найден или Employee_ID не соответствует введенному значению",
                            "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            // Закрываем подключение к базе данных
            database.CloseConnection();
        }

        private void AddEmployee_ClearButton_Click(object sender, EventArgs e)
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
                    AddEmployee_ID.Text = string.Empty;
                    AddEmployee_FullName.Text = string.Empty;
                    AddEmployee_Gender.Text = string.Empty;
                    AddEmployee_PhoneNumber.Text = string.Empty;
                    AddEmployee_Position.Text = string.Empty;
                    AddEmployee_Status.Text = string.Empty;
                    AddEmployee_Country.Text = string.Empty;
                    AddEmployee_Age.Text = string.Empty;

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

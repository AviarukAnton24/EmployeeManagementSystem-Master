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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(RefreshData));

                return;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Вы уверены, что хотите выйти из системы?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (check == DialogResult.Yes)
            {
                Form1 loginfirm = new Form1();
                loginfirm.Show();
                this.Hide();
            }
        }

        private void dashboard_btn_Click(Object sender, EventArgs e)
        {
            dashBoard1.Visible = true;
            employeeInfo1.Visible = false;
            salary1.Visible = false;

            DashBoard dashBoardForm = dashBoard1 as DashBoard;

            if (dashBoardForm != null)
            {
                dashBoardForm.RefreshData();
            }
        }

        private void AddEmployee_btn_Click(object sender, EventArgs e)
        {
            dashBoard1.Visible = false;
            employeeInfo1.Visible = true;
            salary1.Visible = false;

            EmployeeInfo employeeInfoForm = employeeInfo1 as EmployeeInfo;

            if (employeeInfo1 != null)
            {
                employeeInfo1.RefreshData();
            }
        }

        private void salary_btn_Click(object sender, EventArgs e)
        {
            dashBoard1.Visible = false;
            employeeInfo1.Visible = false;
            salary1.Visible = true;

            Salary salaryForm = salary1 as Salary;

            if (salary1 != null)
            {
                salary1.RefreshData();
            }
        }
    }
}

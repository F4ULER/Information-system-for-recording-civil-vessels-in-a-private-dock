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

namespace ISS
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();

            textBoxLog.Text = "Введите логин";
            textBoxLog.ForeColor = Color.Gray;

            textBoxPass.Text = "Введите пароль";
            textBoxPass.ForeColor = Color.Gray;
            textBoxPass.PasswordChar = (char)0;

            textBoxName.Text = "Введите ФИО";
            textBoxName.ForeColor = Color.Gray;

            textBoxPhone.Text = "Введите номер телефона";
            textBoxPhone.ForeColor = Color.Gray;

            textBoxEmail.Text = "Введите электоронную почту";
            textBoxEmail.ForeColor = Color.Gray;
        }

        private void textBoxLog_Enter(object sender, EventArgs e)
        {
            if (textBoxLog.Text == "Введите логин")
            {
                textBoxLog.Text = "";
                textBoxLog.ForeColor = Color.Black;
            }
        }

        private void textBoxLog_Leave(object sender, EventArgs e)
        {
            if (textBoxLog.Text == "")
            {
                textBoxLog.Text = "Введите логин";
                textBoxLog.ForeColor = Color.Gray;
            }
        }

        private void textBoxPass_Enter(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "Введите пароль")
            {
                textBoxPass.Text = "";
                textBoxPass.ForeColor = Color.Black;
                textBoxPass.PasswordChar = '*';
            }
        }

        private void textBoxPass_Leave(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "")
            {
                textBoxPass.Text = "Введите пароль";
                textBoxPass.ForeColor = Color.Gray;
                textBoxPass.PasswordChar = (char)0;
            }
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Введите ФИО")
            {
                textBoxName.Text = "";
                textBoxName.ForeColor = Color.Black;
            }
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                textBoxName.Text = "Введите ФИО";
                textBoxName.ForeColor = Color.Gray;
            }
        }

        private void textBoxPhone_Enter(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "Введите номер телефона")
            {
                textBoxPhone.Text = "";
                textBoxPhone.ForeColor = Color.Black;
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "")
            {
                textBoxPhone.Text = "Введите номер телефона";
                textBoxPhone.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Введите электоронную почту")
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                textBoxEmail.Text = "Введите электоронную почту";
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        private void reg_button_enter_Click(object sender, EventArgs e)
        {
            string logUser = textBoxLog.Text;
            string passUser = textBoxPass.Text;
            string nameUser = textBoxName.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string tableName = "users";

            if(logUser == "Введите логин" || passUser == "Введите пароль" || nameUser == "Введите ФИО" 
                || phone == "Введите номер телефона" || email == "Введите электоронную почту")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (checkLoggin())
            {
                return;
            }

            DataBase DB_UP = new DataBase();
            DataTable table = new DataTable();

            if (DB_UP.AddNote(logUser, passUser, nameUser, phone, email, tableName))
            {
                MessageBox.Show("Регистрация прошла успешно!");
                Authorization form = new Authorization();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }

        public Boolean checkLoggin()
        {
            DataBase DB_UP = new DataBase();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @Log", DB_UP.getConnection());
            command.Parameters.Add("@Log", MySqlDbType.VarChar).Value = textBoxLog.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Данный логин уже существует");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void pictureBackAuth_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization auth = new Authorization();
            auth.Show();
        }


    }
}

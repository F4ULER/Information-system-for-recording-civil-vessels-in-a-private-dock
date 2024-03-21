using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ISS
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();

            textBoxUser.Text = "Введите логин";
            textBoxUser.ForeColor = Color.Gray;

            textBoxPass.Text = "Введите пароль";
            textBoxPass.ForeColor = Color.Gray;
            textBoxPass.PasswordChar = (char)0;
        }

        private void picturePassOff_Click(object sender, EventArgs e)
        {
            picturePassOn.Visible = true;
            picturePassOff.Visible = false;
            textBoxPass.PasswordChar = '*';
        }

        private void picturePassOn_Click(object sender, EventArgs e)
        {
            if (textBoxPass.Text != "Введите пароль")
            {
                picturePassOff.Visible = true;
                picturePassOn.Visible = false;
                textBoxPass.PasswordChar = (char)0;
            }
        }

        private void auth_button_enter_Click(object sender, EventArgs e)
        {
            string logUser = textBoxUser.Text;
            string passUser = textBoxPass.Text;

            DataBase DB_UP = new DataBase();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @Log AND `password` = @Pass", DB_UP.getConnection());
            command.Parameters.Add("@Log", MySqlDbType.VarChar).Value = logUser;
            command.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                Transfer.Welcome = logUser;
                MainForm form = new MainForm();
                form.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm reg = new RegistrationForm();
            reg.Show();
        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "Введите логин")
            {
                textBoxUser.Text = "";
                textBoxUser.ForeColor = Color.Black;
            }
        }

        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
            {
                textBoxUser.Text = "Введите логин";
                textBoxUser.ForeColor = Color.Gray;
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
    }
}

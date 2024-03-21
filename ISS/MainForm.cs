using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;


namespace ISS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            labelWelc.Text = "Добро пожаловать, " + Transfer.Welcome;
            if(Transfer.Welcome == "admin")
            {
                pictureBoxEdit.Visible = true;
            }
            else
            {
                pictureBoxEdit.Visible = false;
            }

            pictureBoxServices.Visible = true;

            textBoxSearch.Text = "Поиск судна";
            textBoxSearch.ForeColor = Color.Gray;

            mainTable.Visible = false;
            tabControl.Visible = false;
            tabServices.Visible = false;

            // заполнение полей для добавления записи
            textBoxNum.Text = "Введите номер судна";
            textBoxNum.MaxLength = 6;
            textBoxNum.ForeColor = Color.Gray;

            textBoxOwner.Text = "Введите логин владельца";
            textBoxOwner.ForeColor = Color.Gray;

            textBoxBrand.Text = "Введите марку судна";
            textBoxBrand.ForeColor = Color.Gray;

            textBoxStartDate.Text = "__.__.____";
            textBoxStartDate.MaxLength = 10;
            textBoxStartDate.ForeColor = Color.Gray;

            textBoxEndDate.Text = "__.__.____";
            textBoxEndDate.MaxLength = 10;
            textBoxEndDate.ForeColor = Color.Gray;

            // заполнение заявления на аренду
            textBoxNumRent.Text = "Введите номер судна";
            textBoxNumRent.MaxLength = 6;
            textBoxNumRent.ForeColor = Color.Gray;

            textBoxOwnerRent.Text = Transfer.Welcome;

            textBoxBrandRent.Text = "Введите марку судна";
            textBoxBrandRent.ForeColor = Color.Gray;

            textBoxStartDateRent.Text = "__.__.____";
            textBoxStartDateRent.MaxLength = 10;
            textBoxStartDateRent.ForeColor = Color.Gray;

            textBoxEndDateRent.Text = "__.__.____";
            textBoxEndDateRent.MaxLength = 10;
            textBoxEndDateRent.ForeColor = Color.Gray;

            
            tableDelete.Visible = false;
            labelCheckDel.Visible = false;
            buttonDelete.Visible = false;
            pictureBoxDel.Visible = false;

            cBAdditionalServices1.Visible = false;
            cBAdditionalServices2.Visible = false;
            pictureBoxPlusServise2.Visible = false;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureSearch_Click(object sender, EventArgs e)
        {
            string request = textBoxSearch.Text;

            DataBase DB = new DataBase();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //поиск по правам доступа
            if(Transfer.Welcome == "admin")
            {
                if (request == "Поиск судна" || request == "")
                {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `ships`", DB.getConnection());
                    adapter.SelectCommand = command;
                }
                else
                {
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `ships` WHERE `id`= @search OR `status`= @search " +
                        "OR `board number`= @search OR `owner`= @search OR `brand`= @search", DB.getConnection());
                    command.Parameters.Add("@search", MySqlDbType.VarChar).Value = request;
                    adapter.SelectCommand = command;
                }
             }
            else
            {
                //пользователь может использовать поиск только по параметру "номер судна"
                MySqlCommand command = new MySqlCommand("SELECT `board number`,`owner`,`brand`,`start date`,`end date`,`status` " +
                    "FROM `ships` WHERE `board number`= @search", DB.getConnection());
                command.Parameters.Add("@search", MySqlDbType.VarChar).Value = request;
                adapter.SelectCommand = command;
            }

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                mainTable.DataSource = table;
                mainTable.Visible = true;
            }
            else
            {
                if (Transfer.Welcome == "admin")
                {
                    MessageBox.Show("Ошибка! Такой записи не существует!");
                    mainTable.Visible = false;
                }
                else
                {
                    MessageBox.Show("Ошибка! Такой записи не существует или Вы не обладаете соответствующими правами доступа!");
                    mainTable.Visible = false;
                }
            }
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "Поиск судна")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.Black;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "")
            {
                textBoxSearch.Text = "Поиск судна";
                textBoxSearch.ForeColor = Color.Gray;
            }
        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            string numBoard = textBoxDelete.Text;

            if (numBoard == "")
            {
                MessageBox.Show("Введите номер судна!");
                return;
            }
            string com = "SELECT * FROM `ships` WHERE `board number`= @del";

            DataBase DB = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand(com, DB.getConnection());
            command.Parameters.Add("@del", MySqlDbType.VarChar).Value = numBoard;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                tableDelete.Visible = true;
                labelCheckDel.Visible = true;
                buttonDelete.Visible = true;
                pictureBoxDel.Visible = true;
                tableDelete.DataSource = table;
            } else
            {
                MessageBox.Show("Ошибка! Такой записи не существует!");
                textBoxDelete.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string num = textBoxNum.Text;
            string owner = textBoxOwner.Text;
            string brand = textBoxBrand.Text;
            string startDate = textBoxStartDate.Text;
            string endDate = textBoxEndDate.Text;

            if (num == "Введите номер судна" || owner == "Введите логин владельца" || brand == "Введите марку судна" || startDate == "__.__.____" || endDate == "__.__.____")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (checkNum(textBoxNum.Text))
            {
                return;
            }

            DataBase DB_UP = new DataBase();
            DataTable table = new DataTable();

            string tableName = "ships";
            if (DB_UP.AddNote("active", num, owner, brand, startDate, endDate, tableName))
            {
                MessageBox.Show("Запись успешно добалена!");
                textBoxNum.Text = "Введите номер судна";
                textBoxNum.ForeColor = Color.Gray;

                textBoxOwner.Text = "Введите логин владельца";
                textBoxOwner.ForeColor = Color.Gray;

                textBoxBrand.Text = "Введите марку судна";
                textBoxBrand.ForeColor = Color.Gray;

                textBoxStartDate.Text = "__.__.____";
                textBoxStartDate.ForeColor = Color.Gray;

                textBoxEndDate.Text = "__.__.____";
                textBoxEndDate.ForeColor = Color.Gray;
            }
            else
            {
                MessageBox.Show("Ошибка! Запись не была добавлена!");
            }
        }

        public Boolean checkNum(string check)
        {
            DataBase DB_UP = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `ships` WHERE `board number` = @num", DB_UP.getConnection());
            command.Parameters.Add("@num", MySqlDbType.VarChar).Value = check;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("У данного судного уже есть запись!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void textBoxNum_Enter(object sender, EventArgs e)
        {
            if (textBoxNum.Text == "Введите номер судна")
            {
                textBoxNum.Text = "";
                textBoxNum.ForeColor = Color.Black;
            }
        }

        private void textBoxNum_Leave(object sender, EventArgs e)
        {
            if (textBoxNum.Text == "")
            {
                textBoxNum.Text = "Введите номер судна";
                textBoxNum.ForeColor = Color.Gray;
            }
        }

        private void textBoxOwner_Enter(object sender, EventArgs e)
        {
            if (textBoxOwner.Text == "Введите логин владельца")
            {
                textBoxOwner.Text = "";
                textBoxOwner.ForeColor = Color.Black;
            }
        }

        private void textBoxOwner_Leave(object sender, EventArgs e)
        {
            if (textBoxOwner.Text == "")
            {
                textBoxOwner.Text = "Введите логин владельца";
                textBoxOwner.ForeColor = Color.Gray;
            }
        }

        private void textBoxBrand_Enter(object sender, EventArgs e)
        {
            if (textBoxBrand.Text == "Введите марку судна")
            {
                textBoxBrand.Text = "";
                textBoxBrand.ForeColor = Color.Black;
            }
        }

        private void textBoxBrand_Leave(object sender, EventArgs e)
        {
            if (textBoxBrand.Text == "")
            {
                textBoxBrand.Text = "Введите марку судна";
                textBoxBrand.ForeColor = Color.Gray;
            }
        }

        private void textBoxStartDate_Enter(object sender, EventArgs e)
        {
            if (textBoxStartDate.Text == "__.__.____")
            {
                textBoxStartDate.Text = "";
                textBoxStartDate.ForeColor = Color.Black;
            }
        }

        private void textBoxStartDate_Leave(object sender, EventArgs e)
        {
            if (textBoxStartDate.Text == "")
            {
                textBoxStartDate.Text = "__.__.____";
                textBoxStartDate.ForeColor = Color.Gray;
            }
        }

        private void textBoxEndDate_Enter(object sender, EventArgs e)
        {
            if (textBoxEndDate.Text == "__.__.____")
            {
                textBoxEndDate.Text = "";
                textBoxEndDate.ForeColor = Color.Black;
            }
        }

        private void textBoxEndDate_Leave(object sender, EventArgs e)
        {
            if (textBoxEndDate.Text == "")
            {
                textBoxEndDate.Text = "__.__.____";
                textBoxEndDate.ForeColor = Color.Gray;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string noteDel = textBoxDelete.Text;

            DataBase DB = new DataBase();

            if (DB.DeleteNote(noteDel) == true)
            {
                MessageBox.Show("Запись успешно удалена!");

                tableDelete.Visible = false;
                labelCheckDel.Visible = false;
                buttonDelete.Visible = false;
                pictureBoxDel.Visible = false;
                textBoxDelete.Text = "";
            }
            else
            {
                MessageBox.Show("Ошибка! Запись не была удалена!");
            }
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            mainTable.Visible = false;
            tabControl.Visible = true;
            tabServices.Visible = false;
            pictureBoxEdit.Visible = false;
            pictureBoxBackAdd.Visible = true;
            textBoxSearch.Visible = false;
            pictureSearch.Visible = false;
            pictureBoxServices.Visible = false;

        }

        private void pictureBoxBackAdd_Click(object sender, EventArgs e)
        {
            pictureBoxEdit.Visible = true;
            pictureBoxBackAdd.Visible = false;
            tabControl.Visible = false;
            textBoxSearch.Text = "Поиск судна";
            textBoxSearch.ForeColor = Color.Gray;
            textBoxSearch.Visible = true;
            pictureSearch.Visible = true;
            pictureBoxServices.Visible = true;

            tableDelete.Visible = false;
            labelCheckDel.Visible = false;
            buttonDelete.Visible = false;
            pictureBoxDel.Visible = false;

            cBStatusEdit.Visible = false;
            textBoxBrandEdit.Visible = false;
            textBoxEndDateEdit.Visible = false;
            textBoxNumEdit.Visible = false;
            textBoxOwnerEdit.Visible = false;
            textBoxStartDateEdit.Visible = false;
            buttonSaveEdit.Visible = false;

            textBoxDelete.Text = "";
            textBoxEdit.Text = "";

            textBoxNum.Text = "Введите номер судна";
            textBoxNum.ForeColor = Color.Gray;

            textBoxOwner.Text = "Введите логин владельца";
            textBoxOwner.ForeColor = Color.Gray;

            textBoxBrand.Text = "Введите марку судна";
            textBoxBrand.ForeColor = Color.Gray;

            textBoxStartDate.Text = "__.__.____";
            textBoxStartDate.ForeColor = Color.Gray;

            textBoxEndDate.Text = "__.__.____";
            textBoxEndDate.ForeColor = Color.Gray;
        }

        private void pictureBoxEditNote_Click(object sender, EventArgs e)
        {
            string numBoard = textBoxEdit.Text;

            if (numBoard == "")
            {
                MessageBox.Show("Введите номер судна!");
                return;
            }
            string com = "SELECT * FROM `ships` WHERE `board number`= @edit";


            DataBase DB = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand(com, DB.getConnection());
            command.Parameters.Add("@edit", MySqlDbType.VarChar).Value = numBoard;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                cBStatusEdit.Visible = true;
                textBoxBrandEdit.Visible = true;
                textBoxEndDateEdit.Visible = true;
                textBoxNumEdit.Visible = true;
                textBoxOwnerEdit.Visible = true;
                textBoxStartDateEdit.Visible = true;
                buttonSaveEdit.Visible = true;

                cBStatusEdit.Text = table.Rows[0].ItemArray[1].ToString();
                textBoxNumEdit.Text = table.Rows[0].ItemArray[2].ToString();
                textBoxOwnerEdit.Text = table.Rows[0].ItemArray[3].ToString();
                textBoxBrandEdit.Text = table.Rows[0].ItemArray[4].ToString();
                textBoxStartDateEdit.Text = table.Rows[0].ItemArray[5].ToString();
                textBoxEndDateEdit.Text = table.Rows[0].ItemArray[6].ToString();
            }
            else
            {
                MessageBox.Show("Ошибка! Такой записи не существует!");
                textBoxDelete.Text = "";
            }
        }

        private void buttonSaveEdit_Click(object sender, EventArgs e)
        {
            string status = cBStatusEdit.SelectedItem.ToString();
            string num = textBoxNumEdit.Text;
            string owner = textBoxOwnerEdit.Text;
            string brand = textBoxBrandEdit.Text;
            string startDate = textBoxStartDateEdit.Text;
            string endDate = textBoxEndDateEdit.Text;

            if (num == "" || owner == "" || brand == "" || startDate == "" || endDate == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            DataBase DB_UP = new DataBase();
            DataTable table = new DataTable();

            if (DB_UP.DeleteNote(num) == true)
            {
                MessageBox.Show("Запись успешно удалена!");
            }
            else 
            {
                MessageBox.Show("Ошибка!");
                return;
            }

            if (checkNum(textBoxNumEdit.Text))
            {
                return;
            }

            string tableName = "ships"; 
            if (DB_UP.AddNote(status, num, owner, brand, startDate, endDate, tableName))
            {
                MessageBox.Show("Запись успешно добалена!");
                cBStatusEdit.Visible = false;
                textBoxNumEdit.Visible = false;
                textBoxOwnerEdit.Visible = false;
                textBoxBrandEdit.Visible = false;
                textBoxStartDateEdit.Visible = false;
                textBoxEndDateEdit.Visible = false;
                buttonSaveEdit.Visible = false;
            }
            else
            {
                MessageBox.Show("Ошибка! Запись не была добавлена!");
            }
        }

        private void pictureBoxServices_Click(object sender, EventArgs e)
        {
            mainTable.Visible = false;
            tabControl.Visible = false;
            tabServices.Visible = true;
            pictureBoxServices.Visible = false;
            pictureBoxBackServices.Visible = true;
            textBoxSearch.Visible = false;
            pictureSearch.Visible = false;
            pictureBoxEdit.Visible = false;
        }

        private void pictureBoxBackServices_Click(object sender, EventArgs e)
        {
            pictureBoxServices.Visible = true;
            pictureBoxBackServices.Visible = false;
            tabControl.Visible = false;
            textBoxSearch.Text = "Поиск судна";
            textBoxSearch.ForeColor = Color.Gray;
            textBoxSearch.Visible = true;
            pictureSearch.Visible = true;
            tabServices.Visible = false;

            if (Transfer.Welcome == "admin")
            {
                pictureBoxEdit.Visible = true;
            }
            else
            {
                pictureBoxEdit.Visible = false;
            }
        }

        private void pictureBoxPlusServise1_Click(object sender, EventArgs e)
        {
            if (cBAdditionalServices.SelectedIndex > -1)
            {
                cBAdditionalServices1.Visible = true;
                pictureBoxPlusServise2.Visible = true;
            }
        }

        private void pictureBoxPlusServise2_Click(object sender, EventArgs e)
        {
            if (cBAdditionalServices1.SelectedIndex > -1)
            {
                cBAdditionalServices2.Visible = true;
            }
        }


        private void buttonService_Click(object sender, EventArgs e)
        {
            if (cBAdditionalServices.SelectedIndex > -1)
            {
                AddService(cBAdditionalServices.SelectedItem.ToString());
                cBAdditionalServices.SelectedIndex = -1;
            } 
            
            if (cBAdditionalServices1.SelectedIndex > -1 )
            {
                AddService(cBAdditionalServices1.SelectedItem.ToString());
                cBAdditionalServices1.SelectedIndex = -1;
            } 
            
            if (cBAdditionalServices2.SelectedIndex > -1)
            {
                AddService(cBAdditionalServices2.SelectedItem.ToString());
                cBAdditionalServices2.SelectedIndex = -1;
            }
            cBBoart.SelectedIndex = -1;
            pictureBoxPlusServise1.Enabled = false;
            cBAdditionalServices.Visible = false;
            cBAdditionalServices1.Visible = false;
            cBAdditionalServices2.Visible = false;
        }

        public void AddService(string item)
        {
            DataBase DB_UP = new DataBase();

            string tableName = "additional_services";
            string num = cBBoart.SelectedItem.ToString();
            if (DB_UP.AddNote(num, item, tableName))
            {
                MessageBox.Show("Заявка успешно оформена! Если возникнут непредвиденные трудности, с Вами свяжется администратор.");
            }
            else
            {
                MessageBox.Show("Ошибка! Запись не была добавлена!");
            }
        }

        private void cBBoart_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBAdditionalServices.Enabled = true;
            pictureBoxPlusServise1.Enabled = true;
        }

        private void textBoxNumRent_Enter(object sender, EventArgs e)
        {
            if (textBoxNumRent.Text == "Введите номер судна")
            {
                textBoxNumRent.Text = "";
                textBoxNumRent.ForeColor = Color.Black;
            }
        }

        private void textBoxNumRent_Leave(object sender, EventArgs e)
        {
            if (textBoxNumRent.Text == "")
            {
                textBoxNumRent.Text = "Введите номер судна";
                textBoxNumRent.ForeColor = Color.Gray;
            }
        }

        private void textBoxBrandRent_Enter(object sender, EventArgs e)
        {
            if (textBoxBrandRent.Text == "Введите марку судна")
            {
                textBoxBrandRent.Text = "";
                textBoxBrandRent.ForeColor = Color.Black;
            }
        }

        private void textBoxBrandRent_Leave(object sender, EventArgs e)
        {
            if (textBoxBrandRent.Text == "")
            {
                textBoxBrandRent.Text = "Введите марку судна";
                textBoxBrandRent.ForeColor = Color.Gray;
            }
        }

        private void textBoxStartDateRent_Enter(object sender, EventArgs e)
        {
            if (textBoxStartDateRent.Text == "__.__.____")
            {
                textBoxStartDateRent.Text = "";
                textBoxStartDateRent.ForeColor = Color.Black;
            }
        }

        private void textBoxStartDateRent_Leave(object sender, EventArgs e)
        {
            if (textBoxStartDateRent.Text == "")
            {
                textBoxStartDateRent.Text = "__.__.____";
                textBoxStartDateRent.ForeColor = Color.Gray;
            }
        }

        private void textBoxEndDateRent_Enter(object sender, EventArgs e)
        {
            if (textBoxEndDateRent.Text == "__.__.____")
            {
                textBoxEndDateRent.Text = "";
                textBoxEndDateRent.ForeColor = Color.Black;
            }
        }

        private void textBoxEndDateRent_Leave(object sender, EventArgs e)
        {
            if (textBoxEndDateRent.Text == "")
            {
                textBoxEndDateRent.Text = "__.__.____";
                textBoxEndDateRent.ForeColor = Color.Gray;
            }
        }

        private void buttonRent_Click(object sender, EventArgs e)
        {
            string num = textBoxNumRent.Text;
            string owner = textBoxOwnerRent.Text;
            string brand = textBoxBrandRent.Text;
            string startDate = textBoxStartDateRent.Text;
            string endDate = textBoxEndDateRent.Text;

            if (num == "Введите номер судна" || brand == "Введите марку судна" || startDate == "__.__.____" || endDate == "__.__.____")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (checkNum(textBoxNumRent.Text))
            {
                return;
            }

            DataBase DB_UP = new DataBase();

            string tableName = "ships";

            if (DB_UP.AddNote("requires moderation", num, owner, brand, startDate, endDate, tableName))
            {
                MessageBox.Show("Заявка успешно оформена! Если возникнут непредвиденные трудности, с Вами свяжется администратор.");
                textBoxNumRent.Text = "Введите номер судна";
                textBoxNumRent.ForeColor = Color.Gray;

                textBoxOwnerRent.Text = Transfer.Welcome;

                textBoxBrandRent.Text = "Введите марку судна";
                textBoxBrandRent.ForeColor = Color.Gray;

                textBoxStartDateRent.Text = "__.__.____";
                textBoxStartDateRent.ForeColor = Color.Gray;

                textBoxEndDateRent.Text = "__.__.____";
                textBoxEndDateRent.ForeColor = Color.Gray;
            }
            else
            {
                MessageBox.Show("Ошибка! Запись не была добавлена!");
            }
        }

        private void cBAdditionalServices_TextChanged(object sender, EventArgs e)
        {
                buttonService.Enabled = true;
        }
        
        public void addBoart()
        {
            string com = "SELECT `board number` FROM `ships` WHERE `owner`= @owner";

            DataBase DB = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand(com, DB.getConnection());
            command.Parameters.Add("@owner", MySqlDbType.VarChar).Value = Transfer.Welcome;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    cBBoart.Items.Add(table.Rows[i][0].ToString());
                }
            }
            else
            {
                cBBoart.Text = "Вы еще не регистрировали свой водный транспорт";
                cBAdditionalServices.Enabled = false;
                pictureBoxPlusServise1.Enabled = false;
            }
        }

        private void tabServices_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                cBAdditionalServices.Enabled = false;
                pictureBoxPlusServise1.Enabled = false;
                buttonService.Enabled = false;

                addBoart();
            }
            else
            {
                cBAdditionalServices.SelectedIndex = -1;
                cBAdditionalServices1.SelectedIndex = -1;
                cBAdditionalServices2.SelectedIndex = -1;
                cBBoart.Items.Clear();
                pictureBoxPlusServise1.Enabled = false;
                cBAdditionalServices1.Visible = false;
                cBAdditionalServices2.Visible = false;
                pictureBoxPlusServise2.Visible = false;
            }
        }

        private void textBoxStartDateRent_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStartDateRent.Text != "__.__.____")
            {
                string a = textBoxStartDateRent.Text;
                if (a.Length == 2)
                {
                    textBoxStartDateRent.Text = textBoxStartDateRent.Text + "."; //добавляет запятую после второго знака
                    textBoxStartDateRent.SelectionStart = textBoxStartDateRent.Text.Length; //переносит курсор в конец текстбокса
                }

                if (a.Length == 5)
                {
                    textBoxStartDateRent.Text = textBoxStartDateRent.Text + "."; //добавляет точку после пятого знака учитывая точку
                    textBoxStartDateRent.SelectionStart = textBoxStartDateRent.Text.Length; //переносит курсор в конец текстбокса
                }
            }
        }

        private void textBoxEndDateRent_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEndDateRent.Text != "__.__.____")
            {
                string a = textBoxEndDateRent.Text;
                if (a.Length == 2)
                {
                    textBoxEndDateRent.Text = textBoxEndDateRent.Text + ".";//добавляет запятую после второго знака
                    textBoxEndDateRent.SelectionStart = textBoxEndDateRent.Text.Length;//переносит курсор в конец текстбокса
                }

                if (a.Length == 5)
                {
                    textBoxEndDateRent.Text = textBoxEndDateRent.Text + ".";//добавляет точку после пятого знака учитывая точку
                    textBoxEndDateRent.SelectionStart = textBoxEndDateRent.Text.Length;//переносит курсор в конец текстбокса
                }
            }
        }

        private void pictureBoxStat_Click(object sender, EventArgs e)
        {
            pictureBoxEdit.Visible = false;
            pictureBoxServices.Visible = false;
            pictureBoxChat.Visible = false;
            pictureBoxStatBack.Visible = true;
            pictureBoxStat.Visible = false;
            panelStat.Visible = true;
            pictureUser.Visible = false;
        }

        private void pictureBoxStatBack_Click(object sender, EventArgs e)
        {
            panelStat.Visible = false;
            pictureBoxEdit.Visible = true;
            pictureBoxServices.Visible = true;
            pictureBoxChat.Visible = true;
            pictureBoxStat.Visible = true;
            pictureBoxStatBack.Visible = false;
            pictureUser.Visible = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalMediaCollection
{
    public partial class frmSearchServices : Form
    {
        DataTable table;
        SQLiteConnection connection;
        SQLiteDataAdapter adapter;
        bool saved;
        private void GetSearchServices()
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "select id, NameService, Login, Password, SortOrder, IsNeedAuth, IsEnabled from SearchServices order by SortOrder;";
            SQLiteCommand update = new SQLiteCommand(connection);
            update.CommandText = "update SearchServices set Login = @Login, Password = @Password, SortOrder = @SortOrder, IsEnabled = @IsEnabled where id = @id";
            update.Parameters.Add("@Login", DbType.String, 256, "Login");
            update.Parameters.Add("@Password", DbType.String, 256, "Password");
            update.Parameters.Add("@SortOrder", DbType.Int32, 4, "SortOrder");
            update.Parameters.Add("@IsEnabled", DbType.Boolean, 1, "IsEnabled");
            update.Parameters.Add("@id", DbType.Int32, 4, "id");
            adapter = new SQLiteDataAdapter();
            adapter.SelectCommand = command;
            adapter.UpdateCommand = update;
            table = new DataTable();
            adapter.Fill(table);
            frmMain main = this.Owner as frmMain;
            if (main == null)
            {
                return;
            }
            foreach (DataRow row in table.Rows)
            {
                if (row["Password"] != DBNull.Value)
                {
                    row["Password"] = main.DecryptString(row["Password"].ToString());
                }
            }
            saved = false;
        }
        public frmSearchServices(SQLiteConnection cn)
        {
            InitializeComponent();
            connection = cn;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSearchServices_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain main = this.Owner as frmMain;
            if (main == null)
            {
                return;
            }
            if (saved == false)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["Password"] != DBNull.Value)
                    {
                        row["Password"] = main.EncryptString(row["Password"].ToString());
                    }
                }
                adapter.Update(table);
                saved = true;
            }
        }

        private void tblServices_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (tblServices.Columns[tblServices.CurrentCell.ColumnIndex].Name == "Password")
            {
              TextBox textBox = e.Control as TextBox;
              if (textBox != null)
              {
                textBox.UseSystemPasswordChar = true;
              }
            }
        }

        private void tblServices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tblServices.Columns[e.ColumnIndex].Name == "Password")
            {
                if (e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                    e.FormattingApplied = true;
                }
            }
        }

        private void frmSearchServices_Load(object sender, EventArgs e)
        {
            GetSearchServices();
            tblServices.DataSource = table;
            tblServices.AllowUserToAddRows = false;
            tblServices.AllowUserToDeleteRows = false;
            foreach (DataGridViewColumn c in tblServices.Columns)
            {
                if (c.Name == "id")
                {
                    c.Visible = false;
                }
                else if (c.Name == "NameService")
                {
                    c.HeaderText = "Сервис";
                    c.ReadOnly = true;
                }
                else if (c.Name == "Login")
                {
                    c.HeaderText = "Пользователь";
                }
                else if (c.Name == "Password")
                {
                    c.HeaderText = "Пароль";
                }
                else if (c.Name == "SortOrder")
                {
                    c.HeaderText = "Порядок поиска";
                }
                else if (c.Name == "IsNeedAuth")
                {
                    c.HeaderText = "Требуется вход";
                    c.ReadOnly = true;
                }
                else if (c.Name == "IsEnabled")
                {
                    c.HeaderText = "Включено";
                }
            }
        }
    }
}

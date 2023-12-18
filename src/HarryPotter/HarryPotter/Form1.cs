using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography.X509Certificates;

namespace HarryPotter
{
    public partial class Form1 : Form
    {
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\HarryPotter2002-2003.mdb";
        private OleDbConnection myString;
        public Form1()
        {
            InitializeComponent();
            myString = new OleDbConnection(connectionString);
            myString.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_HarryPotter2002_2003DataSet.students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this._HarryPotter2002_2003DataSet.students);

        }
        
        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            myString.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int deleteIDstudents = Convert.ToInt32(textBoxDelete.Text);
            string deleteQuery = "DELETE FROM students WHERE [Student ID] = " + deleteIDstudents;
            OleDbCommand command = new OleDbCommand(deleteQuery, myString);
            command.ExecuteNonQuery();
            MessageBox.Show("The student's data has been deleted");
            this.studentsTableAdapter.Fill(this._HarryPotter2002_2003DataSet.students);
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            int changeIDstudents = Convert.ToInt32(textBoxSelectionStudent.Text);
            int changeGroup = Convert.ToInt32(textBoxChange.Text);
            if (changeGroup > 0 && changeGroup < 21)
            {
                string changeQuery = "UPDATE students SET [Group number] = " + changeGroup + " WHERE [Student ID] = " + changeIDstudents;
                OleDbCommand command = new OleDbCommand(changeQuery, myString);
                command.ExecuteNonQuery();
                MessageBox.Show("The student's data has been updated");
                this.studentsTableAdapter.Fill(this._HarryPotter2002_2003DataSet.students);
            }
            else
            {
                MessageBox.Show("You entered an incorrect group number");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.studentsTableAdapter.Fill(this._HarryPotter2002_2003DataSet.students);
        }
    }
}

using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace HarryPotter
{
    public partial class Form2 : Form
    {
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\HarryPotter2002-2003.mdb";
        private OleDbConnection myString;
        public Form2()
        {
            InitializeComponent();
            myString = new OleDbConnection(connectionString);
            myString.Open();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            int StudentID = Convert.ToInt32(textBoxStudentID.Text);
            string FirstName = textBox2.Text;
            string SecondName = textBoxSecondName.Text;
            int GroupNumber = Convert.ToInt32(textBoxGroupNumber.Text);
            string addQuery = "INSERT INTO students VALUES (" + StudentID + ",'" + FirstName + "','" + SecondName + "'," + GroupNumber +")";
            OleDbCommand command = new OleDbCommand(addQuery, myString);
            command.ExecuteNonQuery();
            MessageBox.Show("The student has been added");
        }
    }
}

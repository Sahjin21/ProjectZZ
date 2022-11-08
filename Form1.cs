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


/***************
Shawn Embry
CIST2342 C#II
Project ZZ
11-27-2020
*****************/
namespace ProjectZZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtbxID.Text = "admin";
            txtbxPassword.Text = "123";
            txtbxFirstName.Text = "";
            txtbxLastName.Text = "";
        
        }

        private bool confirmLogon()
        {
            string connectionString = null;
            string sql = null;
            OleDbConnection oledbCnn;
            OleDbDataAdapter adapter;
            OleDbCommand command;
            List<string> acctNumbers = new List<string>();

            connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";

            oledbCnn = new OleDbConnection(connectionString);
            command = new OleDbCommand("Select * from Customers", oledbCnn);
            adapter = new OleDbDataAdapter(command);
            DataTable td = new DataTable();

            adapter.Fill(td);

            foreach (DataRow row in td.Rows)
            {
                //Find the customer to match
                if((string)row.ItemArray[0] == txtbxID.Text)
                {
                    if( (string)row.ItemArray[1] == txtbxPassword.Text && 
                        (string)row.ItemArray[2] == txtbxFirstName.Text && 
                        (string)row.ItemArray[3] == txtbxLastName.Text )
                    {
                        return true;
                    }
                }
                
            }

            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //Admin login
            if(txtbxID.Text == "admin" && txtbxPassword.Text == "123")
            {
                Admin form = new Admin(this);
                form.Show();

                txtbxID.Text = "";
                txtbxPassword.Text = "";
                txtbxFirstName.Text = "";
                txtbxLastName.Text = "";
            }// Customer login
            else if (confirmLogon())
            {
                CustomerAcct form = new CustomerAcct(txtbxID.Text,this);
                form.Show();

                txtbxID.Text = "";
                txtbxPassword.Text = "";
                txtbxFirstName.Text = "";
                txtbxLastName.Text = "";             
            }
            else // Error
            {
                MessageBox.Show("Logon Information Is Wrong");
            }
        }
    }
}

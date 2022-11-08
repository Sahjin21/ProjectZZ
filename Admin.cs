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
using System.Data;

/***************
Shawn Embry
CIST2342 C#II
Project ZZ
11-27-2020
*****************/

namespace ProjectZZ
{
    public partial class Admin : Form
    {
        private List<Customer> _customers = new List<Customer>();
        Form _parentForm;
        public Admin(Form parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _parentForm.Hide();
            populateCustomerList();
        }

        private void populateCustomerList()
        {
            string connectionString = null;
            string sql = null;
            OleDbConnection oledbCnn;
            OleDbDataAdapter adapter;
            OleDbCommand command;

            connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";

            oledbCnn = new OleDbConnection(connectionString);
            command = new OleDbCommand("Select * from Customers", oledbCnn);
            adapter = new OleDbDataAdapter(command);
            DataTable td = new DataTable();
            adapter.Fill(td);
            foreach (DataRow row in td.Rows)
            {
                Customer cust = new Customer();
                cust.ID = (string)row.ItemArray[0];
                cust.password = (string)row.ItemArray[1];
                cust.firstName = (string)row.ItemArray[2];
                cust.lastName = (string)row.ItemArray[3];
                cust.address = (string)row.ItemArray[4];
                cust.email = (string)row.ItemArray[5];
                _customers.Add(cust);

                //Add to ListView control
                ListViewItem lvi = new ListViewItem();                
                lvi.Text = cust.ID;
                lvi.SubItems.Add(cust.password);
                lvi.SubItems.Add(cust.firstName);
                lvi.SubItems.Add(cust.lastName);
                lvi.SubItems.Add(cust.address);
                lvi.SubItems.Add(cust.email);
                lstvwCustomers.Items.Add(lvi);                
            }
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Logoff?", "Chatt Bank", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                _parentForm.Show();
            }
        }


        // Get a free account number to use.
        private string getNewCustomerID()
        {
            int maxID = 0, idNum;
            string val;
            string connectionString = null;
            string sql = null;
            OleDbConnection oledbCnn;
            OleDbDataAdapter adapter;
            OleDbCommand command;
            List<string> acctNumbers = new List<string>();

            connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";

            oledbCnn = new OleDbConnection(connectionString);
            command = new OleDbCommand("Select CustID from Customers", oledbCnn);
            adapter = new OleDbDataAdapter(command);
            DataTable td = new DataTable();

            adapter.Fill(td);

            foreach (DataRow row in td.Rows)
            {
                val = (string)row.ItemArray[0];

                idNum = int.Parse(val);
                if (idNum > maxID)
                {
                    maxID = idNum;
                }
            }
            maxID++;
            return maxID.ToString();
        }

        private string addNewCustomer(string password, string firstName, string lastName, string address, string email)
        {
            string custID;

            custID = getNewCustomerID();        
            string ConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";
            //string SqlString = "Insert Into Customers (CustID, CustPassword, CustFirstName, CustLastName, CustAddress, CustEmail) Values (?,?,?,?,?,?)";
            string SqlString = "Insert Into Customers (CustID, CustPassword, CustFirstName, CustLastName, CustAddress, CustEmail) Values (?,?,?,?,?,?)";
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("CustID", custID);
                    cmd.Parameters.AddWithValue("CustPassword", password);
                    cmd.Parameters.AddWithValue("CustFirstName", firstName);
                    cmd.Parameters.AddWithValue("CustLastName", lastName);
                    cmd.Parameters.AddWithValue("CustAddress", address);
                    cmd.Parameters.AddWithValue("CustEmail", email);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Customer cust = new Customer();
                    cust.ID = custID;
                    cust.password = password;
                    cust.firstName = firstName;
                    cust.lastName = lastName;
                    cust.address = address;
                    cust.email = email;
                    _customers.Add(cust);

                    //Add to listview
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = cust.ID;
                    lvi.SubItems.Add(cust.password);
                    lvi.SubItems.Add(cust.firstName);
                    lvi.SubItems.Add(cust.lastName);
                    lvi.SubItems.Add(cust.address);
                    lvi.SubItems.Add(cust.email);
                    lstvwCustomers.Items.Add(lvi);
                }
            }
            return custID;
        }

        // Adds a new customer to the database
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Want To Create This Account?", "Chatt Bank", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {           
                //Extract the values form text boxes and make sure they are valid
                if (txtbxPassword.Text.Length > 3 && txtbxFirstName.Text.Length > 0 && txtbxLastName.Text.Length > 0 && txtbxEmail.Text.Length > 3 && txtbxAddress.Text.Length > 1)
                {
                    txtbxID.Text = addNewCustomer(txtbxPassword.Text, txtbxFirstName.Text, txtbxLastName.Text, txtbxAddress.Text, txtbxEmail.Text);
                }
                else
                {
                    MessageBox.Show("Customer Data Not Complete");
                }
            }
        }

        private void lstvwCustomers_DoubleClick(object sender, EventArgs e)
        {
            int item;
            string custID;

            item = lstvwCustomers.Items.IndexOf(lstvwCustomers.SelectedItems[0]);
            custID = (string)lstvwCustomers.Items[item].Text;

            for (int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].ID == custID)
                {
                    txtbxID.Text = _customers[i].ID;
                    txtbxPassword.Text = _customers[i].password;
                    txtbxFirstName.Text = _customers[i].firstName;
                    txtbxLastName.Text = _customers[i].lastName;
                    txtbxAddress.Text = _customers[i].address;
                    txtbxEmail.Text = _customers[i].email;             
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string str;

            str = "Do You Want To Delete Account ID " + txtbxID.Text + "?";
            DialogResult dialogResult = MessageBox.Show(str, "Chatt Bank", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                //Find the customer in the customers list and delete
                for (int i = 0; i < _customers.Count; i++) {
                    //Find the customer in the _customers list
                    if(txtbxID.Text == _customers[i].ID)
                    {
                        //First delete the customer's accounts
                        _customers[i].deleteAccounts();

                        //Now delete the customer
                        string ConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";
                        string SqlString = "DELETE FROM Customers WHERE [CustID] = ?";
                        using (OleDbConnection conn = new OleDbConnection(ConnString))
                        {
                            using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                            {
                                cmd.Parameters.AddWithValue("@CustID", _customers[i].ID);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }

                        //remove the customer from the listview
                        for(int j=0; j < lstvwCustomers.Items.Count; j++)
                        {
                            if(lstvwCustomers.Items[j].Text == _customers[i].ID)
                            {
                                lstvwCustomers.Items.RemoveAt(j);
                                break;
                            }
                        }
                        // Now remove the _customers class in the collection
                        _customers.RemoveAt(i);
                        txtbxID.Text = "";
                        txtbxPassword.Text = "";
                        txtbxFirstName.Text = "";
                        txtbxLastName.Text = "";
                        txtbxAddress.Text = "";
                        txtbxEmail.Text = "";
                        break;
                    }
                }             
            }
        }
    }
}

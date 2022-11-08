using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class Customer
    {

        private List<Account> _accounts = new List<Account>();  // The set of accounts for the customer
        private string _firstName;
        private string _lastName;
        private string _ID;
        private string _address;
        private string _email;
        private string _password;
        private int _indexAccount; //Index of the currently selected account in the _accounts List<> container.
        

        public Customer()
        {
            dataChanged = false;
            _firstName = "";
            _lastName = "";
            _ID = "";
            _address = "";
            _email = "";
            _password = "";
            _indexAccount = -1;
        }

        public string firstName   // property
        {
            get { return _firstName; }   // get method
            set { _firstName = value; }  // set method
        }

        public string lastName   // property
        {
            get { return _lastName; }   // get method
            set { _lastName = value; }  // set method
        }

        public string ID   // property
        {
            get { return _ID; }   // get method
            set { _ID = value; }  // set method
        }

        public string address   // property
        {
            get { return _address; }   // get method
            set { _address = value; }  // set method
        }

        public string email   // property
        {
            get { return _email; }   // get method
            set { _email = value; }  // set method
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public List<Account> accounts
        {
            get { return _accounts; }
            set { _accounts = value; }
        }

        public int indexAccount
        {
            get { return _indexAccount; }
            set { _indexAccount = value; }
        }

        // This value is a flag that tells you if the customer changed data
        public bool dataChanged { get; set; }

        // This uses the id to get the Customer's data
        // and set the values of the Customer class object
        // to reflect the database.  The Customer ID must exist.
        public void getCustomerData(string custID)
        {
            string connectionString = null;
            string sql = null;
            OleDbConnection oledbCnn;
            OleDbDataAdapter adapter;
            OleDbCommand command;
            List<string> acctNumbers = new List<string>();

            connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";

            //SELECT* FROM Customers
            //WHERE Country = 'Mexico';

            oledbCnn = new OleDbConnection(connectionString);
            command = new OleDbCommand("Select * from Customers WHERE [CustID] = ?", oledbCnn);
            adapter = new OleDbDataAdapter(command);
            DataTable td = new DataTable();

            command.Parameters.AddWithValue("@CustID", custID);

            adapter.Fill(td);

            // Set the values for the Customer object           
            ID = (string)td.Rows[0].ItemArray[0];
            password = (string)td.Rows[0].ItemArray[1];
            firstName = (string)td.Rows[0].ItemArray[2];
            lastName = (string)td.Rows[0].ItemArray[3];
            address = (string)td.Rows[0].ItemArray[4];
            email = (string)td.Rows[0].ItemArray[5];

            //I'll need to add the accounts here.
            // Get the account numbers for this customer

            command = new OleDbCommand("Select AcctNo from Accounts WHERE [Cid] = ?", oledbCnn);
            adapter = new OleDbDataAdapter(command);
            td = new DataTable();

            command.Parameters.AddWithValue("@Cid", custID);

            adapter.Fill(td);
;
            foreach (DataRow row in td.Rows)
            {
                acctNumbers.Add((string)row.ItemArray[0]);

               // foreach (var item in row.ItemArray)
               // {
               //     Console.WriteLine(item);
               // }

            }

            //Add the accounts to the Customer object
            for(int i=0; i < acctNumbers.Count; i++)
            {
                Account acct = new Account();
                // Access the database to fill in the 
                // members variables for the account
                acct.getAccountData(acctNumbers[i]);
                _accounts.Add(acct);
            }

        }


        // This updates the Customer info in the database
        // to reflect the Customer object. The ID must
        // exit in the database
        public void updateDatabase()
        {
            // "UPDATE Records SET FirstName = @firstname, LastName = @lastname, Age = @age, Address = @address, Course = @course WHERE [ID] = @id";
            string ConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";
            string SqlString = "UPDATE Customers SET [CustPassword] = ?, [CustFirstName] = ?, [CustLastName] = ?, [CustAddress] = ?, [CustEmail] = ? WHERE [CustID] = ?"; //"Insert Into Customers (CustID, CustPassword, CustFirstName, CustLastName, CustAddress, CustEmail) Values (?,?,?,?,?,?)";
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.Parameters.AddWithValue("@CustPassword", password);
                    cmd.Parameters.AddWithValue("@CustFirstName", firstName);
                    cmd.Parameters.AddWithValue("@CustLastName", lastName);
                    cmd.Parameters.AddWithValue("@CustAddress", address);
                    cmd.Parameters.AddWithValue("@CustEmail", email);
                    cmd.Parameters.AddWithValue("@CustID", ID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    dataChanged = false;
                }
            }

            // Update the customer's accounts
            for(int i=0; i < _accounts.Count; i++)
            {
                if(_accounts[i].dataChanged)
                    _accounts[i].updateDatabase();
            }

        }


        // Get a free account number to use.
        private string getNewAccountNumber()
        {
            int maxAcct = 0, acctNum;
            string val;
            string connectionString = null;
            OleDbConnection oledbCnn;
            OleDbDataAdapter adapter;
            OleDbCommand command;
            List<string> acctNumbers = new List<string>();

            connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";

            oledbCnn = new OleDbConnection(connectionString);
            command = new OleDbCommand("Select AcctNo from Accounts", oledbCnn);
            adapter = new OleDbDataAdapter(command);
            DataTable td = new DataTable();

            adapter.Fill(td);

            foreach (DataRow row in td.Rows)
            {
                val = (string)row.ItemArray[0];

                acctNum = int.Parse(val);
                if(acctNum > maxAcct)
                {
                    maxAcct = acctNum;
                }
            }
            maxAcct++;
            return maxAcct.ToString();
        }

        // Returned the account number (as a string)
        public string addNewAccount(string type)
        {
            //First I need an account number to use
            string acctNo = getNewAccountNumber();
            string ConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";
            //string SqlString = "Insert Into Customers (CustID, CustPassword, CustFirstName, CustLastName, CustAddress, CustEmail) Values (?,?,?,?,?,?)";
            string SqlString = "Insert Into Accounts (AcctNo, Cid, Type, Balance) Values (?,?,?,?)";
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("AcctNo", acctNo);
                    cmd.Parameters.AddWithValue("Cid", ID);
                    cmd.Parameters.AddWithValue("Type", type);
                    cmd.Parameters.AddWithValue("Balance", 0.0);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Account acct = new Account();
                    acct.cid = ID;
                    acct.balance = 0;
                    acct.type = type;
                    acct.acctNo = acctNo;
                }
            }
            return acctNo;
        }

        // If the admin deletes the Customer from the database, the
        // Customer must first delete it's accounts from the database
        public void deleteAccounts()
        {
            for (int i = 0;  i < _accounts.Count; i++){

                string ConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";
                string SqlString = "DELETE FROM Accounts WHERE [AcctNo] = ?";
                using (OleDbConnection conn = new OleDbConnection(ConnString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                    {
                        cmd.Parameters.AddWithValue("@AcctNo",_accounts[i].acctNo );
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        ~Customer()
        {
            //If the customer changed data in any of his accounts, update them
            if (dataChanged)
            {
                updateDatabase();
            }
        }
    }
}

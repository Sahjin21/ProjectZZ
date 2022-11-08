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
    public class Account
    {
        private string _acctNo;
        private string _cid;
        private string _type;
        private decimal _balance;

        public  Account()
        {
            dataChanged = false;
            _acctNo = "0";
            _cid = "0";
            _type = "None";
            _balance = 0;
        }

        public string acctNo   // property
        {
            get { return _acctNo; }   // get method
            set { _acctNo = value; }  // set method
        }

        public string cid
        {
            get { return _cid; }
            set { _cid = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public decimal balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        // This flag is set if any of the data in the account as changed
        // if that's the case, it should be written to the database.
        public bool dataChanged { get; set; }

        // This uses the acctNo to get the Account data
        // and set the values of the Account class object
        // to reflect the database. The acctNo must exist
        // in the database
        public void getAccountData(string accountNum)
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
            command = new OleDbCommand("Select * from Accounts WHERE [AcctNo] = ?", oledbCnn);
            adapter = new OleDbDataAdapter(command);
            DataTable td = new DataTable();

            command.Parameters.AddWithValue("@AcctNo", accountNum);

            adapter.Fill(td);

            string tmp;
            // Set the values for the Customer object           
            acctNo = (string)td.Rows[0].ItemArray[0];
            cid = (string)td.Rows[0].ItemArray[1];
            type = (string)td.Rows[0].ItemArray[2];
            balance = (decimal)td.Rows[0].ItemArray[3];
        }

        // This updates the Account info in the database
        // to reflect the Account object. The acctNo must
        // exit in the database
        public void updateDatabase()
        {
            string ConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\kerds\OneDrive\School\C# II\Project\ChattBankMDB.mdb";
            string SqlString = "UPDATE Accounts SET [Type] = ?, [Balance] = ? WHERE [AcctNo] = ?";
            using (OleDbConnection conn = new OleDbConnection(ConnString))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Balance", balance);                    
                    cmd.Parameters.AddWithValue("@AcctNo", acctNo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    dataChanged = false;
                }
            }
        }

        ~Account()
        {
            if (dataChanged)
            {
                updateDatabase();
            }
        }
    }
}

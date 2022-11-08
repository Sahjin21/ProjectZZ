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

namespace ProjectZZ
{
    public partial class CustomerAcct : Form
    {
        Customer _customer;
        string _custID;
        Form _parentForm;        

        public CustomerAcct(string custID, Form parentForm)
        {
            InitializeComponent();

            // Create and then fill the Customer object with data from the data base.
            _custID = custID;
            _customer = new Customer();
            _customer.getCustomerData(custID);

            _parentForm = parentForm;
            _parentForm.Hide();         

            // Add data to the CustomerAcct form
            for (int i = 0; i < _customer.accounts.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = _customer.accounts[i].acctNo; // Hidden from view. Useful for accessing the proper account
                lvi.Text = _customer.accounts[i].type;                
                lvi.SubItems.Add(_customer.accounts[i].balance.ToString());
                lstvwCustomerAccts.Items.Add(lvi);
            }

            if(_customer.accounts.Count > 0)
            {
                lblAcctNumber.Text = "Account Number: " + _customer.accounts[0].acctNo;
                lblType.Text = "Account Type: " + _customer.accounts[0].type;
                lblBalance.Text = "Balance: " + _customer.accounts[0].balance.ToString();
            }

            cmbbxWithdrawDeposit.SelectedIndex = 0;
            cmbbxType.SelectedIndex = 0;
            lblFirstName.Text = "First Name: " + _customer.firstName;
            lblLastName.Text = "Last Name: " + _customer.lastName;
            lblID.Text = "ID: " + _customer.ID;
        }

        private void CustomerAcct_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnCreateAcct_Click(object sender, EventArgs e)
        {
            int idx;
            idx = cmbbxType.SelectedIndex;
            string str="";
            string acctType = "";

            if(idx == 0)
            {
                str = "Do You Want To Create A Savings Account?";
                acctType = "SAV";
            }else if (idx == 1)
            {
                str = "Do You Want To Create A Checking Account?";
                acctType = "CHK";
            }else if (idx == 2)
            {
                str = "Do You Want To Create An MMA Account?";
                acctType = "MMA";
            }
            else
            {
                return;
            }


            DialogResult dialogResult = MessageBox.Show(str, "Chatt Bank", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string accountNumber;
                Decimal val = 0;
                accountNumber = _customer.addNewAccount(acctType);

                //Update Listview
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = accountNumber; // Hidden from view. Useful for accessing the proper account
                lvi.Text = acctType;
                lvi.SubItems.Add(val.ToString());
                lstvwCustomerAccts.Items.Add(lvi);
            }
            
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }

        private void CustomerAcct_MouseDoubleClick(object sender, MouseEventArgs e)
        {
      
        }

        private void lstvwCustomerAccts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int item;
            string acctNo;

            item = lstvwCustomerAccts.Items.IndexOf(lstvwCustomerAccts.SelectedItems[0]);
            acctNo = (string)lstvwCustomerAccts.Items[item].Tag;

            for(int i = 0; i < _customer.accounts.Count;i++)
            {
                if(_customer.accounts[i].acctNo == acctNo)
                {
                    _customer.indexAccount = i;
                    lblAcctNumber.Text = "Account Number: " + _customer.accounts[i].acctNo;
                    lblType.Text = "Account Type: " + _customer.accounts[i].type;
                    lblBalance.Text = "Balance: " + _customer.accounts[i].balance.ToString();
                }
            }
            
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string str;
            int idx = cmbbxWithdrawDeposit.SelectedIndex;
            decimal money;
            int i = 0;

            // Validate that the value represents money
            if(!Decimal.TryParse(txtbxMoney.Text, out money))
            {                
                MessageBox.Show("Invalid Data", "Chatt Bank");
                return;
            }

            if ( (double)money < 0.0)
            {
                MessageBox.Show("Invalid Data", "Chatt Bank");
                return;
            }

            if (idx == 0)
            {
                str = "Do You Want To Withdraw $" + txtbxMoney.Text + " From Your Account?";
            }
            else
            {
                str = "Do You Want To Deposit $" + txtbxMoney.Text + " Into Your Account?";
            }

            DialogResult dialogResult = MessageBox.Show(str, "Chatt Bank", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (idx == 0)  // Withdrawing money
                {
                    _customer.accounts[_customer.indexAccount].balance -= money;
                    lblBalance.Text = "Balance: " + _customer.accounts[_customer.indexAccount].balance.ToString();
                    _customer.accounts[_customer.indexAccount].dataChanged = true; // Flag that the account has changed
                    //Update the listview
                    for (i = 0; i < lstvwCustomerAccts.Items.Count; i++)
                    {
                        if (_customer.accounts[_customer.indexAccount].acctNo == (string)lstvwCustomerAccts.Items[i].Tag)
                        {
                            lstvwCustomerAccts.Items[i].SubItems[1].Text = _customer.accounts[_customer.indexAccount].balance.ToString();
                            break;
                        }
                    }
                }
                else  // Depositing money
                {
                    _customer.accounts[_customer.indexAccount].balance += money;                    
                    lblBalance.Text = "Balance: " + _customer.accounts[_customer.indexAccount].balance.ToString();
                    _customer.accounts[_customer.indexAccount].dataChanged = true; // Flag that the account has changed
                    //Update the listview
                    for(i=0; i < lstvwCustomerAccts.Items.Count;  i++)
                    {
                        if(_customer.accounts[_customer.indexAccount].acctNo == (string)lstvwCustomerAccts.Items[i].Tag)
                        {
                            lstvwCustomerAccts.Items[i].SubItems[1].Text = _customer.accounts[_customer.indexAccount].balance.ToString();
                            break;
                        }
                    }
                }
            }
        }

        private void txtbxMoney_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

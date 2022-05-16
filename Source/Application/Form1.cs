using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel;
using ApplicationModel;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        AppModel appModel = new AppModel();
        DomainModel.DomainModel domainModel = null;

        public Form1()
        {
            InitializeComponent();
            domainModel = new DomainModel.DomainModel(appModel);

            //Uncomment it for test run without data file
            //domainModel.TestDataInitialization();

            domainModel.LoadDataFromFile();
            appModel.Initialization();

            // Initialize UI
            foreach (var bank in domainModel.Banks)
            {
                cmbBank.Items.Add((bank.Key));
            }
            cmbBank.SelectedIndex = 0;
            cmbCheck.SelectedIndex = 0;

        }

        private void AuthorizeUser()
        {

            if (appModel.CurrentUser == null && tabMainMenu.SelectedTab == tabLogin)
            {
                return;
            }
            else 
                if(appModel.CurrentUser == null)
                {
                    MessageBox.Show(
                    "Войдите в приложение со своим ID!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    tabMainMenu.SelectedTab = tabLogin;
                    return;
                }


            switch (appModel.CurrentUser.Role)
            {
                case RoleList.Administrator:
                    {
                        if (tabMainMenu.SelectedTab != tabAdministrator)
                        {
                            tabMainMenu.SelectTab(tabAdministrator);
/*
                            MessageBox.Show(
                            "У вас нет доступа к этой странице!",
                            "Сообщение",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);*/
                        }
                        break;
                    }
                case RoleList.Manager:
                    {
                        if (tabMainMenu.SelectedTab != tabManager || tabMainMenu.SelectedTab != tabOperator)
                        {
                            tabMainMenu.SelectTab(tabManager);

/*                            MessageBox.Show(
                            "У вас нет доступа к этой странице!",
                            "Сообщение",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
*/
                        }
                        break;
                    }

                case RoleList.Operator:
                    {
                        if (tabMainMenu.SelectedTab != tabOperator)
                        {
                            tabMainMenu.SelectTab(tabOperator);
                            /*
                            MessageBox.Show(
                            "У вас нет доступа к этой странице!",
                            "Сообщение",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);*/
                            return;
                        }
                        break;
                    }

                case RoleList.Client:
                    {
                        if (appModel.CurrentUser.GetType().Name == "PhysicalClient")
                        {
                            if (tabMainMenu.SelectedTab != tabPhysicalClient)
                                tabMainMenu.SelectTab(tabPhysicalClient);
                        }
                        else
                        {
                            if (tabMainMenu.SelectedTab != tabEnterpriseClient)
                                tabMainMenu.SelectTab(tabEnterpriseClient);
                        }
                        /*
                        MessageBox.Show(
                            "У вас нет доступа к этой странице!",
                            "Сообщение",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                        */
                        break;
                    }
            }


        }

        private void InitializeUIForCurrentUser()
        {
            if (appModel.CurrentUser == null)
                return;

            // Initialize UI for current user

            listAccountsPC.Items.Clear();
            listTransactionsPC.Items.Clear();

            listAccountsEC.Items.Clear();
            listTransactionsEC.Items.Clear();

            listLogAdmin.Items.Clear();

            listClients.Items.Clear();
            listManager.Items.Clear();
            listTransactions.Items.Clear();

            listOperator.Items.Clear();
            listOperator2.Items.Clear();

            // For Physical Client

            if (appModel.CurrentUser.GetType() == typeof(PhysicalClient))
            {
                tabMainMenu.SelectTab(tabPhysicalClient);
                tabPCMenu.SelectTab(tabPCAccounts);
                lblUserPC.Text = appModel.CurrentUser.Name;

                // Initialize physical client page controls
                foreach (KeyValuePair<Guid, Account> keyValuePair2 in appModel.CurrentBank.Accounts)
                {
                    var account = (Account)keyValuePair2.Value;

                    if (account.ClientID == appModel.CurrentUser.ID)
                        listAccountsPC.Items.Add(account.ID);
                }

                if (listAccountsPC.Items.Count > 0)
                    listAccountsPC.SelectedIndex = 0;


                foreach (KeyValuePair<Guid, Transaction> keyValuePair2 in appModel.CurrentBank.Transactions)
                {
                    var transaction = (Transaction)keyValuePair2.Value;

                    if (transaction.ClientID == appModel.CurrentUser.ID)
                        listTransactionsPC.Items.Add(transaction.ID);
                }

                if (listTransactionsPC.Items.Count > 0)
                    listTransactionsPC.SelectedIndex = 0;

            }

            // Enterprise Client
            if (appModel.CurrentUser.GetType() == typeof(EnterpriseClient))
            {
                tabMainMenu.SelectTab(tabEnterpriseClient);
                tabECMenu.SelectTab(tabECAccounts);
                lblUserEC.Text = appModel.CurrentUser.Name;

                // Initialize enterprise client page controls
                foreach (KeyValuePair<Guid, Account> keyValuePair2 in appModel.CurrentBank.Accounts)
                {
                    var account = (Account)keyValuePair2.Value;

                    if (account.ClientID == appModel.CurrentUser.ID)
                        listAccountsEC.Items.Add(account.ID);
                }

                if (listAccountsEC.Items.Count > 0)
                    listAccountsEC.SelectedIndex = 0;

                foreach (KeyValuePair<Guid, Transaction> keyValuePair2 in appModel.CurrentBank.Transactions)
                {
                    var transaction = (Transaction)keyValuePair2.Value;

                    if (transaction.ClientID == appModel.CurrentUser.ID)
                        listTransactionsEC.Items.Add(transaction.ID);
                }

                if (listTransactionsEC.Items.Count > 0)
                    listTransactionsEC.SelectedIndex = 0;

            }

            // Employee
            if (appModel.CurrentUser.GetType() == typeof(Employee))
            {
                // Administrator
                if (appModel.CurrentUser.ID.Equals("1"))
                {
                    tabMainMenu.SelectTab(tabAdministrator);

                    foreach (String s in appModel.LogList)
                    {
                        listLogAdmin.Items.Add(s);
                    }

                }

                // Manager
                if (appModel.CurrentUser.ID.Equals("2"))
                {
                    tabMainMenu.SelectTab(tabManager);

                    foreach (KeyValuePair<String, EnterpriseClient> keyValuePairClient in (Dictionary<String, EnterpriseClient>)appModel.CurrentBank.EnterpriseClients)
                    {
                        if (keyValuePairClient.Value.Status != ClientStatus.Аpproved)
                            listClients.Items.Add(keyValuePairClient.Value.ID);
                    }

                    foreach (KeyValuePair<String, PhysicalClient> keyValuePairClient in (Dictionary<String, PhysicalClient>)appModel.CurrentBank.PhysicalClients)
                    {
                        if (keyValuePairClient.Value.Status != ClientStatus.Аpproved)
                            listClients.Items.Add(keyValuePairClient.Value.ID);
                    }

                    foreach (KeyValuePair<Guid, Account> keyValuePairAccount in appModel.CurrentBank.Accounts)
                    {
                        if (keyValuePairAccount.Value.Status != AccountStatus.Аpproved)
                            listManager.Items.Add(keyValuePairAccount.Value.ID);
                    }

                    foreach (KeyValuePair<Guid, Transaction> keyValuePairTransaction in appModel.CurrentBank.Transactions)
                    {
                        if (keyValuePairTransaction.Value.Status != TransactionStatus.Approved)
                            listTransactions.Items.Add(keyValuePairTransaction.Value.ID);
                    }

                }

                // Operator
                if (appModel.CurrentUser.ID.Equals("3"))
                {
                    tabMainMenu.SelectTab(tabOperator);
                    foreach (KeyValuePair<Guid, Transaction> keyValuePairClient in (Dictionary<Guid, Transaction>)appModel.CurrentBank.Transactions)
                    {
                        listOperator.Items.Add(keyValuePairClient.Value.ID);
                    }

                    foreach (KeyValuePair<Guid, Account> keyValuePairClient in (Dictionary<Guid, Account>)appModel.CurrentBank.Accounts)
                    {
                        if (keyValuePairClient.Value.Status == AccountStatus.NotApproved && keyValuePairClient.Value.Type == AccountType.SalaryProject)
                            listOperator2.Items.Add(keyValuePairClient.Value.ID);
                    }

                }
            }        

        }

        private void cmbCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbCheck.SelectedIndex)
            {
                case 0:
                    cmbCheck.Items.Add("Физическое лицо");
                    cmbCheck.Items.Add("Юридическое лицо");
                    cmbCheck.Visible = true;
                    lblRoleChoose.Visible = true;
                    break;

                case 1:
                    txbID.Visible = true;
                    lblIDRole.Visible = true;
                    break;
            }
        }

        private void cmbClientChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbCheck.SelectedIndex)
            {
                case 0:
                    tabMainMenu.Visible = true;
                    tabPCMenu.Visible = true;
                    break;

                case 1:
                    tabMainMenu.Visible = true;
                    tabECMenu.Visible = true;
                    tabMainMenu.SelectedTab = tabEnterpriseClient;
                    break;
            }
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            appModel.CurrentBank = domainModel.Banks[(Guid)cmbBank.SelectedItem];
            tabMainMenu.Visible = true;

        }




        //Registration EC
        private void btnRegistrationEC_Click(object sender, EventArgs e)
        {
            txtLegalName.Visible = true;
            lblLegalName.Visible = true;

            txtType.Visible = true;
            lblType.Visible = true;

            txtBankID.Visible = true;
            lblBankID.Visible = true;

            txtAccountNumber.Visible = true;
            lblAccountNumber.Visible = true;

            txtAdressEC.Visible = true;
            lblAdressEC.Visible = true;
        }

        // Log  in
        private void button1_Click_2(object sender, EventArgs e)
        {
            // No CurrentUser - let's do log in
            if (appModel.CurrentUser == null)
            {

                // Looking up for a physical Client
                foreach (KeyValuePair<String, PhysicalClient> keyValuePair in (((Dictionary<String, PhysicalClient>)appModel.CurrentBank.PhysicalClients)))
                {
                    if (((Client)keyValuePair.Value).ID == txbID.Text)
                    {
                        appModel.CurrentUser = ((IClient)keyValuePair.Value);
                        break;
                    }

                }


                // Looking up for a Enterprise Client
                if (appModel.CurrentUser == null)
                    foreach (KeyValuePair<String, EnterpriseClient> keyValuePair in (((Dictionary<String, EnterpriseClient>)appModel.CurrentBank.EnterpriseClients)))
                    {
                        if (((Client)keyValuePair.Value).ID == txbID.Text)
                        {
                            appModel.CurrentUser = ((IClient)keyValuePair.Value);
                            break;
                        }

                    }

                // Looking up for a Enterprise Client
                if (appModel.CurrentUser == null)
                    foreach (KeyValuePair<String, Employee> keyValuePair in (((Dictionary<String, Employee>)appModel.CurrentBank.Employees)))
                    {
                        if (((Employee)keyValuePair.Value).ID == txbID.Text)
                        {
                            appModel.CurrentUser = ((Employee)keyValuePair.Value);
                            break;
                        }

                    }

                if (appModel.CurrentUser == null)
                {

                    MessageBox.Show(
                    "Аккаунт не найден!",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

                    return;
                }
                else
                {
                    btnEnter.Text = "Выйти";
                    txbID.ReadOnly = true;

                    appModel.WriteLog("Произошёл вход в аккаунт " + appModel.CurrentUser.Name + ": " + appModel.CurrentUser.ID);

                    InitializeUIForCurrentUser();
                }

            }
            // There is Current User - let's do log out
            else
            {
                appModel.CurrentUser = null;
                btnEnter.Text = "Войти";
                txbID.ReadOnly = false;

                //Cleaning list boxes and comboboxes
                
                // For Physical Client
                listAccountsPC.Items.Clear();

                listTransactionsPC.Items.Clear();
                cmbNewSourceAccountPC.Items.Clear();
                cmbNewDestinationAccountPC.Items.Clear();

                // For Enterprise Client
                listAccountsEC.Items.Clear();
//                cmbTypeOfAccountEC.Items.Clear();

                listTransactionsEC.Items.Clear();
                cmbNewSourceAccountEC.Items.Clear();
                cmbNewDestinationAccountEC.Items.Clear();

                // For Admin
                listLogAdmin.Items.Clear();

                //For Manager
                listClients.Items.Clear();
                listManager.Items.Clear();
                listTransactions.Items.Clear();
                
                //For Operator
                listOperator.Items.Clear();

                tabMainMenu.SelectTab(tabLogin);

            }

        }




        private void cmbAction(object sender, EventArgs e)
        {
        }



        //List Initialization
        private void listAccountsSelectedIndexChanged(object sender, EventArgs e)
        {
            txtAccountIDPC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsPC.SelectedItem].ID.ToString();
            txtAccountBankPC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsPC.SelectedItem].BankID.ToString();
            txtAccountDatePC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsPC.SelectedItem].Date.ToString();
            txtAccountSumPC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsPC.SelectedItem].Sum.ToString();
            txtAccountTypePC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsPC.SelectedItem].Type.ToString();
            txtAccountStatusPC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsPC.SelectedItem].Status.ToString();
        }

        private void listAccountsEC_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbAccountIDEC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsEC.SelectedItem].ID.ToString();
            txbAccountBankEC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsEC.SelectedItem].BankID.ToString();
            txbAccountDateEC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsEC.SelectedItem].Date.ToString();
            txbAccountSumEC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsEC.SelectedItem].Sum.ToString();
            txbAccountTypeEC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsEC.SelectedItem].Type.ToString();
            txbAccountStatusEC.Text = appModel.CurrentBank.Accounts[(Guid)listAccountsEC.SelectedItem].Status.ToString();
        }

        private void listTransactionPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbSourceBankPC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsPC.SelectedItem].SourceBankID.ToString();
            txbDestinationBankPC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsPC.SelectedItem].DestinationBankID.ToString();
            txbSourceAccountPC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsPC.SelectedItem].SourceAccountID.ToString();
            txbDestinationAccountPC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsPC.SelectedItem].DestinationAccountID.ToString();
            txbSumPC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsPC.SelectedItem].Sum.ToString();
            txbDatePC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsPC.SelectedItem].Date.ToString();
        }

        private void listTransactionEC_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbSourceBankEC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsEC.SelectedItem].SourceBankID.ToString();
            txbDestinationBankEC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsEC.SelectedItem].DestinationBankID.ToString();
            txbSourceAccountEC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsEC.SelectedItem].SourceAccountID.ToString();
            txbDestinationAccountEC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsEC.SelectedItem].DestinationAccountID.ToString();
            txbSumEC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsEC.SelectedItem].Sum.ToString();
            txbDateEC.Text = appModel.CurrentBank.Transactions[(Guid)listTransactionsEC.SelectedItem].Date.ToString();
        }



        //tabMainMenu_Click
        private void tabMainMenu_Click(object sender, EventArgs e)
        {
            AuthorizeUser();
        }



        //Registration Check Code
        private void cmbClientChooseSelectedIndexChanged(object sender, EventArgs e)
        {

            switch(cmbCheck.SelectedItem)
            {
                case "Физическое лицо":
                {
                    //PhysicalCLient controls are enabled
                    txtName.ReadOnly = false;
                    txtFulname.ReadOnly = false;
                    txtPatronymic.ReadOnly = false;
                    txtPassportSeries.ReadOnly = false;
                    txtPassportNumber.ReadOnly = false;
                    txtID.ReadOnly = false;
                    txtTelephone.ReadOnly = false;
                    txtMail.ReadOnly = false;

                    //EnterpriseCLient controls are disabled
                    txtLegalName.ReadOnly = true;
                    txtType.ReadOnly = true;
                    txtAccountNumber.ReadOnly = true;
                    txtBankID.ReadOnly = true;
                    txtEC_ID.ReadOnly = true;
                    txtAdressEC.ReadOnly = true;
                    txtECTelephone.ReadOnly = true;
                    txtECMail.ReadOnly = true;
                    btnRegistryPC.Visible = true;

                        break;
                }

                case "Юридическое лицо":
                    {

                        txtName.ReadOnly = true;
                        txtFulname.ReadOnly = true;
                        txtPatronymic.ReadOnly = true;
                        txtPassportSeries.ReadOnly = true;
                        txtPassportNumber.ReadOnly = true;
                        txtID.ReadOnly = true;
                        txtTelephone.ReadOnly = true;
                        txtMail.ReadOnly = true;

                        //EnterpriseCLient controls are disabled
                        txtLegalName.ReadOnly = false;
                        txtType.ReadOnly = false;
                        txtAccountNumber.ReadOnly = false;
                        txtBankID.ReadOnly = false;
                        txtEC_ID.ReadOnly = false;
                        txtAdressEC.ReadOnly = false;
                        txtECTelephone.ReadOnly = false;
                        txtECMail.ReadOnly = false;
                        btnRegistryPC.Visible = true;

                        break;
                    }

                case "Не выбран":
                {
                        //PhysicalCLient controls are enabled
                        txtName.ReadOnly = true;
                        txtFulname.ReadOnly = true;
                        txtPatronymic.ReadOnly = true;
                        txtPassportSeries.ReadOnly = true;
                        txtPassportNumber.ReadOnly = true;
                        txtID.ReadOnly = true;
                        txtTelephone.ReadOnly = true;
                        txtMail.ReadOnly = true;

                        //EnterpriseCLient controls are disabled
                        txtLegalName.ReadOnly = true;
                        txtType.ReadOnly = true;
                        txtAccountNumber.ReadOnly = true;
                        txtBankID.ReadOnly = true;
                        txtEC_ID.ReadOnly = true;
                        txtAdressEC.ReadOnly = true;
                        txtECTelephone.ReadOnly = true;
                        txtECMail.ReadOnly = true;
                        btnRegistryPC.Visible = false;
                        break;
                    }

            }
        }

        private void tabECMenu_Click(object sender, EventArgs e)
        {
            AuthorizeUser();
        }

        private void tabPCMenu_Click(object sender, EventArgs e)
        {
            AuthorizeUser();
        }


        //Create new Account PC
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            lblTypeOfAccountPC.Visible = true;
            cmbTypeOfAccountPC.Visible = true;
            lblSumOfAccountPC.Visible = true;
            txbSumOfAccountPC.Visible = true;
            btnSaveNewAccountPC.Visible = true;
        }

        private void btnSaveNewAccount_Click(object sender, EventArgs e)
        {
            Account account = new Account(appModel.CurrentBank, appModel.CurrentUser.ID, (AccountType)cmbTypeOfAccountPC.SelectedIndex, DateTime.Now, Convert.ToDouble(txbSumOfAccountPC.Text));
            account.Status = AccountStatus.NotApproved;

            appModel.CurrentBank.Accounts.Add(account.ID, account);

            lblTypeOfAccountPC.Visible = false;
            cmbTypeOfAccountPC.Visible = false;
            lblSumOfAccountPC.Visible = false;
            txbSumOfAccountPC.Visible = false;
            btnSaveNewAccountPC.Visible = false;

            listAccountsPC.Items.Add(account.ID);

            appModel.WriteLog("Создан новый счёт " + account.ID + " с аккаунта " + appModel.CurrentUser.Name + ": " + appModel.CurrentUser.ID + ", текущего банка: " + appModel.CurrentBank.Name);
        }
        


        //Create new Account EC
        private void btnCreateAccountEC_Click(object sender, EventArgs e)
        {
            lblTypeOfAccountEC.Visible = true;
            cmbTypeOfAccountEC.Visible = true;
            lblSumOfAccountEC.Visible = true;
            txbSumOfAccountEC.Visible = true;
            btnSaveNewAccountEC.Visible = true;
        }

        private void btnSaveNewAccountEC_Click(object sender, EventArgs e)
        {
            Account account = new Account(appModel.CurrentBank, appModel.CurrentUser.ID, (AccountType)cmbTypeOfAccountEC.SelectedIndex, DateTime.Now, Convert.ToDouble(txbSumOfAccountEC.Text));
            appModel.CurrentBank.Accounts.Add(account.ID, account);
            account.Status = AccountStatus.NotApproved;

            lblTypeOfAccountEC.Visible = false;
            cmbTypeOfAccountEC.Visible = false;
            lblSumOfAccountEC.Visible = false;
            txbSumOfAccountEC.Visible = false;
            btnSaveNewAccountEC.Visible = false;

            listAccountsEC.Items.Add(account.ID);

            appModel.WriteLog("Создан новый счёт " + account.ID + " с аккаунта " + appModel.CurrentUser.Name + ": " + appModel.CurrentUser.ID + ", текущего банка: " + appModel.CurrentBank.Name);
        }



        //Create new Transaction PC
        private void btnNewTransactionPC_Click(object sender, EventArgs e)
        {
            lblNewSumPC.Visible = true;
            txbNewSumPC.Visible = true;
            cmbNewSourceAccountPC.Items.Clear();
            cmbNewDestinationAccountPC.Items.Clear();

            foreach (KeyValuePair<Guid, Account> keyValuePair in appModel.CurrentBank.Accounts)
            {
                if(keyValuePair.Value.ClientID == appModel.CurrentUser.ID)
                    cmbNewSourceAccountPC.Items.Add(keyValuePair.Value.ID);
            }

            lblNewSourceAccountPC.Visible = true;
            cmbNewSourceAccountPC.Visible = true;

            foreach (KeyValuePair<Guid, Account> keyValuePair in appModel.CurrentBank.Accounts)
            {
                cmbNewDestinationAccountPC.Items.Add(keyValuePair.Value.ID);
            }

            lblNewDestinationAccountPC.Visible = true;
            cmbNewDestinationAccountPC.Visible = true;

            btnCreateTransactionPC.Visible = true;
        }

        private void btnCreateTransactionPC_Click(object sender, EventArgs e)
        {

            foreach (KeyValuePair<Guid, Account> keyValuePairSourceAccount in appModel.CurrentBank.Accounts)
            {
                if (keyValuePairSourceAccount.Key.ToString() == cmbNewSourceAccountPC.SelectedItem.ToString())
                {
                    keyValuePairSourceAccount.Value.Sum = keyValuePairSourceAccount.Value.Sum - Convert.ToDouble(txbNewSumPC.Text);

                    foreach (KeyValuePair<Guid, Account> keyValuePairDestinationAccount in appModel.CurrentBank.Accounts)
                    {
                        var account = keyValuePairDestinationAccount.Value;

                        if (account.ID.ToString() == cmbNewDestinationAccountPC.SelectedItem.ToString())
                        {
                            Transaction transaction = new Transaction(appModel.CurrentBank.ID, account.BankID, (keyValuePairSourceAccount.Value).ID, account.ID, DateTime.Now, Convert.ToDouble(txbNewSumPC.Text), appModel.CurrentUser.ID);
                            transaction.Status = TransactionStatus.NotApproved;
                            appModel.CurrentBank.Transactions.Add(transaction.ID, transaction);
                            account.Sum = account.Sum + Convert.ToDouble(txbNewSumPC.Text);

                            listTransactionsPC.Items.Add(transaction.ID);

                            appModel.WriteLog("Создан новый перевод " + transaction.ID + " с аккаунта " + appModel.CurrentUser.Name + ": " + appModel.CurrentUser.ID + ", текущего банка: " + appModel.CurrentBank.Name);

                            break;
                        }
                    }
                }

            }

            lblNewSumPC.Visible = false;
            txbNewSumPC.Visible = false;

            lblNewSourceAccountPC.Visible = false;
            cmbNewSourceAccountPC.Visible = false;

            lblNewDestinationAccountPC.Visible = false;
            cmbNewDestinationAccountPC.Visible = false;

            btnCreateTransactionPC.Visible = false;

            if (listTransactionsPC.Items.Count > 0)
                listTransactionsPC.SelectedIndex = 0;
        }



        //Create new Transaction EC
        private void btnNewTransactionEC_Click(object sender, EventArgs e)
        {
            lblNewSumEC.Visible = true;
            txbNewSumEC.Visible = true;

            foreach (KeyValuePair<Guid, Account> keyValuePair in appModel.CurrentBank.Accounts)
            {
                if (keyValuePair.Value.ClientID == appModel.CurrentUser.ID)
                    cmbNewSourceAccountEC.Items.Add(keyValuePair.Value.ID);
            }

            lblNewSourceAccountEC.Visible = true;
            cmbNewSourceAccountEC.Visible = true;

            foreach (KeyValuePair<Guid, Account> keyValuePair in appModel.CurrentBank.Accounts)
            {
                cmbNewDestinationAccountEC.Items.Add(keyValuePair.Value.ID);
            }

            lblNewDestinationAccountEC.Visible = true;
            cmbNewDestinationAccountEC.Visible = true;

            btnCreateTransactionEC.Visible = true;
        }

        private void btnCreateTransactionEC_Click(object sender, EventArgs e)
        {

            foreach (KeyValuePair<Guid, Account> keyValuePairSourceAccount in appModel.CurrentBank.Accounts)
            {
                if (keyValuePairSourceAccount.Key.ToString() == cmbNewSourceAccountEC.SelectedItem.ToString())
                {
                    keyValuePairSourceAccount.Value.Sum = keyValuePairSourceAccount.Value.Sum - Convert.ToDouble(txbNewSumEC.Text);

                    foreach (KeyValuePair<Guid, Account> keyValuePairDestinationAccount in appModel.CurrentBank.Accounts)
                    {
                        var account = keyValuePairDestinationAccount.Value;

                        if (account.ID.ToString() == cmbNewDestinationAccountEC.SelectedItem.ToString())
                        {
                            Transaction transaction = new Transaction(appModel.CurrentBank.ID, account.BankID, keyValuePairSourceAccount.Value.ID, account.ID, DateTime.Now, Convert.ToDouble(txbNewSumEC.Text), appModel.CurrentUser.ID);
                            appModel.CurrentBank.Transactions.Add(transaction.ID, transaction);
                            account.Sum = account.Sum + Convert.ToDouble(txbNewSumEC.Text);

                            listTransactionsEC.Items.Add(transaction.ID);

                            appModel.WriteLog("Создан новый перевод " + transaction.ID + " с аккаунта " + appModel.CurrentUser.Name + ": " + appModel.CurrentUser.ID + ", текущего банка: " + appModel.CurrentBank.Name);

                            break;
                        }
                    }
                }

            }

            lblNewSumEC.Visible = false;
            txbNewSumEC.Visible = false;

            lblNewSourceAccountEC.Visible = false;
            cmbNewSourceAccountEC.Visible = false;

            lblNewDestinationAccountEC.Visible = false;
            cmbNewDestinationAccountEC.Visible = false;

            btnCreateTransactionEC.Visible = false;
        }



        //Manager
        private void btnManagerApprove_Click(object sender, EventArgs e)
        {
            if (listManager.SelectedItem != null)
                appModel.CurrentBank.Accounts[(Guid)listManager.SelectedItem].Status = AccountStatus.Аpproved;

            appModel.WriteLog("Пользователь "+ appModel.CurrentUser.ID+" подтвердил аккаунт " + ((Guid)listManager.SelectedItem).ToString());

            listManager.Items.Remove(listManager.SelectedItem);

        }



        //Operator
        private void btnApprove_Click(object sender, EventArgs e)
        {

            if (listOperator2.SelectedItem != null)
                appModel.CurrentBank.Accounts[(Guid)listOperator2.SelectedItem].Status = AccountStatus.Аpproved;

            appModel.WriteLog("Пользователь " + appModel.CurrentUser.ID + " подтвердил зарплатный проект " + ((Guid)listOperator2.SelectedItem).ToString());

            listOperator2.Items.Remove(listOperator2.SelectedItem);

        }



        //Out Code
        private void txtSingOut_Click(object sender, EventArgs e)
        {
            appModel.CurrentUser = null;
            appModel.CurrentBank = null;

            tabMainMenu.SelectTab(tabLogin);
            tabMainMenu.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            domainModel.StoreDataToFile();
            appModel.CloseLog();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listClients.SelectedItem != null)
            {
                if (appModel.CurrentBank.PhysicalClients[(String)listClients.SelectedItem] != null)
                {
                    ((Dictionary<String, PhysicalClient>)appModel.CurrentBank.PhysicalClients)[(String)listClients.SelectedItem].Status = ClientStatus.Аpproved;
                    return;
                }
                if (appModel.CurrentBank.EnterpriseClients[(String)listClients.SelectedItem] != null)
                    ((Dictionary<String, EnterpriseClient>)appModel.CurrentBank.EnterpriseClients)[(String)listClients.SelectedItem].Status = ClientStatus.Аpproved;

            }

            appModel.WriteLog("Пользователь " + appModel.CurrentUser.ID + " подтвердил учетную запись клиента " + ((String)listClients.SelectedItem));

            listClients.Items.Remove(listClients.SelectedItem);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listTransactions.SelectedItem != null)
                appModel.CurrentBank.Transactions[(Guid)listTransactions.SelectedItem].Status = TransactionStatus.Approved;

            appModel.WriteLog("Пользователь " + appModel.CurrentUser.ID + " подтвердил транзакцию " + ((Guid)listTransactions.SelectedItem).ToString());

            listTransactions.Items.Remove(listTransactions.SelectedItem);

        }

        private void btnRegistryPC_Click(object sender, EventArgs e)
        {
            if ((String)cmbCheck.SelectedItem == "Не выбран")
                return;

            if ((String)cmbCheck.SelectedItem == "Физическое лицо")
            {
                PhysicalClient physicalClient = new PhysicalClient();
                physicalClient.Name = txtName.Text;
                physicalClient.Patronymic = txtPatronymic.Text;
                physicalClient.PassportSeries = txtPassportSeries.Text;
                physicalClient.PassportNumber = txtPassportNumber.Text;
                physicalClient.ID = txtID.Text;
                physicalClient.Telephone = txtTelephone.Text;
                physicalClient.Mail = txtMail.Text;
                physicalClient.Status = ClientStatus.NotApproved;
                appModel.WriteLog("Зарегистрирован аккаунт " + physicalClient.Name + ": " + physicalClient.ID);

                ((Dictionary<String, PhysicalClient>)appModel.CurrentBank.PhysicalClients).Add(physicalClient.ID, (PhysicalClient)physicalClient);
            }
            else 
            {
                EnterpriseClient enterpriseClient = new EnterpriseClient();
                enterpriseClient.Role = RoleList.Client;
                enterpriseClient.Name = txtLegalName.Text;
                enterpriseClient.Type = txtType.Text;
                enterpriseClient.UNB = txtAccountNumber.Text;
                enterpriseClient.BIK = txtBankID.Text;
                enterpriseClient.ID = txtEC_ID.Text;
                enterpriseClient.Telephone = txtECTelephone.Text;
                enterpriseClient.Address = txtAdressEC.Text;
                enterpriseClient.Mail = txtECMail.Text;

                enterpriseClient.Status = ClientStatus.NotApproved;

                ((Dictionary<String, EnterpriseClient>)appModel.CurrentBank.EnterpriseClients).Add(enterpriseClient.ID, enterpriseClient);
                appModel.WriteLog("Зарегистрирован аккаунт " + enterpriseClient.Name + ": " + enterpriseClient.ID);

            }

            txtName.Text = String.Empty;
            txtFulname.Text = String.Empty;
            txtPatronymic.Text = String.Empty;
            txtPassportSeries.Text = String.Empty;
            txtPassportNumber.Text = String.Empty;
            txtID.Text = String.Empty;
            txtTelephone.Text = String.Empty;
            txtMail.Text = String.Empty;

            //EnterpriseCLient controls are disabled
            txtLegalName.Text = String.Empty;
            txtType.Text = String.Empty;
            txtAccountNumber.Text = String.Empty;
            txtBankID.Text = String.Empty;
            txtEC_ID.Text = String.Empty;
            txtAdressEC.Text = String.Empty;
            txtECTelephone.Text = String.Empty;
            txtECMail.Text = String.Empty;
            btnRegistryPC.Text = String.Empty;

            cmbCheck.SelectedIndex = 0;

            MessageBox.Show(
            "Аккаунт зарегистрирован в системе.\nПожалуйста, ожидайте подтверждение менеджера.",
            "Сообщение",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
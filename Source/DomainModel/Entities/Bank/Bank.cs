using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Bank : IBank
    {
        public String Name { get; set; }

        public Guid ID { get; set; }

        public Dictionary<String, PhysicalClient> PhysicalClients { get; set; }

        public Dictionary<String, EnterpriseClient> EnterpriseClients { get; set; }

        public Dictionary<String, Employee> Employees { get; set; }

        public Dictionary<Guid, Account> Accounts { get; set; }

        public Dictionary<Guid, Transaction> Transactions { get; set; }


        public Bank()
        {
            ID = Guid.NewGuid();
            Name = "Bank " + ID.ToString();
            EnterpriseClients = new Dictionary<string, EnterpriseClient>();
            PhysicalClients = new Dictionary<string, PhysicalClient>();
            Employees = new Dictionary<string, Employee>();
            Accounts = new Dictionary<Guid, Account>();
            Transactions = new Dictionary<Guid, Transaction>();
        }

        public void Initialization()
        {
            Random rnd = new Random();
            var numberCode = new[] { 25, 29, 44 };
            var mail = new[] { "@mail.ru", "@gmail.com", "@yandex.ru" };

            // Clients

            // Physical clients
            for (int i = 1; i <= 300; i++)
            {
                IClient client = new PhysicalClient();
                client.Name = "Имя " + i;
                ((PhysicalClient)client).Fulname = "Фамилия " + i;
                ((PhysicalClient)client).Patronymic = "Отчество " + i;
                ((PhysicalClient)client).PassportSeries = Convert.ToString(Convert.ToChar(62 + rnd.Next(22, 26)));
                ((PhysicalClient)client).PassportSeries = Convert.ToString(rnd.Next(1000000, 9999999));
                client.ID = "PC" + Convert.ToString(i);
                client.Telephone = "+375" + Convert.ToString(rnd.Next(numberCode.Length)) + Convert.ToString(rnd.Next(1000000, 9999999));
                client.Mail = "PC" + Convert.ToString(i) + Convert.ToString(rnd.Next(mail.Length));
                client.Status = ClientStatus.Аpproved;
                PhysicalClients.Add(client.ID, (PhysicalClient)client);


            }

            // Enterprise clients
            for (int i = 1; i <= 30; i++)
            {
                IClient client = new EnterpriseClient();
                client.Name = "Компания" + i;
                var typeofEnterprise = new[] { "ИП", "ООО", "ОАО", "ЗАО", "АО" };
                ((EnterpriseClient)client).Type = Convert.ToString(rnd.Next(typeofEnterprise.Length));
                ((EnterpriseClient)client).Address = "Улица Компании " + Convert.ToString(i);
                ((EnterpriseClient)client).UNB = Convert.ToString(rnd.Next(100000000, 999999999));
                ((EnterpriseClient)client).BIK = ID.ToString();

                client.ID = "EC" + Convert.ToString(i);
                client.Telephone = "+375" + Convert.ToString(rnd.Next(numberCode.Length)) + Convert.ToString(rnd.Next(1000000, 9999999));
                client.Mail = "EC" + Convert.ToString(i) + Convert.ToString(rnd.Next(mail.Length));
                client.Status = ClientStatus.Аpproved;
                EnterpriseClients.Add(client.ID, (EnterpriseClient)client);
            }


            // Employees
            for (int i = 1; i <= 3; i++)
            {
                Employee employee = new Employee();
                employee.Name = "Name " + Convert.ToString(i);
                employee.ID = Convert.ToString(i);

                if (i == 1)
                {
                    employee.Role = RoleList.Administrator;
                }

                if (i == 2)
                {
                    employee.Role = RoleList.Manager;
                }

                if (i == 3)
                {
                    employee.Role = RoleList.Operator;
                }

                Employees[employee.Name] = employee;
                Employees.Add(employee.ID, employee);
            }

            // Accounts

            for (int j = 1; j <= 300; j++)
            {

                int i = 1;
                Client bankClient = null;
                foreach (KeyValuePair<String, PhysicalClient> keyValuePair in PhysicalClients)
                {
                    if (i == j)
                    {
                        bankClient = (Client)keyValuePair.Value;
                        break;
                    }
                    else
                        i++;
                }
                var type = rnd.Next((int)AccountType.Credit, (int)AccountType.SalaryProject);
                Account account = new Account(this, bankClient.ID, (AccountType)type, DateTime.Now, j*100);
                Accounts[account.ID] = account;
            }

            for (int j = 1; j <= 30; j++)
            {

                int i = 1;
                IClient bankClient = null;
                foreach (KeyValuePair<String, EnterpriseClient> keyValuePair in EnterpriseClients)
                {
                    if (i == j)
                    {
                        bankClient = (Client)keyValuePair.Value;
                        break;
                    }
                    else
                        i++;
                }
                var type = rnd.Next((int)AccountType.Credit, (int)AccountType.SalaryProject);
                Account account = new Account(this, bankClient.ID, (AccountType)type, DateTime.Now, j * 100);
                Accounts[account.ID] = account;
            }

            // Transactions
            for (int i = 1; i <= 10; i++)
            {
                ITransaction transaction= new Transaction(this.ID, this.ID, Guid.NewGuid(), Guid.NewGuid(), DateTime.Now,i*10, "PC1");

                ((Transaction)transaction).Status = TransactionStatus.NotApproved;
                Transactions.Add(transaction.ID, ((Transaction)transaction));
            }



        }
    }   
}

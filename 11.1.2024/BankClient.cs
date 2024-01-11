using System.Collections;
namespace Bank{

    public class BankClient{
        public static void Main(){
            
            IBankRepository bank = new BankRepository();
            
            SBAccount aa = new SBAccount(1, "a", "delhi", 25000m);
            SBAccount bb = new SBAccount(2, "b", "mumbai", 20000m);
            SBAccount cc = new SBAccount(3, "c", "jammu", 15000m);

            bank.NewAccount(aa);
            bank.NewAccount(bb);
            bank.NewAccount(cc);

            bank.DepositAmount(1, 1000m);
            bank.WithdrawAmount(2, 2000m);
            bank.WithdrawAmount(3, 5000m);
            bank.DepositAmount(1, 9000m);
            bank.DepositAmount(1, 3000m);
            bank.WithdrawAmount(1, 2000m);

            SBAccount account = bank.GetAccountDetails(3);
            Console.Write("Customer Name with AcountNumber 3 is: ");
            Console.WriteLine(account.Customername);
            
            Console.WriteLine();

            List<SBAccount> accounts = bank.GetAllAccounts();
            Console.WriteLine("All accounts details: ");
            foreach(SBAccount i in accounts){
                Console.WriteLine(i.Accountnumber + " " + i.Currentbalance + " " + i.Customeraddress + " " + i.Currentbalance);
            }

            Console.WriteLine();

            List<SBTransaction> transactions = bank.GetTransactions(1);
            Console.WriteLine("All transaction details of AccountNumber 1: ");
            foreach(SBTransaction i in transactions){
                Console.WriteLine(i.Transactionid + " " + i.Transactiondate + " " + i.Accountnumber + " " + i.Amount + " " + i.Transactiontype);
            }

        }
    } 
    
}
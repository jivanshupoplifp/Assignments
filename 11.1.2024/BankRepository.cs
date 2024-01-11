using System.Collections;
namespace Bank{
    public class BankRepository:IBankRepository{

        public int Tid = 0;
        public List<SBAccount> accounts = new List<SBAccount>();
        public List<SBTransaction> transactions = new List<SBTransaction>();
        public void NewAccount(SBAccount acc){
            accounts.Add(acc);
        }
        public List<SBAccount> GetAllAccounts(){
            return accounts;
        }
        public SBAccount GetAccountDetails(int accno){
            
            SBAccount ans = new SBAccount(1, "a", "a", 1m);
            foreach(SBAccount a in accounts){
                if(a.Accountnumber == accno){
                    ans = a;
                }
            }
            return ans;

        }

        public void DepositAmount(int accno, decimal amt){
            
            SBAccount ans = new SBAccount(1, "a", "a", 1m);
            foreach(SBAccount a in accounts){
                if(a.Accountnumber == accno){
                    a.Currentbalance += amt;
                }
            }

            int t = ++Tid;
            transactions.Add(new SBTransaction(t, DateTime.Now, ans.Accountnumber, amt, "Deposit"));

        }

        public void WithdrawAmount(int accno, decimal amt){

            SBAccount ans = new SBAccount(1, "a", "a", 1m);
            foreach(SBAccount a in accounts){
                if(a.Accountnumber == accno){
                    a.Currentbalance -= amt;
                    ans = a;
                }
            }

            int t = ++Tid;
            transactions.Add(new SBTransaction(t, DateTime.Now, ans.Accountnumber, amt, "Withdraw"));


        }

        public List<SBTransaction> GetTransactions(int accno){

            List<SBTransaction> ans = new List<SBTransaction>();
            foreach(SBTransaction i in transactions){
                if(i.Accountnumber == accno){
                    ans.Add(i);
                }
            }

            return ans;

        }

    }
}
namespace WebApplication_web_01.Models.Interface
{
    public interface BankService
    {
        string BankId { get; set; }
        string BankName { get; set; }
        int Deposit { get; set; }
        //存款 Deposit
        int Search_Deposit(string bankid);
    }
    public class A_Bank : BankService
    {
        public string BankId { get; set; }
        public string BankName { get; set; }
        public int Deposit { get; set; }

        public A_Bank()
        {
            BankId = "0093";
            BankName = "日日銀行";
            Deposit = 35;
        }

        public int Search_Deposit(string bankid)
        {
            return Deposit;
        }
    }
}

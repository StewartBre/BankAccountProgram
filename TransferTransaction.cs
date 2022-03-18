using System;

public class TransferTransaction : Transaction
{
    private Account _fromAccount;
    private Account _toAccount;
    private WithdrawTransaction _theWithdraw;
    private DepositTransaction _theDeposit;
  
    public override bool Success
    {
        get 
        {
            if (_theDeposit.Success && _theWithdraw.Success)
                return true;
            else
                return false;
        }
    }

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
    {
        _fromAccount = fromAccount;
        _toAccount = toAccount;
        _theWithdraw = new WithdrawTransaction(fromAccount, amount);
        _theDeposit = new DepositTransaction(toAccount, amount);
    }

    public override void Execute()
    {
        base.Execute();
        _theWithdraw.Execute();
        if (_theWithdraw.Success)
        {
            _theDeposit.Execute();
        
            if (!_theDeposit.Success)
            {
                _theWithdraw.Rollback();
                _executed = false;
            }
        }
        else
        {
            throw new Exception ("Cannot execute transaction! Withdraw Failed.");
        }
    }

    public override void Rollback()
    {
        base.Rollback();
        if(_theWithdraw.Success)
        {
            _theWithdraw.Rollback();
        }
        
        if(_theDeposit.Success)
        {
            _theDeposit.Rollback();
        }
    }
    
    public override void Print()
    {
        if (_theWithdraw.Success && _theDeposit.Success)
        {
            Console.WriteLine(" A transfer of" + _amount + " from " + _fromAccount.Name + "'s account to  " + _toAccount.Name + "'s account was successful. ");
            Console.Write("   ");
            _theDeposit.Print();
            Console.Write("   ");
            _theWithdraw.Print();         
        }
        else
        {
            Console.WriteLine("Transfer was not successful.");
            if (_reversed)
                Console.WriteLine("Transfer was reversed.");
        }
        
    }
    
}
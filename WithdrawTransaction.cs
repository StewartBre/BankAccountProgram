using System;
using SplashKitSDK;

public class WithdrawTransaction : Transaction
{
    private Account _account;
    private bool _success = false;
    public override bool Success
    {
        get 
        {
            return _success;
        }
    }

    public WithdrawTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Withdraw(_amount);
    }

    public override void Rollback()
    {
        base.Rollback();
       _success = _account.Deposit(_amount);
    }

     public override void Print()
    {   
        if( _success )
            Console.WriteLine("A withdraw of " + _amount + " from " + _account.Name + "'s account was successful. ");
            else
            {
                Console.WriteLine("Withdraw was not successful");
                if (_reversed)
                    Console.WriteLine("Withdraw was reversed");
            }

    }
}



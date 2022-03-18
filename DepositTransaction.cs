using System;
using SplashKitSDK;

public class DepositTransaction : Transaction
{
    private Account _account;
    private bool _success = false;
    
    
    public override bool  Success
   {
       get
       {
           return _success;
       }
   }

    public DepositTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
    }
    public override void Execute()
    {
        base.Execute();
        _success = _account.Deposit(_amount);
    }
     
    public override void Rollback()
    {
        base.Rollback();
       _success = _account.Withdraw(_amount);

    }
    
    public override void Print()
    {   
        if( _success )
            Console.Write("A deposit of " + _amount + " into " + _account.Name + "'s account was successful. ");
            else
            {
                Console.WriteLine("Deposit was not successful");
                if (_reversed)
                    Console.WriteLine("Deposit was reversed");
            }

    }

}



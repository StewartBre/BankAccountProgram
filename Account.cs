using System;

public class Account
{
   private decimal _balance;
   private string  _name;

  public Account(string name, decimal startingBalance)
  {
      _name = name;
      _balance = startingBalance;
  }
  public bool Deposit(decimal amountToAdd)
  {
      if (amountToAdd > 0)
      {
          _balance += amountToAdd;
          return true; 
      }
      return false;
  }

  public bool Withdraw(decimal amountToWithdraw)
  {
      if ((_balance > amountToWithdraw) && (amountToWithdraw > 0))
      {
          _balance = _balance - amountToWithdraw;
          return true;
      }
      return false;
  }
  public string Name
  {
     get {return _name;}
  }
  public void Print()
  {
     Console.WriteLine("The account name is " + _name + " and the balance is " + _balance);
  }
}
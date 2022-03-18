using System;
using SplashKitSDK;

public enum menuOption
{
    withdraw,
    deposit, 
    transfer,
    print,
    add_account,
    print_transactions,
    quit
}
public class program 
{

    public static void Main()
    {
        //Account  myAccount = new Account ("George", 2000.0M);
        //Account stewartaccount = new Account("Stewart", 3000.0M);
        Bank bank = new Bank();
        menuOption userSelection;
        do 
        {
            userSelection =readUserOption();
            switch (userSelection)
            {
                case menuOption.withdraw:
                {
                    doWithdraw(bank);
                    break;
                }
                case menuOption.deposit:
                {
                    doDeposit(bank);
                    break;
                }
                 case menuOption.transfer:
                {
                    doTransfer(bank);
                    break;
                }
                case menuOption.print:
                {
                    doPrint(bank);
                    break;
                }
                case menuOption.add_account:
                {
                    doAddAccount(bank);
                    break;
                }
                case menuOption.print_transactions:
                {
                    bank.PrintTransactionHistory();
                    break;
                }
                case menuOption.quit:
                {
                    Console.WriteLine("Quitting...");
                    break;
                }
            }
        } while (userSelection != menuOption.quit);
    }


 private static menuOption readUserOption()
 {
     int lastOption = 7;
     int option;
     Console.WriteLine($"Please select an option ranging from [1-{lastOption}]:");
     Console.WriteLine(".....");
     Console.WriteLine("1: Withdraw");
     Console.WriteLine("2: Deposit");
     Console.WriteLine("3: Transfer");
     Console.WriteLine("4: Print");
     Console.WriteLine("5: Add Account");
     Console.WriteLine("6: Print Transactions");
     Console.WriteLine("7: Quit");
     Console.WriteLine("......");

     do
     {
       try
       {
            option = Convert.ToInt32(Console.ReadLine());
       }
       catch (Exception ex)
       {
          Console.WriteLine("Exception: " + ex.Message);
          Console.WriteLine("There was a problem parsing your selection: ");
          option = -1;
       }
       if (option > lastOption || option <1)
       {
           Console.WriteLine($"Please select a number between 1 and {lastOption}: ");
       }
     }   while (option > lastOption || option < 1); 
     return (menuOption)(option - 1);
 }

 private static Account findAccount( Bank bank )
    {
        Console.Write("Enter account name: ");
        string name = Console.ReadLine();
        Account result = bank.GetAccount(name);

        if ( result == null )
        {
            Console.WriteLine($"No account found with the name {name}");
        }

        return result;
    }

  private static void doAddAccount(Bank bank)
  {
      Console.WriteLine("Please enter the account name: ");
      string accountName = Console.ReadLine();

      while (true)
      {
          try
          {
              Console.Write("Please enter the opening balance: ");
              decimal openingBalance = Convert.ToDecimal(Console.ReadLine());
          
              if (openingBalance < 0)
              {
                  throw new Exception("The opening balance must be greater than 0. Please try again! ");
              }

              Account newAccount = new Account(accountName, openingBalance);
              bank.AddAccount(newAccount);
              break;
          }
          catch (Exception ex)
          {
              Console.WriteLine(ex.Message);
          }
      }
  }

  private static void doWithdraw(Bank bank)
  {
      Account account = findAccount(bank);
      if (account == null) { return;}

      decimal amount;
      Console.WriteLine("Select how much you would like to withdraw? ");
      try
      {
          amount = Convert.ToDecimal(Console.ReadLine());
          WithdrawTransaction transaction = new WithdrawTransaction (account, amount);
          bank.ExecuteTransaction(transaction);
      }
      catch (Exception e)
      {
          Console.WriteLine(e.Message);
          Console.WriteLine("You must enter a decimal number!");
      }     
   } 

  private static void doDeposit(Bank bank)
  {
      Account account = findAccount(bank);
      if (account == null) { return;}

      decimal amount;
      Console.WriteLine("Select how much you would like to deposit? ");
      try
      {
          amount = Convert.ToDecimal(Console.ReadLine());
          DepositTransaction transaction = new DepositTransaction (account, amount);
          bank.ExecuteTransaction(transaction);
      }
      catch (Exception e)
      {
          Console.WriteLine(e.Message);
          Console.WriteLine("You must enter a decimal number!");
      } 
  }
   private static void doTransfer(Bank bank)
   {
       try
        {
            Account fromAccount = findAccount(bank);
            if (fromAccount == null) { return; }

            Account toAccount = findAccount(bank);
            if (toAccount == null) { return; }

            //if(fromAccount == toAccount) { throw new Exception("Same Account..."); }

            Console.WriteLine("How much would you like to transfer into " + toAccount.Name + " 's account? ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            TransferTransaction transferTransaction = 
            new TransferTransaction(fromAccount, toAccount, amount);

            try
            {
                bank.ExecuteTransaction(transferTransaction);
                if (!transferTransaction.Success)
                {
                    throw new Exception("Transfer was not succesfull ");

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }   
    }

    private static void doPrint(Bank bank)
    {
        Account account = findAccount(bank);
        if (account == null) { return; }
        account.Print();
    }
    
}

 // public class Program
 // {
 //     public static void Main()
 //     {
 //      Account account = new Account("Jakes Account", 200000);
 //      account.Print();

 //      account.Deposit(1000);
 //      account.Print();

 //      account.Withdraw(20000);
 //      account.Print();

 //      Account account1 = new Account("Stewart's Account", 100);
 //      account1.Print();

 //      account1.Deposit(1000);
 //      account1.Print();

 //      account1.Deposit(5000);
 //      account1.Print();

 //      account1.Withdraw(1000);
 //      account1.Print();

 //      account1.Withdraw(500);
 //      account1.Print();

     
 //     }


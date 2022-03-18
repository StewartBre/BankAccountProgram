using System;
using System.Collections.Generic;

public class Bank
{
    private List<Account> _accounts;
    private List<Transaction> _transactions;

    public Bank()
    {
        _accounts = new List<Account>();
        _transactions = new List<Transaction>();
    }

    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

    public Account GetAccount(string accountName)
    {
        foreach (Account acc in this._accounts)
        {
            if (acc.Name.ToLower().Trim() == accountName.ToLower().Trim())
                return acc;
        }

        return null;
    }

    public void ExecuteTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
        transaction.Execute();
    }

    public void PrintTransactionHistory()
    {
        foreach ( Transaction transaction in _transactions)
        {
            Console.Write(transaction.DateStamp + " :");
            transaction.Print();
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;

public class CardHolder
{
    private string cardNum;
    private int pin;
    private string firstName;
    private string lastName;
    private double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string GetCardNum() { return cardNum; }
    public int GetPin() { return pin; }
    public double GetBalance() { return balance; }
    public string GetFirstName() { return firstName; }
    public string GetLastName() { return lastName; }

    public void SetCardNum(string newCardNum) { cardNum = newCardNum; }
    public void SetPin(int newPin) { pin = newPin; }
    public void SetBalance(double newBalance) { balance = newBalance; }
    public void SetFirstName(string newName) { firstName = newName; }
    public void SetLastName(string newName) { lastName = newName; }

    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("Please select one of the following options...");
            Console.WriteLine("1) Deposit");
            Console.WriteLine("2) Withdraw");
            Console.WriteLine("3) Balance");
            Console.WriteLine("4) Exit");
        }

        void Deposit(CardHolder user)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine());
            user.SetBalance(user.GetBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your balance is now: " + user.GetBalance());
        }

        void Withdraw(CardHolder user)
        {
            Console.WriteLine("How much money would you like to withdraw?");
            double withdrawal = double.Parse(Console.ReadLine());

            if (user.GetBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                user.SetBalance(user.GetBalance() - withdrawal);
                Console.WriteLine("Have a great day!");
            }
        }

        void ShowBalance(CardHolder user)
        {
            Console.WriteLine("Your current balance is: " + user.GetBalance());
        }

        List<CardHolder> cardHolders = new List<CardHolder>
        {
            new CardHolder("1811318183181811", 1221, "John1", "Griffin", 150.4),
            new CardHolder("1811318183181812", 1222, "John2", "Griffin", 151.4),
            new CardHolder("1811318183181813", 1223, "John3", "Griffin", 152.4),
            new CardHolder("1811318183181814", 1224, "John4", "Griffin", 153.4),
            new CardHolder("1811318183181815", 1225, "John5", "Griffin", 154.4)
        };

        Console.WriteLine("Welcome to Your Favorite ATM");
        Console.WriteLine("Please insert your debit card:");
        string debitCardNum = "";
        CardHolder currentUser;

        while (true)
        {
            debitCardNum = Console.ReadLine();
            currentUser = cardHolders.FirstOrDefault(a => a.GetCardNum() == debitCardNum);

            if (currentUser != null)
            {
                break;
            }
            else
            {
                Console.WriteLine("Card is not recognized. Please try again.");
            }
        }

        Console.WriteLine("Enter Your PIN:");
        int userPin = 0;

        while (true)
        {
            userPin = int.Parse(Console.ReadLine());

            if (currentUser.GetPin() == userPin)
            {
                break;
            }
            else
            {
                Console.WriteLine("Incorrect PIN. Please try again.");
            }
        }

        Console.WriteLine("Welcome, " + currentUser.GetFirstName() + " :)");
        int option = 4;

        do
        {
            PrintOptions();

            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                option = 0;
            }

            if (option == 1) { Deposit(currentUser); }
            else if (option == 2) { Withdraw(currentUser); }
            else if (option == 3) { ShowBalance(currentUser); }
        }
        while (option != 4);

        Console.WriteLine("Have a wonderful day!");
    }
}

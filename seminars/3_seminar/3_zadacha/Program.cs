using System;

namespace ConsoleApp2
{
    class Account
    {
        // делегат void (string, int, int)
        public delegate void FinanceMove(string info, int a, int b);
        public event FinanceMove OnFinanceMove;
        public Account(int sum)
        {
            Sum = sum;
        }
        // сумма на счете
        public int Sum { get; private set; }
        // добавление средств на счет
        public void Put(int sum)
        {
            Sum += sum;
            OnFinanceMove?.Invoke("Put", Sum - sum, sum);
        }
        // списание средств со счета
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                OnFinanceMove?.Invoke("Take", Sum + sum, sum);
            }
            else
            {
                OnFinanceMove?.Invoke("TakeError", Sum, sum);
            }
        }

    }

    class Program
    {
        static void PrintInfo(string type, int a, int b)
        {
            Console.WriteLine($"{type} {b}; Баланс: {a}");
        }
        static void Main(string[] args)
        {

            Account acc = new Account(100);
            acc.OnFinanceMove += PrintInfo;
            acc.Put(20);    // добавляем на счет 20
            acc.Take(70);   // пытаемся снять со счета 70
            acc.Take(180);  // пытаемся снять со счета 180
            Console.Read();
        }
    }
}
using System;

//1. Реализовать шаблон «Одиночка» для многопоточной программы с использованием оператора lock.
//2. Реализовать шаблон «Одиночка» для многопоточной программы с использованием класса Lazy<T>.

public sealed class MySingleton
{
    #region Fields

    private static readonly Lazy<MySingleton> _instance =
        new Lazy<MySingleton>(() => new MySingleton());
    private static readonly object _lock = new object();

    #endregion


    #region ClassLifeCycle

    private MySingleton() {}

    #endregion


    #region Properties

    public static MySingleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance != null)
                {
                    return _instance.Value;
                }
                return _instance.Value;
            }
        }
    }

    #endregion


    #region Methods
    public void SayHello()
    {
        Console.WriteLine("Hello");
    }
    #endregion

}

class Program
{
    static void Main(string[] args)
    {
        MySingleton instanceOne = MySingleton.Instance;
        instanceOne.SayHello();
    }
}
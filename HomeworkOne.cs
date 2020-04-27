using System;
using System.Collections.Generic;

#region Задание 1
//1. Провести рефакторинг кода из раздела «Повторяющаяся логика»,
//применяя внедрение зависимостей к классу EntityBase.

#region Пример
//public abstract class EntityBase
//{
//    public long Id { get; private set; }

//    public EntityBase()
//    {
//        Id = CalculateId();
//    }

//    private long CalculateId()
//    {
//        long id = DateTime.Now.Ticks;
//        return id;
//    }
//}

//public class Customer : EntityBase
//{
//    public string Description { get; set; }

//    public Customer()
//    { }
//}

//public class Store : EntityBase
//{
//    public Store()
//    { }
//}
#endregion

public interface IIdGenerator
{
    long CalculateId();
}

public class DefaultIdGenerator : IIdGenerator
{
    public long CalculateId()
    {
        long id = DateTime.Now.Ticks;
        return id;
    }
}

public abstract class EntityBase
{
    private readonly IIdGenerator _idGenerator;
    public long Id { get; private set; }

    public EntityBase(IIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
        Id = _idGenerator.CalculateId();
    }
}
public class Customer : EntityBase
{
    public string Description { get; set; }

    public Customer(IIdGenerator idGenerator) : base(idGenerator)
    { }
}
public class Store : EntityBase
{
    public Store(IIdGenerator idGenerator) : base(idGenerator)
    { }
}

#endregion

#region Задание 2
//2. Реализовать программу из раздела «Повторяющиеся фрагменты кода» с помощью делегата Func.

#region Пример
//class Constants
//{
//    public static readonly string Address = "Москва, Россия";
//    public static readonly string Format = "{0} - {1}, адрес {2}, возраст {3}";
//}

//class Program
//{
//    public static readonly string Address = Constants.Address;
//    public static readonly string Format = Constants.Format;

//    private static void DummyFunc()
//    {
//        WriteToConsole("Петя", "школьный друг", 30);
//    }

//    private static void DummyFuncAgain()
//    {
//        WriteToConsole("Вася", "сосед", 54);
//    }

//    private static void DummyFuncMore()
//    {
//        WriteToConsole("Николай", "сын", 4);
//    }

//    private static string WriteToConsole(string name, string description,
//                                        int age)
//    {
//        string result = $"{name} - {description}, {Address}, {age}";
//        return result;
//    }

//    private static void MakeAction(Action action)
//    {
//        string methodName = action.Method.Name;
//        Console.WriteLine("Начало работы метода {0}", methodName);
//        action();
//        Console.WriteLine("Окончание работы метода {0}\n", methodName);
//    }

//    private static List<Action> GetActionSteps()
//    {
//        return new List<Action>()
//        {
//            DummyFunc,
//            DummyFuncAgain,
//            DummyFuncMore
//        };
//    }

//    static void Main(string[] args)
//    {
//        List<Action> actions = GetActionSteps();
//        foreach (var action in actions)
//        {
//            MakeAction(action);
//        }

//        Console.ReadLine();
//    }
//}
#endregion

class Constants
{
    public static readonly string Address = "Москва, Россия";
}

class Program
{
    public static readonly string Address = Constants.Address;
    private static readonly Func<string, string, int, string> Format = WriteToConsole;

    private static void DummyFunc()
    {
        Console.WriteLine(Format("Петя", "школьный друг", 30)); 
    }

    private static void DummyFuncAgain()
    {
        Console.WriteLine(Format("Вася", "сосед", 54)); 
    }

    private static void DummyFuncMore()
    {
        Console.WriteLine(Format("Николай", "сын", 4)); 
    }

    private static string WriteToConsole(string name, string description, int age)
    {
        string result = $"{name} - {description}; адрес {Address}; возраст {age}";
        return result;
    }

    private static void MakeAction(Action action)
    {
        string methodName = action.Method.Name;
        Console.WriteLine("Начало работы метода {0}", methodName);
        action();
        Console.WriteLine("Окончание работы метода {0}\n", methodName);
    }

    private static List<Action> GetActionSteps()
    {
        return new List<Action>()
        {
            DummyFunc,
            DummyFuncAgain,
            DummyFuncMore
        };
    }

    static void Main(string[] args)
    {
        List<Action> actions = GetActionSteps();
        foreach (var action in actions)
        {
            MakeAction(action);
        }

        Console.ReadLine();
    }
}

#endregion
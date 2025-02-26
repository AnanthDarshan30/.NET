using System;

// DLL read, CLR read.
public class Class1
{
    public void m1() => Console.WriteLine("M1");
}
public class Class2
{
    public void m2() => Console.WriteLine("M2");
}
public class Class3
{
    //void Class3() { }
    private Class1 obj1 = new Class1();
    private Class2 obj2 = new Class2();
    public void m1() => obj1.m1();
    public void m2() => obj2.m2();

}
class Program
{

    public static void Main(string[] args)
    {
        Class3 mainObj = new Class3();
        mainObj.m1();
        Console.ReadLine();
    }
}


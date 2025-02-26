using System;

public class Person
{
	//var person;
	int age;
	public Person(int age)
	{
		this.age = age;
	}
	Person() { }
	public static void Main(string[] args)
	{

		Person obj = new Person();
		Person obj1 = new Person(18);
		Console.WriteLine(obj1.age);

		Console.ReadLine();
	}
}


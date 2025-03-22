using System;

class Student : Person
{
	//(重複的不用寫)
	//public string name;
	//public int age;
	public string school;
	public Student(string name, int age, string school)
	{
		this.name = name;
		this.age = age;
		this.school = school;
	}
}

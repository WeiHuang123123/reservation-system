// namespace (分類管理) using
// namespace Animal
//{
	class Person
	{
		public double height;
		public int age;
		public string name;

		public void sayHi()
		{
			Console.WriteLine("你好我是 " + name);
		}

		//public void isAdult()
		//{
		//	if (age >= 18)
		//	{
		//		Console.WriteLine("我已成年" + "我" + age + "歲");
		//	}
		//	else
		//	{
		//		Console.WriteLine("我未成年" + "我" + age + "歲");
		//	}
		//}
		public bool IsAdult(int age)
		{
			if (age < 18)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public void PrintAge() 
		{
			Console.WriteLine(this.age);
		}
		public void PrintName()
		{
			Console.WriteLine(this.name);
		}

}
//}

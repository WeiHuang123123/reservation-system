// Class.Object 類別物件

//Person person1 = new Person();
//person1.height = 187.5;
//person1.age = 22;
//person1.name = "惡魔之戀";

//System.Console.WriteLine(person1.height);
//System.Console.WriteLine(person1.age);
//System.Console.WriteLine(person1.name);

//Person person2 = new Person();
//person2.height = 170;
//person2.age = 18;
//person2.name = "惡魔之颯";

//System.Console.WriteLine(person2.height);
//System.Console.WriteLine(person2.age);
//System.Console.WriteLine(person2.name);


// namespace (分類管理) using(使用模組，之後就不用一直引用)
// method(自訂方法-動作)
//using Animal;
//using System;
//Person person1 = new Person();
//Person person2 = new Person();
//person1.height = 187.5;
//person1.age = 22;
//person1.name = "惡魔之戀";
//person1.sayHi();


//person2.height = 187.5;
//person2.age = 16;
//person2.name = "惡魔之颯";
//person2.sayHi();

// main() C#預設框架
//class program
//{
//    static void Main()
//    {

//    }
//}

//  constructor(建構方法)
//class Program
//{
//    public double height;
//    public int age;
//    public string name;
//    class Person
//    {
//        public double height;
//        public int age;
//        public string name;

//        public Person(double h, int a, string N) {
//        height = h;
//        age = a;
//        string name = N; 
//        }

//    }
//    static void Main(double h, int a, string N)
//    {
//        Person person1 = new Person(187.5,22,"惡魔之戀");
//    }
//}

// getter setter (限制屬性)
using System;
Video video1 = new Video("我要快樂", "阿妹", "音樂");
Video video2 = new Video("康熙來了", "康&熙", "娛樂");
Video video3 = new Video("柴仔翻肚", "柴仔", "惡魔");

//Console.WriteLine(video1.Type);
//Console.WriteLine(video2.Type);
//Console.WriteLine(video3.Type);

// static attribute(靜態屬性)
// 因為屬於class本身 所以必須要前面加上class名稱
//Console.WriteLine(Video.counter);
// 用video1(物件)取得counter
//Console.WriteLine(video1.getVideoCount());

//static method /static class(靜態方法/類別)
//靜態方法是屬於類別本身
//靜態類別是無法創建物件

//繼承
Student student1 = new Student("惡魔之戀", 22, "市大同");
Console.WriteLine(student1.school);
student1.PrintAge();

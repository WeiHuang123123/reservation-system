////  "資料型態"
//char last = '黃';         //char用單引
//string first = "柏崴";
//string name = "黃柏崴";    //string用雙引
////如果不用 Tostring()  char會變成 Unicode相加
//System.Console.WriteLine(last.ToString()  + ' ' + first + "=" + name);


////  "Input格式"
//用Write不會換行(WriteLine會) vs  ReadLine是讀整行(Read只讀一個字)
//System.Console.Write("請輸入名字 : ");
//string name = System.Console.ReadLine();
////要計算只能用 input string ->(轉換) Int32/Double
//System.Console.Write("請輸入年紀 : ");
//int age = System.Convert.ToInt32(System.Console.ReadLine());
//System.Console.Write("請輸入身高 : ");
//double tall = System.Convert.ToDouble(System.Console.ReadLine());
//System.Console.Write(tall + "公分的" + name );
//double round_tall = System.Math.Round(tall);
//System.Console.Write("明年你就是大約 " + round_tall + "公分高 " + (age + 1) + "歲"
//    + "的" + name + "了!");


////  "Array"
//int[] score = { 10, 20, 30, 40, 50 };
//score[0] = 30000;
//System.Console.Write(score);
//// 建空陣列
//string[] phones = new string[10];
//phones[0] = "12";
//phones[1] = "22";
////[法一] 使用 for 迴圈
//for (int i = 0; i < score.Length; i++)
//    {
//        System.Console.WriteLine(score[i]);
//    }
//
// [法二] 使用 foreach 迴圈來顯示陣列中的每個元素
//foreach (int s in score)
//{
//    System.Console.Write(s + " ");
//}
// [法三] 使用 string.Join 方法來將陣列元素轉換成一個字串
//string result = string.Join(" ", score);
//System.Console.Write(result);

////  "If-else"
//System.Console.Write("請輸入第一個數字 : ");
//double num1 = System.Convert.ToDouble(System.Console.ReadLine());

//System.Console.Write("請輸入運算子 : ");
//string oper = System.Console.ReadLine();

//System.Console.Write("請輸入第二個數字 : ");
//double num2 = System.Convert.ToDouble(System.Console.ReadLine());

//System.Console.Write("答案為: ");
//if (oper == "*") 
//{
//    System.Console.WriteLine(num1*num2);  
//}
//else if(oper == "/") 
//{ 
//    System.Console.WriteLine(num1 / num2); 
//}
//else if (oper == "+") 
//{ 
//    System.Console.WriteLine(num1 + num2); 
//}
//else if (oper == "-") 
//{ 
//    System.Console.WriteLine(num1 - num2); 
//}

////  "while Loop" 
//第一種:會先判斷
//int n = 2;
//while (n <= 4) 
//{
//    System.Console.WriteLine(n);
//    n++;  // n=n+1的C版本
//}
//第二種:do-while:先做一次再判斷
//int n = 2;
//do
//{
//    System.Console.WriteLine(n);
//    n++;  // n=n+1的C版本
//}
//while (n <= 6);

////  "for Loop"
//  for (起始值;停止條件;迭代規則)
//for (int i = 1; i <= 5; i++) 
//{
//    System.Console.Write(i);
//}

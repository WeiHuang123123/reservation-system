using System;

public class Video
{
	public string title;
	public string author;
	private string type;
	//[限制]影片有四個類別: 教育/娛樂/音樂/其他
	//1.原本改成private
	//2.創新的public裝get set
	//3.原本的public屬性欄 左邊要改成public版

	public static int counter = 0;
	//加計數器:
	//1.創public static 的變數
	//2.在Video裡寫 counter++

	public Video(string title, string author, string type)
	{
		this.title = title;
		this.author = author;
		Type = type;
		counter++;
	}

	public int getVideoCount() { return counter; }

	public string Type // type的對外代理人 (public Type)
	{
		get {  return type; }
		set {
			if (value=="教育"||value=="娛樂"|| value=="音樂")
			{
				type = value;
			}
			else
			{
				type = "其他";
			}
		}
	}
}

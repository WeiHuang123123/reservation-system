using System;

namespace ReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=ReservationSystem;Uid=root;Pwd=ben0503";
            UserManager userManager = new UserManager(connectionString);
            ReservationManager reservationManager = new ReservationManager(connectionString);

            Console.WriteLine("1. 註冊");
            Console.WriteLine("2. 登入");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("請輸入使用者名稱:");
                string username = Console.ReadLine();
                Console.WriteLine("請輸入密碼:");
                string password = Console.ReadLine();
                bool isRegistered = userManager.RegisterUser(username, password);
                Console.WriteLine(isRegistered ? "註冊成功!" : "註冊失敗!");
            }
            else if (choice == 2)
            {
                Console.WriteLine("請輸入使用者名稱:");
                string username = Console.ReadLine();
                Console.WriteLine("請輸入密碼:");
                string password = Console.ReadLine();
                bool isValid = userManager.ValidateUser(username, password);
                if (isValid)
                {
                    Console.WriteLine("登入成功！");
                    bool exit = false;
                    while (!exit)
                    {
                        Console.WriteLine("\n請選擇一個選項:");
                        Console.WriteLine("1. 新增預約");
                        Console.WriteLine("2. 顯示所有預約");
                        Console.WriteLine("3. 更新預約狀態");
                        Console.WriteLine("4. 退出");

                        string optionInput = Console.ReadLine();
                        int option;
                        if (int.TryParse(optionInput, out option))
                        {
                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("請輸入使用者名稱:");
                                    string user = Console.ReadLine();
                                    Console.WriteLine("請輸入預約時間 (yyyy-mm-dd hh:mm):");
                                    DateTime reservationTime;
                                    if (DateTime.TryParse(Console.ReadLine(), out reservationTime))
                                    {
                                        reservationManager.AddReservation(user, reservationTime);
                                    }
                                    else
                                    {
                                        Console.WriteLine("無效的日期格式，請重試。");
                                    }
                                    break;
                                case 2:
                                    reservationManager.DisplayReservations();
                                    break;
                                case 3:
                                    Console.WriteLine("請輸入預約ID:");
                                    string input = Console.ReadLine();
                                    int reservationId;
                                    if (int.TryParse(input, out reservationId))
                                    {
                                        Console.WriteLine("請輸入新的狀態 (Pending, Confirmed, Canceled):");
                                        string newStatus = Console.ReadLine();
                                        reservationManager.UpdateReservationStatus(reservationId, newStatus);
                                    }
                                    else
                                    {
                                        Console.WriteLine("輸入的預約ID無效，請輸入數字。");
                                    }
                                    break;
                                case 4:
                                    exit = true;
                                    break;
                                default:
                                    Console.WriteLine("無效的選項，請重試。");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("請輸入有效的數字選項。");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("登入失敗！");
                }
            }
        }
    }
}

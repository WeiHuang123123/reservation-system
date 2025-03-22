using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ErrorAnalysisSystem
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public class StudentAnswer
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager(string connString)
        {
            connectionString = connString;
        }

        public void RecordStudentAnswer(StudentAnswer answer)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO StudentAnswers 
                              (StudentId, QuestionId, Answer, IsCorrect) 
                              VALUES (@StudentId, @QuestionId, @Answer, @IsCorrect)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", answer.StudentId);
                    command.Parameters.AddWithValue("@QuestionId", answer.QuestionId);
                    command.Parameters.AddWithValue("@Answer", answer.Answer);
                    command.Parameters.AddWithValue("@IsCorrect", answer.IsCorrect);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Dictionary<int, int> GetErrorCountByQuestion()
        {
            var errorCounts = new Dictionary<int, int>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = @"SELECT QuestionId, COUNT(*) as ErrorCount 
                              FROM StudentAnswers 
                              WHERE IsCorrect = 0 
                              GROUP BY QuestionId";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int questionId = reader.GetInt32("QuestionId");
                            int errorCount = reader.GetInt32("ErrorCount");
                            errorCounts[questionId] = errorCount;
                        }
                    }
                }
            }
            return errorCounts;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string connString = "server=localhost;user=your_username;password=your_password;database=error_analysis_db;";
            var dbManager = new DatabaseManager(connString);

            while (true)
            {
                Console.WriteLine("1. 輸入學生答案");
                Console.WriteLine("2. 查看錯題統計");
                Console.WriteLine("3. 退出");
                Console.Write("請選擇操作: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InputStudentAnswer(dbManager);
                        break;
                    case "2":
                        ShowErrorStatistics(dbManager);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("無效的選擇，請重試。");
                        break;
                }
            }
        }

        static void InputStudentAnswer(DatabaseManager dbManager)
        {
            Console.Write("請輸入學生ID: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("請輸入題目ID: ");
            int questionId = int.Parse(Console.ReadLine());
            Console.Write("請輸入學生答案: ");
            string answer = Console.ReadLine();
            Console.Write("答案是否正確 (Y/N): ");
            bool isCorrect = Console.ReadLine().ToUpper() == "Y";

            var studentAnswer = new StudentAnswer
            {
                StudentId = studentId,
                QuestionId = questionId,
                Answer = answer,
                IsCorrect = isCorrect
            };

            dbManager.RecordStudentAnswer(studentAnswer);
            Console.WriteLine("答案已記錄。");
        }

        static void ShowErrorStatistics(DatabaseManager dbManager)
        {
            var errorCounts = dbManager.GetErrorCountByQuestion();
            Console.WriteLine("錯題統計：");
            foreach (var kvp in errorCounts)
            {
                Console.WriteLine($"題目ID: {kvp.Key}, 錯誤次數: {kvp.Value}");
            }
        }
    }
}
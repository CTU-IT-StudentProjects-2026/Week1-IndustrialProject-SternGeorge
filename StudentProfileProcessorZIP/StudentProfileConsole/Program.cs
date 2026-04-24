using System;

namespace StudentProfileConsole
{
    class Program
    {
        // Global scope variable (accessible to all methods in class)
        static string institution = "Kitumaini Digital Solutions";

        static void Main(string[] args)
        {
            Console.Title = "Smart Student Profile Processor";
            Console.WriteLine($"Welcome to {institution}\n");

            // Local variables inside Main
            string studentName;
            int studentAge;
            double module1Score, module2Score, module3Score;

            // Input with validation
            Console.Write("Enter student name: ");
            studentName = Console.ReadLine();

            studentAge = GetValidAge();

            Console.WriteLine("\n--- Enter Module Scores (0-100) ---");
            module1Score = GetValidScore("Module 1");
            module2Score = GetValidScore("Module 2");
            module3Score = GetValidScore("Module 3");

            // Calculate readiness using different overloaded methods
            double average1 = CalculateReadiness(module1Score, module2Score);
            double average2 = CalculateReadiness(module1Score, module2Score, module3Score);
            string readinessLevel = GetReadinessLevel(average2);

            // Display formatted output
            DisplayStudentProfile(studentName, studentAge, module1Score, module2Score, module3Score, average2, readinessLevel);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Method to validate age (positive integer, typical student age range)
        static int GetValidAge()
        {
            int age;
            while (true)
            {
                Console.Write("Enter student age: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out age) && age >= 0)
                    break;
                Console.WriteLine("Invalid age. Please enter a valid non-negative integer.");
            }
            return age;
        }

        // Method to validate score (0-100)
        static double GetValidScore(string moduleName)
        {
            double score;
            while (true)
            {
                Console.Write($"{moduleName} score: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out score) && score >= 0 && score <= 100)
                    break;
                Console.WriteLine("Invalid score. Must be between 0 and 100.");
            }
            return score;
        }

        // Method overloading: CalculateReadiness for two modules
        static double CalculateReadiness(double score1, double score2)
        {
            // Local variable to method
            double sum = score1 + score2;
            return sum / 2; // average
        }

        // Overloaded method: CalculateReadiness for three modules
        static double CalculateReadiness(double score1, double score2, double score3)
        {
            double sum = score1 + score2 + score3;
            return sum / 3;
        }

        // Determine readiness level based on average score
        static string GetReadinessLevel(double average)
        {
            // Using ternary operator and logical operators
            if (average >= 75)
                return "Ready";
            else if (average >= 50)
                return "Partially Ready";
            else
                return "Not Ready";
        }

        // Display formatted profile
        static void DisplayStudentProfile(string name, int age, double m1, double m2, double m3, double avg, string level)
        {
            Console.WriteLine("\n========== STUDENT PROFILE ==========");
            Console.WriteLine($"Institution : {institution}");
            Console.WriteLine($"Student Name: {name.ToUpper()}");
            Console.WriteLine($"Age         : {age}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Module Scores:");
            Console.WriteLine($"  Module 1   : {m1:F2}");
            Console.WriteLine($"  Module 2   : {m2:F2}");
            Console.WriteLine($"  Module 3   : {m3:F2}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Average Score : {avg:F2}");
            Console.WriteLine($"Readiness Level: {level}");
            // Type casting example: converting double to int for display
            Console.WriteLine($"Rounded Average (int): {(int)avg}");
            // Increment operator example (just for demonstration)
            int counter = 0;
            Console.WriteLine($"Demo counter++: {counter++} then {counter}");
            Console.WriteLine("======================================");
        }
    }
}
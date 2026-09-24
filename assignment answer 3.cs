using System;

namespace Assignment4
{
    // =========================================================================
    // Structs and Enums Definitions for the Assignment
    // =========================================================================

    // Question 1 (Enum: WeekDays)
    public enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    // Question 2 & Question 7 (Struct: Person)
    public struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    // Question 3 (Enum: Season)
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    // Question 4 (Enum Flags: Permissions)
    [Flags]
    public enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }

    // Question 5 (Enum: Colors)
    public enum Colors
    {
        Red,
        Green,
        Blue
    }

    // Question 6 (Struct: Point)
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point p)
        {
            return Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // =========================================================================
            // PART 1: FUNCTIONS
            // =========================================================================

            // =========================================================================
            // Question 1 (Functions): Passing Value Type Parameters by Value vs by Reference
            // Explanation:
            // - By Value: A copy of the value is passed. Changes inside the function do NOT affect the original variable.
            // - By Reference (ref): A reference to the original variable is passed. Changes inside the function DO affect the original variable.
            // =========================================================================
            Console.WriteLine("----- Functions - Question 1 -----");
            int val1 = 10;
            int val2 = 10;

            PassValueTypeByValue(val1);
            PassValueTypeByRef(ref val2);

            Console.WriteLine($"Original val1 (Passed by Value): {val1}"); // Output: 10
            Console.WriteLine($"Original val2 (Passed by Ref):   {val2}"); // Output: 200

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 2 (Functions): Passing Reference Type Parameters by Value vs by Reference
            // Explanation:
            // - By Value: Passes a copy of the reference pointer. Modifying the object's state affects the original object, but reassigning 'new' inside the function does NOT affect the original pointer.
            // - By Reference (ref): Passes the reference pointer itself. Reassigning 'new' inside the function WILL replace the original object reference.
            // =========================================================================
            Console.WriteLine("----- Functions - Question 2 -----");
            Person pVal = new Person("Ahmed", 20);
            Person pRef = new Person("Ahmed", 20);

            PassRefTypeByValue(pVal);
            PassRefTypeByRef(ref pRef);

            Console.WriteLine($"pVal Name (Passed by Value, reassigned inside): {pVal.Name}"); // Output: Ahmed
            Console.WriteLine($"pRef Name (Passed by Ref, reassigned inside):   {pRef.Name}"); // Output: Reassigned Person

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 3 (Functions): Summation and Subtracting of 2 numbers using 4 parameters
            // =========================================================================
            Console.WriteLine("----- Functions - Question 3 -----");
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            SumAndSubtract(num1, num2, out double sumResult, out double subResult);
            Console.WriteLine($"Summation = {sumResult}");
            Console.WriteLine($"Subtraction = {subResult}");

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 4 (Functions): Sum of individual digits of a given number
            // =========================================================================
            Console.WriteLine("----- Functions - Question 4 -----");
            Console.Write("Enter a number: ");
            int digitNum = int.Parse(Console.ReadLine());
            int sumDigits = CalculateDigitsSum(digitNum);
            Console.WriteLine($"The sum of the digits of the number {digitNum} is: {sumDigits}");

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 5 (Functions): IsPrime function
            // =========================================================================
            Console.WriteLine("----- Functions - Question 5 -----");
            Console.Write("Enter a number to check prime: ");
            int primeInput = int.Parse(Console.ReadLine());
            Console.WriteLine($"Is {primeInput} prime? {IsPrime(primeInput)}");

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 6 (Functions): MinMaxArray using ref parameters
            // =========================================================================
            Console.WriteLine("----- Functions - Question 6 -----");
            int[] numbersArray = { 12, 5, 23, 8, 45, 2, 19 };
            int minVal = 0, maxVal = 0;
            MinMaxArray(numbersArray, ref minVal, ref maxVal);
            Console.WriteLine($"Array Elements: {string.Join(", ", numbersArray)}");
            Console.WriteLine($"Minimum Value = {minVal}");
            Console.WriteLine($"Maximum Value = {maxVal}");

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 7 (Functions): Iterative (non-recursive) Factorial
            // =========================================================================
            Console.WriteLine("----- Functions - Question 7 -----");
            Console.Write("Enter a number to calculate factorial: ");
            int factNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"Factorial of {factNum} is: {FactorialIterative(factNum)}");

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 8 (Functions): ChangeChar function
            // =========================================================================
            Console.WriteLine("----- Functions - Question 8 -----");
            Console.Write("Enter a original string: ");
            string originalStr = Console.ReadLine();
            Console.Write("Enter character position (0-based): ");
            int pos = int.Parse(Console.ReadLine());
            Console.Write("Enter new character: ");
            char newChar = Console.ReadLine()[0];

            string modifiedStr = ChangeChar(originalStr, pos, newChar);
            Console.WriteLine($"Modified String: {modifiedStr}");

            Console.WriteLine("\n=========================================================================\n");

            // =========================================================================
            // PART 2: ENUM AND STRUCT
            // =========================================================================

            // =========================================================================
            // Question 1 (Enum & Struct): Print all WeekDays enum members
            // =========================================================================
            Console.WriteLine("----- Enum & Struct - Question 1 -----");
            Console.WriteLine("Days of the week:");
            foreach (var day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 2 (Enum & Struct): Array of 3 Person objects
            // =========================================================================
            Console.WriteLine("----- Enum & Struct - Question 2 -----");
            Person[] persons = new Person[3];
            persons[0] = new Person("Ahmed", 21);
            persons[1] = new Person("Mohamed", 25);
            persons[2] = new Person("Saeed", 30);

            Console.WriteLine("Displaying Person Details:");
            foreach (var p in persons)
            {
                Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 3 (Enum & Struct): Season Enum and Month Range
            // =========================================================================
            Console.WriteLine("----- Enum & Struct - Question 3 -----");
            Console.Write("Enter season name (Spring, Summer, Autumn, Winter): ");
            string seasonInput = Console.ReadLine();

            if (Enum.TryParse<Season>(seasonInput, true, out Season selectedSeason))
            {
                string range = selectedSeason switch
                {
                    Season.Spring => "March to May",
                    Season.Summer => "June to August",
                    Season.Autumn => "September to November",
                    Season.Winter => "December to February",
                    _ => "Unknown"
                };
                Console.WriteLine($"Corresponding month range: {range}");
            }
            else
            {
                Console.WriteLine("Invalid Season Name Entered!");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 4 (Enum & Struct): Enum Permissions (Add, Remove, Check)
            // =========================================================================
            Console.WriteLine("----- Enum & Struct - Question 4 -----");
            Permissions userPermissions = Permissions.Read | Permissions.Write;
            Console.WriteLine($"Initial Permissions: {userPermissions}");

            // Add Permission (Execute)
            userPermissions |= Permissions.Execute;
            Console.WriteLine($"After Adding 'Execute': {userPermissions}");

            // Remove Permission (Write)
            userPermissions &= ~Permissions.Write;
            Console.WriteLine($"After Removing 'Write': {userPermissions}");

            // Check if specific permission exists (Read)
            bool hasRead = (userPermissions & Permissions.Read) == Permissions.Read;
            Console.WriteLine($"Is 'Read' permission existed? {hasRead}");

            // Check if specific permission exists (Write)
            bool hasWrite = userPermissions.HasFlag(Permissions.Write);
            Console.WriteLine($"Is 'Write' permission existed? {hasWrite}");

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 5 (Enum & Struct): Colors Enum (Primary Color Check)
            // =========================================================================
            Console.WriteLine("----- Enum & Struct - Question 5 -----");
            Console.Write("Enter color name: ");
            string colorInput = Console.ReadLine();

            if (Enum.TryParse<Colors>(colorInput, true, out Colors parsedColor))
            {
                Console.WriteLine($"{parsedColor} is a Primary Color.");
            }
            else
            {
                Console.WriteLine($"{colorInput} is NOT a Primary Color.");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 6 (Enum & Struct): Point Struct and Distance Calculation
            // =========================================================================
            Console.WriteLine("----- Enum & Struct - Question 6 -----");
            Console.Write("Enter Point 1 (X Y): ");
            string[] pt1Parts = Console.ReadLine().Split();
            Point point1 = new Point(double.Parse(pt1Parts[0]), double.Parse(pt1Parts[1]));

            Console.Write("Enter Point 2 (X Y): ");
            string[] pt2Parts = Console.ReadLine().Split();
            Point point2 = new Point(double.Parse(pt2Parts[0]), double.Parse(pt2Parts[1]));

            double distance = point1.DistanceTo(point2);
            Console.WriteLine($"Distance between points = {distance:F2}");

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // =========================================================================
            // Question 7 (Enum & Struct): Oldest Person among 3 Persons
            // =========================================================================
            Console.WriteLine("----- Enum & Struct - Question 7 -----");
            Person[] inputPersons = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter Name and Age for Person {i + 1} (e.g. Ali 25): ");
                string[] pParts = Console.ReadLine().Split();
                inputPersons[i] = new Person(pParts[0], int.Parse(pParts[1]));
            }

            Person oldest = inputPersons[0];
            for (int i = 1; i < 3; i++)
            {
                if (inputPersons[i].Age > oldest.Age)
                {
                    oldest = inputPersons[i];
                }
            }
            Console.WriteLine($"Oldest Person: {oldest.Name}, Age: {oldest.Age}");

            Console.WriteLine("\n=========================================================================");
            Console.WriteLine("End of Assignment 4");
            Console.WriteLine("=========================================================================");

            Console.ReadLine(); // Keeps console window open
        }

        // =========================================================================
        // Helper Functions Definitions
        // =========================================================================

        // Q1 Function Helpers
        static void PassValueTypeByValue(int x)
        {
            x = 200;
        }

        static void PassValueTypeByRef(ref int x)
        {
            x = 200;
        }

        // Q2 Function Helpers
        static void PassRefTypeByValue(Person p)
        {
            p = new Person("Reassigned Person", 99);
        }

        static void PassRefTypeByRef(ref Person p)
        {
            p = new Person("Reassigned Person", 99);
        }

        // Q3 Function Helper
        static void SumAndSubtract(double a, double b, out double sum, out double sub)
        {
            sum = a + b;
            sub = a - b;
        }

        // Q4 Function Helper
        static int CalculateDigitsSum(int number)
        {
            int sum = 0;
            number = Math.Abs(number);
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        // Q5 Function Helper
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Q6 Function Helper
        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            if (arr == null || arr.Length == 0) return;
            min = arr[0];
            max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
            }
        }

        // Q7 Function Helper
        static long FactorialIterative(int number)
        {
            if (number < 0) return -1; // Invalid input
            long fact = 1;
            for (int i = 1; i <= number; i++)
            {
                fact *= i;
            }
            return fact;
        }

        // Q8 Function Helper
        static string ChangeChar(string str, int index, char newChar)
        {
            if (string.IsNullOrEmpty(str) || index < 0 || index >= str.Length)
                return str;

            char[] chars = str.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
    }
}
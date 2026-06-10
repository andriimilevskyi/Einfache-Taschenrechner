using System;

public class Program
{
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 10));
        Console.WriteLine("EINFACHE TASCHENRECHNER");
        Console.WriteLine("MILEVSKYI");
        Console.WriteLine(new string('-', 10));
        Console.ResetColor();


        while (true)
        {
            try
            {
                double number1, number2;
                number1 = ParseDoubleInput("Geben Sie erste Zahl");
                number2 = ParseDoubleInput("Geben Sie zweite Zahl");

                var _operator = ParceOperationInput();

                double result = Calculate(number1, number2, _operator);

                Console.WriteLine($"Result: {result}");



                Console.WriteLine("\nSPACE = nochmal, ESC = beenden");

                while (true)
                {
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.Spacebar)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\n--- Neue Berechnung ---\n");
                        Console.ResetColor();
                        break; //repeat
                    }

                    if (key == ConsoleKey.Escape) return; //end
                }
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine($"Fehler {ex.Message}.  Versuche erneut.\n\n");
                }
            }


            static double ParseDoubleInput(string message)
            {
                while (true)
                {
                    Console.WriteLine(message);
                    var input = Console.ReadLine();

                    if (double.TryParse(input, out var value))
                        return value;

                    Console.WriteLine("Fehler: Bitte gültige Zahl eingeben!");
                }
            }



            static string ParceOperationInput()
            {
                while (true)
                {
                    Console.Write("Operation wählen (+, -, *, /): ");
                    var value = Console.ReadLine();

                    if (value == "+" || value == "-" || value == "*" || value == "/")
                        return value;

                    Console.WriteLine("Ungültige Operation!");
                }
            }


            static double Calculate(double number1, double number2, string _operator)
            {
                switch (_operator)
                {
                    case "+": return number1 + number2;
                    case "-": return number1 - number2;
                    case "*": return number1 * number2;

                    case "/":
                        if (number2 == 0)
                        {
                            Console.WriteLine("Fehler: Division durch 0!");
                            throw new DivideByZeroException();
                        }

                        return number1 / number2;

                    default:
                        throw new Exception("Ungültige Operation!");
                }
            }
        }
    }
}
namespace KalkulatorApp

{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayProgramHeader();
            RunCalculatorMenu();

            DisplayProgramAuthorInfo();
        }

        static void DisplayProgramHeader()
        {
            Console.WriteLine(
     "\n\t\t\tCALCULATOR PROGRAM allows calculating the values of selected mathematical quantities");

        }

        static void RunCalculatorMenu()
        {
            ConsoleKeyInfo selectedOption;

            do
            {
                DisplayMainMenu();
                selectedOption = Console.ReadKey();
                Console.WriteLine();

                switch (selectedOption.Key)
                {
                    case ConsoleKey.A:
                        RunLaboratoryCalculator();
                        break;
                    case ConsoleKey.B:
                        RunIndividualCalculator();
                        break;
                    case ConsoleKey.X:
                        break;
                    default:
                        DisplayInvalidOptionMessage();
                        break;
                }
            } while (selectedOption.Key != ConsoleKey.X);
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("\n\t\tMAIN MENU");
            Console.WriteLine("\t\tA. Laboratory Calculator");
            Console.WriteLine("\t\tB. Individual Calculator");
            Console.WriteLine("\t\tX. Exit the program");
            Console.Write("\n\t\tPress one of the allowed keys (A, B, X) to select an option: ");
        }


        static void DisplayInvalidOptionMessage()
        {
            Console.WriteLine("\n\t\tERROR: You pressed an invalid key!");
            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }


        static void DisplayProgramAuthorInfo() // Information about the author.
        {
            Console.WriteLine("\n\n\t\tProgram Author: Naraikivskyi_Mykhailo");
            Console.WriteLine("\t\tToday's Date: {0}", DateTime.Now);
            Console.Write("\n\t\tPress any key to continue...");
            Console.ReadKey();
        }


        static void RunLaboratoryCalculator() // KALKULATOR LABORATORYJNY.
        {
            ConsoleKeyInfo selectedFunction;
            List<string> history = new List<string>();

            do
            {
                DisplayLaboratoryMenu();
                selectedFunction = Console.ReadKey();
                Console.WriteLine();

                switch (selectedFunction.Key)
                {
                    case ConsoleKey.A:
                        CalculateAverage(history); // Obliczenie sredniej artmetycznej wyrazow ciagu liczbowego.
                        break;
                    case ConsoleKey.B:
                        CalculatePolynomial(history); // Obliczenie wartosci wielomianu n-tego stopnia.
                        break;
                    case ConsoleKey.C:
                        ConvertToNeg(history); // Konwersja znakowego zapisu liczby naturalnej na wartosc.
                        break;
                    case ConsoleKey.D:
                        CalculatingValueOfNewtonsSymbol(history); // Obliczenie wartosci symbolu Newtona.
                        break;
                    case ConsoleKey.X:
                        OutputFromCalculator(history); // Historia kalkulatora przy wyjscie.
                        break;
                    default:
                        DisplayIndividualMenu();
                        break;
                }

                Console.Write("\n\t\tPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (selectedFunction.Key != ConsoleKey.X);
        }
        static void DisplayLaboratoryMenu()
        {
            Console.WriteLine("\n\t\tLABORATORY CALCULATOR MENU");
            Console.WriteLine("\t\tA. Calculate arithmetic mean");
            Console.WriteLine("\t\tB. Calculate polynomial value");
            Console.WriteLine("\t\tC. Convert string representation of a number to a numeric value");
            Console.WriteLine("\t\tD. Calculate Newton's binomial coefficient");
            Console.WriteLine("\t\tX. Exit Laboratory Calculator");
            Console.Write("\n\t\tPress an allowed key (A, B, C, D, X): ");
        }
        static void OutputFromCalculator(List<string> history) // Historia dwóch kalkulatorów
        {
            Console.WriteLine("\n\t\tCalculation history:");
            if (history.Count == 0)
            {
                Console.WriteLine("\t\tHistory is empty.");
            }
            else
            {
                foreach (var entry in history)
                {
                    Console.WriteLine("\t\t" + entry);
                }
            }
        }

        static void CalculatingValueOfNewtonsSymbol(List<string> history)
        {
            try
            {
                Console.WriteLine("\n\t\tYou selected: D - Calculate Newton's binomial coefficient");
                Console.Write("\t\tEnter n: ");
                double n = double.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("\t\tEnter k: ");
                double k = double.Parse(Console.ReadLine());
                Console.WriteLine();

                // Validate input
                if (k > n)
                {
                    Console.WriteLine("\t\tError: k cannot be greater than n.");
                    return;
                }

                if (n < 0 || k < 0)
                {
                    Console.WriteLine("\t\tError: n and k must be non-negative numbers.");
                    return;
                }

                double result = Factorial(n) / (Factorial(k) * Factorial(n - k));
                history.Add("Newtone value from cof k = " + k + " and n = " + n + " result = " + result);
                Console.WriteLine("\t\tResultat: " + result);
            }
            catch (FormatException)
            {
                Console.WriteLine("\t\tError: Please enter valid numeric values for n and k.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("\t\tError: The number is too large to calculate.");
            }
        }

        static double Factorial(double num)
        {
            if (num <= 1) return 1;
            return num * Factorial(num - 1);
        }

   


        static void CalculateAverage(List<string> history)
        {
            Console.WriteLine("\n\t\tYou selected: A - Calculate arithmetic mean");
            Console.WriteLine("\n\t\tEnter numbers: ");
            double[] numbers = ReadArrayFromConsole();
            double average = numbers.Average();
            history.Add("Z tablicy" + string.Join(", ", numbers) + "srednie " + average);
            Console.WriteLine("Średnia: " + average);
        }


        static void CalculatePolynomial(List<string> history) //Polynomial
        {
            Console.WriteLine("\n\t\tYou selected: B - Calculate polynomial value");
            Console.WriteLine("\n\t\tEnter coefficients: ");
            double[] coefficients = ReadArrayFromConsole();

            Console.WriteLine("Enter the polynomial argument: ");
            double x = Convert.ToDouble(Console.ReadLine());

            double result = EvaluatePolynomial(coefficients, x);
            history.Add("Z tablicy " + string.Join(", ", coefficients) + "wielomian " + result);
            Console.WriteLine("Wartość wielomianu: " + result);
        }

        static void DisplayNotImplementedMessage()
        {
            Console.WriteLine("\n\t\tSORRY, but I'm in the process of implementation);");
        }

        static double EvaluatePolynomial(double[] coefficients, double x)
        {
            double result = coefficients[0];
            for (int i = 1; i < coefficients.Length; i++)
            {
                result = result * x + coefficients[i];
            }
            return result;
        }


        static void ConvertToNeg(List<string> history)
        {
            Console.WriteLine("\n\t\tYou selected: C - Convert string representation of a number to a numeric value");
            Console.WriteLine("Enter the value: ");

            double value = double.Parse(Console.ReadLine() ?? string.Empty);
            if (value <= 0)
            {
                Console.WriteLine(value);
                return;
            }

            Console.WriteLine(-value);
            history.Add("Negative Value from " + value + " to " + -value);
        }

        static double[] ReadArrayFromConsole()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    // Check for empty input
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("\t\tError: Input cannot be empty. Please try again.");
                        continue;
                    }

                    // Parse and validate numbers
                    return input
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s =>
                        {
                            if (!double.TryParse(s, out double number))
                            {
                                throw new FormatException($"Invalid number: {s}");
                            }
                            return number;
                        })
                        .ToArray();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"\t\tError: {ex.Message}. Please enter valid numbers.");
                }
            }
        }

        static void DisplayIndividualMenu()
        {
            Console.WriteLine("\n\t\tINDIVIDUAL CALCULATOR MENU");
            Console.WriteLine("\t\tA. Calculate harmonic mean");
            Console.WriteLine("\t\tB. Calculate quadratic mean");
            Console.WriteLine("\t\tC. Calculate power mean (generalized mean)");
            Console.WriteLine("\t\tD. Calculate geometric mean");
            Console.WriteLine("\t\tE. Calculate weighted average price");
            Console.WriteLine("\t\tF. Convert a number between numeral systems");
            Console.WriteLine("\t\tG. Calculate the sum of a number sequence");
            Console.WriteLine("\t\tX. Exit Individual Calculator");
            Console.Write("\n\t\tPress an allowed key (A, B, C, D, E, F, G, X): ");
        }



        static void RunIndividualCalculator() // MENU Indywidualnego Kalkulatora
        {
            ConsoleKeyInfo selectedFunction;
            List<string> history = new List<string>();
            do
            {
                DisplayIndividualMenu();
                selectedFunction = Console.ReadKey();
                Console.WriteLine();

                switch (selectedFunction.Key)
                {
                    case ConsoleKey.A:
                        CalcHarmonicMean(history); // Calculation of the harmonic mean of the terms in the number sequence
                        break;
                    case ConsoleKey.B:
                        CalcQuadraticMean(history); // Calculation of the quadratic mean of the terms in the number sequence
                        break;
                    case ConsoleKey.C:
                        CalcPowerMean(history); // Calculation of the power mean of the terms in the number sequence
                        break;
                    case ConsoleKey.D:
                        CalcGeometricMean(history); // Calculation of the geometric mean of the terms in the number sequence
                        break;
                    case ConsoleKey.E:
                        CalcWAP(history); // Calculation of the unit price of feed . . .
                        break;
                    case ConsoleKey.F:
                        ConvertBase(history); // Conversion of the string representation of a natural number in a numerical system . . .
                        break;
                    case ConsoleKey.G:
                        CalculateSequenceSum(history); // Calculation of the sum of a sequence of numbers
                        break;
                    case ConsoleKey.X:
                        OutputFromCalculator(history); // Calculator history on exit
                        break;
                    default:
                        DisplayInvalidOptionMessage();
                        break;
                }

                Console.Write("\n\t\tPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (selectedFunction.Key != ConsoleKey.X);

        }

        static void ConvertBase(List<string> history)
        {
            try
            {
                Console.WriteLine("\n\t\tYou selected functionality: F. Convert a number from one numeral system to another");
                Console.Write("\n\t\tEnter the number: ");
                string input = Console.ReadLine();

                Console.WriteLine("Enter the base P (input): ");
                int baseP = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the base Q (output): ");
                int baseQ = Convert.ToInt32(Console.ReadLine());

                // Comprehensive input validation
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("\n\t\tError: Number input cannot be empty.");
                    return;
                }

                if (baseP < 2 || baseP > 32 || baseQ < 2 || baseQ > 32)
                {
                    Console.WriteLine("\n\t\tError: Bases must be in the range from 2 to 32!");
                    return;
                }

                // Validate input number against its base
                if (!IsValidNumberInBase(input, baseP))
                {
                    Console.WriteLine($"\n\t\tError: Invalid number {input} for base {baseP}");
                    return;
                }

                int decemial = Convert.ToInt32(input, baseP);
                string result = Convert.ToString(decemial, baseQ);
                history.Add("Result: " + result + " in Q " + baseQ + " and P " + baseP);
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\t\tError: Invalid input. Please check your number and bases.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\t\tError: Number is too large to convert.");
            }
        }
        // Helper method to validate number in a specific base
        static bool IsValidNumberInBase(string number, int baseP)
        {
            string validChars = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
            return number.ToUpper().All(c => validChars.IndexOf(c) < baseP);
        }

        static void CalcWAP(List<string> history)
        {
            Console.WriteLine("\n\t\tYou selected functionality: E. Calculation of the unit price of feed . . .");
            Console.WriteLine("Enter the prices per unit: ");
            double[] prices = ReadArrayFromConsole();

            Console.WriteLine("Enter the weights per unit: ");
            double[] weights = ReadArrayFromConsole();

            if (prices.Length != weights.Length || (prices.Length == 0 || weights.Length == 0))
            {
                Console.WriteLine("Invalid input data.");
                return;
            }

            double totalPrice = 0;
            double totalWeight = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                totalPrice += prices[i] * weights[i];
                totalWeight += weights[i];
            }
            history.Add("From the array of prices " + string.Join(", ", prices) + ", total price is " + totalPrice +
                        ", from the array of weights " + string.Join(", ", weights) +
                        ", total weight is " + totalWeight +
                        ", weighted average price is " + totalPrice / totalWeight + "\n");

            Console.WriteLine("Total Price: " + totalPrice);
            Console.WriteLine("Total Weight: " + totalWeight);
            Console.WriteLine("Weighted Average Price: " + totalPrice / totalWeight);
        }


        static void CalcHarmonicMean(List<string> history)
        {
            Console.WriteLine("\n\t\tYou selected functionality: A. Calculation of the harmonic mean of the terms in the number sequence");
            Console.WriteLine("Enter the values: ");
            double[] numbers = ReadArrayFromConsole();
            if (numbers.Length == 0)
            {
                Console.WriteLine("Insufficient number of values, harmonic mean calculation is not possible.");
                return;
            }

            double sum = 0.0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += 1.0 / numbers[i];
            }

            double harmonicMean = numbers.Length / sum;
            history.Add("From the array " + string.Join(", ", numbers) + " the harmonic mean is " + harmonicMean + "\n");
            Console.WriteLine("Mean: " + harmonicMean);
        }



        static void CalcGeometricMean(List<string> history)
        {
            Console.WriteLine("\n\t\tYou selected functionality: D. Calculation of the geometric mean of the terms in the number sequence");
            Console.WriteLine("Enter the values: ");
            double[] numbers = ReadArrayFromConsole();
            if (numbers.Length == 0)
            {
                Console.WriteLine("Insufficient number of values, geometric mean calculation is not possible.");
                return;
            }

            double geometricMean = Math.Pow(numbers.Aggregate(1.0, (a, b) => a * b), 1.0 / numbers.Length);
            history.Add("From the array " + string.Join(", ", numbers) + " the geometric mean is " + geometricMean + "\n");
            Console.WriteLine("Mean: " + geometricMean);
        }

        static void CalcPowerMean(List<string> history)
        {
            Console.WriteLine("\n\t\tYou selected functionality: C. Calculation of the power mean of the terms in the number sequence");
            Console.WriteLine("Enter the values: ");
            double[] numbers = ReadArrayFromConsole();

            if (numbers.Length == 0)
            {
                Console.WriteLine("Insufficient number of values, power mean calculation is not possible.");
                return;
            }

            Console.WriteLine("Enter the exponent (p): ");
            double p = double.Parse(Console.ReadLine());

            double powerMean = Math.Pow(numbers.Average(x => Math.Pow(Math.Abs(x), p)), 1.0 / p);

            history.Add("From the array " + string.Join(", ", numbers) + " Power Mean (p=" + p + ") is " + powerMean + "\n");
            Console.WriteLine("Power Mean: " + powerMean);
        }

        static void CalcQuadraticMean(List<string> history)
        {
            Console.WriteLine("\n\t\tYou selected functionality: B. Calculation of the quadratic mean of the terms in the number sequence");
            Console.WriteLine("\n\t\tEnter the numbers: ");
            double[] numbers = ReadArrayFromConsole();
            if (numbers.Length == 0)
            {
                Console.WriteLine("Insufficient number of values, quadratic mean calculation is not possible.");
                return;
            }

            double quadraticMean = Math.Sqrt(numbers.Average(x => x * x));

            history.Add("From the array " + string.Join(", ", numbers) + " Quadratic Mean is " + quadraticMean + "\n");
            Console.WriteLine("Quadratic Mean: " + quadraticMean);
        }

        static void CalculateSequenceSum(List<string> history)
        {
            Console.WriteLine("\n\t\tYou selected functionality: G. Calculation of the sum of a sequence of numbers");
            Console.Write("\n\t\tEnter n (number): ");
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            List<int> sequence = new List<int>();

            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                    sequence.Add(i);
                }
            }
            if (n <= 0)
            {
                Console.WriteLine("Invalid value provided. Please enter a number greater than zero.");
                return;
            }

            string sequenceStr = string.Join(" + ", sequence);
            history.Add($"For n={n}, the sequence sum {sequenceStr} = {sum}");

            Console.WriteLine($"\n\t\tSequence: {sequenceStr}");
            Console.WriteLine($"\t\tSequence Sum: {sum}");
        }

    }


}

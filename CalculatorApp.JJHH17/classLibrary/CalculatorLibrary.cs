namespace classLibrary;
using System.Diagnostics; // Used for logging

class Calculator
{

    private int useQuantity { get; set; } = 0;

    public Calculator()
    {
        StreamWriter logFile = File.CreateText("calculator.log");
        Trace.Listeners.Add(new TextWriterTraceListener(logFile));
        Trace.AutoFlush = true;
        Trace.WriteLine("Starting the calculator log");
        Trace.WriteLine(String.Format("Starts {0}", System.DateTime.Now.ToString()));

        // Tracking the number of uses of the calculator
    }

    public double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

        // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = num1 + num2;
                Trace.WriteLine(String.Format("{0} + {1} = {2}", num1, num2, result));
                useQuantity++;
                break;
            case "s":
                result = num1 - num2;
                Trace.WriteLine(String.Format("{0} - {1} = {2}", num1, num2, result));
                useQuantity++;
                break;
            case "m":
                result = num1 * num2;
                Trace.WriteLine(String.Format("{0} * {1} = {2}", num1, num2, result));
                useQuantity++;
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                if (num2 != 0)
                {
                    result = num1 / num2;
                    Trace.WriteLine(String.Format("{0} / {1} = {2}", num1, num2, result));
                    useQuantity++;
                }
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }

    // Method allowing us to call how many times the calculator is used
    public string getUsageQuantity()
    {
        Trace.WriteLine($"Calculator used {useQuantity} times");
        return $"Calculator used {useQuantity} times";
    }
}

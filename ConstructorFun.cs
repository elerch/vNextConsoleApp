using System;
using System.Collections.Generic;

namespace vNextConsoleApp
{

    /* Cut feature!
    class PrimaryConstructors(double latitude, double longitude)
    {
        public double Latitude {get;} = latitude;
        public double Longitude {get;} = longitude;
    }
    */
    internal class CSharpSixFun
    {

        public Action<string> WriteLine { get; } // "getter-only autoproperties" No set! That implies a private readonly backing field
        public string Message { get; } = "Hello world"; // "auto-property initializers" and if we want  a default value...

        public Dictionary<int, string> Versions { get; }

        // "string interpolation" - no more string.format! Note that this syntax has changed since this old and busted version of VS...
        // it would now be written as $" from C# {Versions[6]"
        // See https://roslyn.codeplex.com/discussions/570614 for more information
        public void DoIt() => WriteLine(Message + " from C# \{Versions[6]}"); // "expression-bodied function members" - Define method using a lambda

        public void PassInAMessage(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message)); // "nameof" allows easier refactoring
            WriteLine(message);
        }

        public CSharpSixFun(Action<string> writeLine)
        {
            WriteLine = writeLine; // note this is ok even without a private set.

            // We can even set specific values in a dictionary that we define up front
            Versions = new Dictionary<int, string>  // "index initializers"
            {
                [1] = "one",
                [6] = "6 and the Roslyn compiler, run with kre!",
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };

            // Cut feature - declaration expressions
            // var succeeded = int.TryParse("42", out var result)
            // if (succeeded) Console.WriteLine("The result is \{result}");

            // not shown: await in catch/finally
            // not shown: parameterless constructors in structs
        }
    }
}
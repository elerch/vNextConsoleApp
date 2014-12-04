using System;
using System.Console; // "using static": umm...using a class? 

namespace vNextConsoleApp
{
    public class Program
    {
        public void Main(string[] args)
        {
            var fun = new CSharpSixFun(WriteLine); // using System.Console means we can skip Console here...
            fun.DoIt();
            try {
                fun.PassInAMessage(null);
            }
            catch (ArgumentNullException ex) if (ex.ParamName == "somethingelse")
            { // exception filters
                // Do something with this
            }
            catch (ArgumentNullException ex) if (ex.ParamName == "message")
            {
                WriteLine("This is what an exception filter *actually* looks like");  // again, no need for Console.WriteLine
            }
            // null conditional operators: no NRE! If the tree doesn't have left values, we don't care!
            WriteLine("The value of the third node on the left is: \{(new Tree()?.Left?.Left?.Left?.Value ?? "empty")}");
            ReadLine();
        }

        private class Tree
        {
            public Tree Right { get; set; }
            public Tree Left { get; set; }

            public string Value { get; set; }
        }
    }
}

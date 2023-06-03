using System;

namespace TragicTheReckoning.Views
{
    public class View
    {

        public void RenderPhaseLabel(Type phase)
        {
            Console.Clear();
            Console.WriteLine($"\nCurrent Phase: {phase.Name}");
        }
    
        public void RenderPhaseExit(Type phase)
        {
            Console.WriteLine($"\n{phase.Name} has finished!\nPRESS ANY KEY TO CONTINUE");
            Console.ReadLine();
        }

        protected void RenderExitWithInput(string msg)
        {
            Console.WriteLine($"\n{msg}\nPRESS ANY KEY TO CONTINUE");
            Console.ReadLine();
        }
        
        protected bool GetTreatedBooleanInput(string msg)
        {
            string treatedInput = " ";
            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.Write($"{msg} [Y/N]: ");
                string untreatedInput = Console.ReadLine();
                
                // Checking if the string is empty or not
                if (untreatedInput != null)
                    untreatedInput = untreatedInput.ToUpper().Trim();
                else
                {
                    Console.WriteLine("Sorry the input is not valid. Let's try again.");
                    continue;
                }
                
                // Checking if the input is valid or not
                isInputValid = (untreatedInput.Equals("Y") || untreatedInput.Equals("N"));
                if (!isInputValid)
                    Console.WriteLine("Sorry the input is not valid. Let's try again.");
                else
                    treatedInput = untreatedInput;
            }
            return treatedInput.Equals("Y");
        }
    }
}
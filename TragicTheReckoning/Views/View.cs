using System;

namespace TragicTheReckoning.Views
{
    public class View
    {

        public void  RenderPhaseLabel(Type phase, ConsoleColor nameColor = ConsoleColor.Cyan)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("\nCurrent Phase: ");
            Console.ForegroundColor = nameColor;
            Console.WriteLine($"{phase.Name}");
            Console.BackgroundColor = 0;
            Console.ForegroundColor = ConsoleColor.White;
        }
    
        public void RenderPhaseExit(Type phase)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            RenderExitWithInput($"{phase.Name} has finished!");
            Console.BackgroundColor = 0;
            Console.ForegroundColor = ConsoleColor.White;
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
                    RenderInvalidInputMsg();
                    continue;
                }
                
                // Checking if the input is valid or not
                isInputValid = (untreatedInput.Equals("Y") || untreatedInput.Equals("N"));
                if (!isInputValid)
                    RenderInvalidInputMsg();
                else
                    treatedInput = untreatedInput;
            }
            return treatedInput.Equals("Y");
        }

        private void RenderInvalidInputMsg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry the input is not valid. Let's try again.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
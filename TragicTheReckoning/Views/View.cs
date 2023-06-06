using System;

namespace TragicTheReckoning.Views
{
    public abstract class View
    {

        public void RenderPhaseLabel(int round, Type phase, ConsoleColor nameColor = ConsoleColor.Cyan)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write($"\nRound ({round}) | Current Phase: ");
            Console.ForegroundColor = nameColor;
            Console.WriteLine($"{phase.Name}");
            Console.BackgroundColor = 0;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RenderPhaseExit(Type phase)
        {
            RenderExitWithInput($"{phase.Name} has finished! ",
                ConsoleColor.Yellow, ConsoleColor.DarkGray);
        }
        
        public void RenderExitWithInput(string msg = "", 
            ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = 0)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine($"\n{msg}PRESS ENTER TO CONTINUE");
            Console.ReadLine();
            Console.BackgroundColor = 0;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string GetValidStringInput(string msg)
        {
            string input = "";
            while (true)
            {
                Console.Write(msg);
                string untreatedInput = Console.ReadLine();
                if (untreatedInput != null && ! untreatedInput.Equals(string.Empty))
                {
                    input = untreatedInput.Trim();
                    break;
                }
                else RenderInvalidInputMsg();
            }
            return input;
        }
        
        protected bool GetTreatedBooleanInput(string msg)
        {
            string treatedInput = " ";
            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.Write($"{msg} [y/n]: ");
                string untreatedInput = Console.ReadLine();
                
                // Checking if the string is neither empty nor null
                if (untreatedInput != null && ! untreatedInput.Equals(string.Empty))
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

        public void RenderInvalidInputMsg(string msg = "Sorry the input is not valid. Let's try again.")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ClearScreen()
        {
            Console.Clear();
        }
        
    }
}
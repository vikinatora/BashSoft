using BashSoft.Contracts;
using System;

namespace BashSoft
{
    public class InputReader:IReader
    {
        private const string endCommand = "quit";
        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.GetCurrentDirectoryPath()}> ");
                string input = Console.ReadLine().Trim();
                if (input.Equals(endCommand))
                {
                    break;
                }
                this.interpreter.InterpretCommand(input);
            }
        }
    }
}

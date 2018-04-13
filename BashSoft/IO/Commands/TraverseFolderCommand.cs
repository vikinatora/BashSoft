using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("ls")]
    public class TraverseFolderCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public TraverseFolderCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (base.Data.Length == 1)
            {
               this.inputOutputManager.TraverseDirectory(0);
            }
            else if (base.Data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(base.Data[1], out depth);
                if (hasParsed)
                {
                    this.inputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
            }
            else
            {
                throw new InvalidCommandException(base.Input);
            }
        }
    }
}

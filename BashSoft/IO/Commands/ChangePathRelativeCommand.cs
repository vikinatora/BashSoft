using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using System.Reflection;

namespace BashSoft.IO.Commands
{
    [Alias("cdrel")]
    public class ChangePathRelativeCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangePathRelativeCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (base.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string relPath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}

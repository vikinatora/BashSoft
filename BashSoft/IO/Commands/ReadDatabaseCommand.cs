using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("readdb")]
    public class ReadDatabaseCommand : Command
    {
        [Inject]
        private StudentsRepository repository;

        public ReadDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (base.Data.Length != 2)
            {
                throw new InvalidCommandException(base.Input);
            }

            string fileName = base.Data[1];
            this.repository.LoadData(fileName);
        }
    }
}

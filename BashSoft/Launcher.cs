using BashSoft.Contracts;

namespace BashSoft
{
    class Launcher
    {
        static void Main()
        {
            Tester tester = new Tester();
            IDirectoryManager ioManger = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManger);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
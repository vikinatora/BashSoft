using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("help")]
    public class GetHelpCommand : Command
    {

        public GetHelpCommand(string input, string[] data)
            : base(input, data)
        {
        }


        public override void Execute()
        {
            if (base.Data.Length != 1)
            {
                throw new InvalidCommandException(base.Input);   
            }

            OutputWriter.WriteMessageOnNewLine($"{new string('_', 123)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "change directory - changeDirREl:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "change directory - changeDir:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -121}|", "get help – help"));
            OutputWriter.WriteMessage($"{new string('_', 123)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0,98|", "display data entitites - display student/courses ascending/descending"));
            OutputWriter.WriteEmptyLine();
        }
    }
}

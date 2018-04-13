using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.IO.Commands
{
    [Alias("show")]
    public class ShowCourseCommand : Command
    {
        [Inject]
        private StudentsRepository repository;

        public ShowCourseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (base.Data.Length == 2)
            {
                string courseName = base.Data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
            }
            else if (base.Data.Length == 3)
            {
                string courseName = base.Data[1];
                string username = base.Data[2];
                this.repository.GetStudentScoresFromCourse(courseName, username);
            }
            else
            {
                throw new InvalidCommandException(base.Input);
            }
        }
    }
}

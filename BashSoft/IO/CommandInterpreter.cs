using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using System;
using System.Linq;
using System.Reflection;

namespace BashSoft
{
    public class CommandInterpreter:IInterpreter
    {
        private Tester judge;
        private StudentsRepository repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0].ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }

        }

        private IExecutable ParseCommand(string input, string[] data, string command)
        {

            object[] parametersForConstruction = new object[]
            {
                input,data
            };

            var typeOfCommand = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                                .Where(atr => atr.Equals(command))
                                .ToArray().Length > 0);

            var typeOfInterpreter = typeof(CommandInterpreter);

            var exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            var fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var fieldsOfInterpreter = typeOfInterpreter.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                var atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));

                if(atrAttribute!=null)
                {
                    if(fieldsOfInterpreter.Any(x=>x.FieldType==fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(exe, fieldsOfInterpreter.First(x => x.FieldType == fieldOfCommand.FieldType).GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}

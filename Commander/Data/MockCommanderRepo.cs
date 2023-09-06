using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommand()
        {
            var command = new List<Command>
            {
                new Command { ID = 1, HowTo = "one Two", Line = "blabla2", Platform = "IDKK" },
                new Command { ID = 2, HowTo = "one Three", Line = "blabla3", Platform = "IDKKK" },
                new Command { ID = 3, HowTo = "one Four", Line = "blabla4", Platform = "IDKKKK" },
                new Command { ID = 4, HowTo = "one Five", Line = "blabla5", Platform = "IDKKKKK" },
        };
            return command;
        }

        public Command GetCommandByID(int id)
        {
            return new Command { ID = 1, HowTo = "one Two", Line = "blabla", Platform = "IDK" };

        }

        public bool SaveChnage()
        {
            throw new NotImplementedException();
        }

        public bool SaveChnages()
        {
            throw new NotImplementedException();
        }

        public Command UpdateCommand(int id)
        {
            throw new NotImplementedException();
        }

        public Command UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}

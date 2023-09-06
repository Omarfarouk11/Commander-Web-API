using Commander.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Commander.Data
{
    public class SQLCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;
        public SQLCommanderRepo(CommanderContext commander) 
        { 
         
            _context = commander;
        }

        public void CreateCommand(Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
         

            _context.commands.Add(command);
            

        }

        public IEnumerable<Command> GetAllCommand()
        {
            return _context.commands.ToList();
        }

        public Command GetCommandByID(int id)
        {
           
            return _context.commands.FirstOrDefault(c => c.ID == id);
        }

        public bool SaveChnage()
        {
            return Convert.ToBoolean(_context.SaveChanges());
        }

        public Command UpdateCommand(Command command)
        {
            _context.commands.Update(command);
            return command;
            
        }
    }
}

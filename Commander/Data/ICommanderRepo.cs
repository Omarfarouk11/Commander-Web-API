using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool SaveChnage();
        IEnumerable<Command> GetAllCommand();
        Command GetCommandByID(int id);
        void CreateCommand(Command command);
        Command UpdateCommand(Command command);

    }
}

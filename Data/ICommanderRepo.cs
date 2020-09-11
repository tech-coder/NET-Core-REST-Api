using System.Collections.Generic;
using CommanderMine.Models;

namespace CommanderMine.Data
{
   public interface ICommanderRepo
    {
        public IEnumerable<Command> getAllCommands();

        public Command getCommandById(int Id);

        void createCommand(Command cmd);

        void updateCommand(Command cmd);

        void DeleteCommand(Command cmd);

        bool saveChanges();
        
    }
}
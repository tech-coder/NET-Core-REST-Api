using System.Collections.Generic;
using System.Linq;
using CommanderMine.Models;
using System;

namespace CommanderMine.Data
{
    class SqlCommander : ICommanderRepo
    {
        public CommanderContext _context { get; }
        public SqlCommander(CommanderContext cxt)
        {
            _context = cxt;
        }

        public IEnumerable<Command> getAllCommands()
        {
            return _context.CommandMine.ToList();
        }

        public Command getCommandById(int Id)
        {
            return _context.CommandMine.FirstOrDefault<Command>(p => p.Id == Id);
        }

        public void createCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _context.Add(cmd);
            }
            // _context.Add(cmd);
        }

        public bool saveChanges()
        {
            var res = _context.SaveChanges();
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void updateCommand(Command cmd)
        {
            // throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            _context.CommandMine.Remove(cmd);
        }
    }
}
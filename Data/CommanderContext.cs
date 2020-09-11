using CommanderMine.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderMine.Data
{
    class CommanderContext :DbContext
     {
         public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
         {
             
         }

         public DbSet<Command> CommandMine  { get; set; }
    }
}
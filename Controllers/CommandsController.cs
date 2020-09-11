using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommanderMine.Data;
using CommanderMine.Dtos;
using CommanderMine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CommanderMine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repoObj;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _repoObj = repo;
            _mapper = mapper;
        }


        //GET  api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandRead>> getCommands()
        {
            var commandItems = _repoObj.getAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandRead>>(commandItems));
        }

        //GET  api/commands/{id}
        [HttpGet("{id}", Name = "getCommands")]
        public ActionResult<CommandRead> getCommands(int Id)
        {
            var commandItems = _repoObj.getCommandById(Id);
            if (commandItems == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandRead>(commandItems));
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<Command> createCommand(CommandCreate cmd)
        {
            Command createCmd = _mapper.Map<Command>(cmd);
            _repoObj.createCommand(createCmd);
            var res = _repoObj.saveChanges();
            // sends uri in location header to accesss the current resource 
            return CreatedAtRoute("getCommands", new { Id = createCmd.Id }, createCmd);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult updateCommand(int id, CommandUpdate cmdUpdate)
        {
            var cmdObj = _repoObj.getCommandById(id);
            if (cmdObj == null)
            {
                return NotFound();
            }
            _mapper.Map(cmdUpdate, cmdObj);
            _repoObj.updateCommand(cmdObj);
            _repoObj.saveChanges();
            return NoContent();
        }

        //PATCH api/commands/{id}
         [HttpPatch("{id}")]
        public ActionResult partialUpdateCommand(int id,JsonPatchDocument<CommandUpdate> patchDoc)
        {
            var cmdObj = _repoObj.getCommandById(id);
            if (cmdObj == null)
            {
                return NotFound();
            }
          var cmdToPatch = _mapper.Map<CommandUpdate>(cmdObj);
          patchDoc.ApplyTo(cmdToPatch,ModelState);
           if (!TryValidateModel(cmdToPatch)){
               return ValidationProblem();
           }
           _mapper.Map(cmdToPatch,cmdObj);
            _repoObj.updateCommand(cmdObj);
            _repoObj.saveChanges();
            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult deleteCommand(int id){
             var cmdObj = _repoObj.getCommandById(id);
            if (cmdObj == null)
            {
                return NotFound();
            }

            _repoObj.DeleteCommand(cmdObj);
            _repoObj.saveChanges();
            return NoContent();
        }

    }
}

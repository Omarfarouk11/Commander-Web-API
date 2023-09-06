using AutoMapper;
using Azure;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo commanderRepo,IMapper mapper) 
        {
            _commanderRepo = commanderRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCommands()
        {
            var command=_commanderRepo.GetAllCommand();
            var result = _mapper.Map<IEnumerable<CommandReadDto>>(command);
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetCommandByID(int id)
        {

            var command=_commanderRepo.GetCommandByID(id);
          var result =  _mapper.Map<CommandReadDto>(command);
            if(result == null)
            {
                return NotFound($" The ID :{id} Not Found");
            }
            return Ok(result);

        }
        [HttpPost]
        public IActionResult Createcommand(CommandCreateDto command)
        {
            var result =_mapper.Map<Command>(command);
            _commanderRepo.CreateCommand(result);
            _commanderRepo.SaveChnage();
            return Ok(result);
       
        }
        [HttpPut("{id}")]
        public IActionResult Updatecommand(UpdateCommandDto commandDto,int id)
        {
            var fincommand = _commanderRepo.GetCommandByID(id);
            if(fincommand == null)
            {
                return BadRequest("xxxx");
            }
            var result=_mapper.Map(commandDto,fincommand);
            _commanderRepo.UpdateCommand(result);
            _commanderRepo.SaveChnage();
            return Ok(result);


        }
        [HttpPatch("{id}")]
        public IActionResult UpdatePartial(int id,JsonPatchDocument<UpdateCommandDto> commandpatch) {


            var fincommand = _commanderRepo.GetCommandByID(id);
            if (fincommand == null)
            {
                return BadRequest("xxxx");
            }
            var result = _mapper.Map<UpdateCommandDto>(fincommand);
            commandpatch.ApplyTo(result);
           var result2= _mapper.Map(result,fincommand);
            _commanderRepo.UpdateCommand(result2);
            _commanderRepo.SaveChnage();

           

            return Ok(result2);

        }
    }
}

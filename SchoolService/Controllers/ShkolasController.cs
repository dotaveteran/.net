using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolService.Data;
using SchoolService.Dtos;
using SchoolService.Models;
using SchoolService.SyncDataServices.Http;

namespace SchoolService.Controllers
{
    [Route("api/[controller]") ]
    [ApiController]    
    public class ShkolasController : ControllerBase
    {
        
        private readonly IShkolaRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public ShkolasController(
            IShkolaRepo repository,
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShkolaReadDto>> GetShkolas()
        {
            Console.WriteLine("--> Getting Shkolas....");
            
            var shkolaItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<ShkolaReadDto>>(shkolaItem));
        }
    

        [HttpGet("{id}", Name = "GetShkolaById")]
        public ActionResult<ShkolaReadDto> GetShkolaById(int id)
        {
            var shkolaItem = _repository.GetShkolaById(id);
            if(shkolaItem != null)
            {
                return Ok(_mapper.Map<ShkolaReadDto>(shkolaItem));    
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ShkolaReadDto>> CreateShkola(ShkolaCreateDto shkolaCreateDto)
        {
            var shkolaModel = _mapper.Map<Shkola>(shkolaCreateDto);
            _repository.CreateShkola(shkolaModel);
            _repository.SaveChanges();

            var ShkolaReadDto = _mapper.Map<ShkolaReadDto>(shkolaModel);

            try
            {
                await _commandDataClient.SendShkolaToCommand(ShkolaReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetShkolaById), new {Id = ShkolaReadDto.Id}, ShkolaReadDto);
        }
    }
}
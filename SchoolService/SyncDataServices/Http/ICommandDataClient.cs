using SchoolService.Dtos;

namespace SchoolService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendShkolaToCommand(ShkolaReadDto plat);
    }
}
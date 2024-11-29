using BSS_Backend_Opgave.Repositories.Models.Dtos.EventLogDtos;

namespace BSS_Backend_Opgave.API.Hubs;

public interface IEventHubClient
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public Task ReceiveMessage(string message);
}
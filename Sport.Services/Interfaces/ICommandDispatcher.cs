using System.Threading.Tasks;

namespace Sport.Services.Interfaces
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}
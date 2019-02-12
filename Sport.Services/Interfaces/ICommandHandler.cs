using System.Threading.Tasks;

namespace Sport.Services.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
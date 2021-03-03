using System.Threading.Tasks;

namespace Buddy.Infrastructure
{
    public interface IStartupTask
    {
        Task ExecuteAsync();

        int Order { get; }
    }
}
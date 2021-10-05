using System.Threading.Tasks;

namespace Buddy
{
    public interface IStartupTask
    {
        Task Execute();

        int Order { get; }
    }
}
using NP.Services.Commands;
using System.Threading.Tasks;

namespace NP.Services.Tools
{
    public interface ITool
    {
        string Name { get; }

        ToolResponse Execute(ToolRequest request);
    }
    public interface IToolAsync
    {
        string Name { get; }

        Task<ToolResponse> ExecuteAsync(
            ToolRequest request);
    }
}
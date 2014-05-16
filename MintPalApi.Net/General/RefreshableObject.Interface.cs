using System.Threading.Tasks;

namespace Jojatekok.MintPalAPI
{
    public interface IRefreshableObject
    {
        /// <summary>Reloads the object's data from the server.</summary>
        Task RefreshAsync();
    }
}

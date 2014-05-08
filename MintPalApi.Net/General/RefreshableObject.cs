using System.Threading.Tasks;

namespace MintPalAPI
{
    public abstract class RefreshableObject
    {
        internal object BaseObject { get; set; }

        abstract public Task RefreshAsync();
    }
}

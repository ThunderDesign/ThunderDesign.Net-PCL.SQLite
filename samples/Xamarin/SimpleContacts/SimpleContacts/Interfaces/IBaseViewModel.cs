using System.Threading.Tasks;
using ThunderDesign.Net.Threading.Interfaces;

namespace SimpleContacts.Interfaces
{
    public interface IBaseViewModel : IBindableObject
    {
        #region properties
        bool IsBusy { get; set; }
        #endregion

        #region methods
        Task<bool> LoadViewModelAsync(bool forceRefresh = false);
        #endregion
    }
}

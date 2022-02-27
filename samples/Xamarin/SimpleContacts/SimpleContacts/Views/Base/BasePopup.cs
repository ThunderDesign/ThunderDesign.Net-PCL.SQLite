using SimpleContacts.Interfaces;
using SimpleContacts.ViewModels.Base;
using Xamarin.CommunityToolkit.UI.Views;

namespace SimpleContacts.Views.Base
{
    public class BasePopup<T> : Popup where T : BaseViewModel, new()
    {
        #region constructors
        public BasePopup() : base()
        {
            ViewModel = new T();
            BindingContext = ViewModel;
        }
        #endregion

        #region properties
        public IBaseViewModel ViewModel { get; protected set; }
        #endregion
    }
}

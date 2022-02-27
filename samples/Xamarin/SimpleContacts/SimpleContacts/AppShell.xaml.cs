using SimpleContacts.Views;
using Xamarin.Forms;

namespace SimpleContacts
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ContactPopup), typeof(ContactPopup));
        }

    }
}

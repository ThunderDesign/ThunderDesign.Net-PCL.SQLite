using SimpleContacts.Extentions;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ThunderDesign.Net.Threading.HelperClasses;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleContacts.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingActionButton : ContentView
    {
        #region constructors
        public FloatingActionButton() : base()
        {
            InitializeComponent();
        }
        #endregion

        #region event handlers
        public event EventHandler Clicked;
        #endregion

        #region properties
        public static readonly BindableProperty CommandProperty =
                               BindableProperty.Create(propertyName: nameof(Command), returnType: typeof(ICommand), declaringType: typeof(FloatingActionButton));
        public static readonly BindableProperty ImageSourceProperty =
                               BindableProperty.Create(propertyName: nameof(ImageSource), returnType: typeof(ImageSource), declaringType: typeof(FloatingActionButton));
        public new static readonly BindableProperty BackgroundColorProperty =
                                   BindableProperty.Create(propertyName: nameof(BackgroundColor), returnType: typeof(Color), declaringType: typeof(FloatingActionButton), defaultValue: Color.Black);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }
        #endregion

        #region methods
        protected override void OnParentSet()
        {
            base.OnParentSet();

            ThreadHelper.RunAndForget(async () =>
            {
                var page = await this.GetParentAsync<Page>();

                await WaitForPageAnimationEndsAsync();
                await ShowButtonAsync();

                page.Appearing += Page_Appearing;
                page.Disappearing += Page_Disappearing;
            });
        }

        private void Page_Appearing(object sender, EventArgs e)
        {
            ThreadHelper.RunAndForget(async () => await ShowPageAsync().ConfigureAwait(false));
        }

        private void Page_Disappearing(object sender, EventArgs e)
        {
            ThreadHelper.RunAndForget(async () => await HidePageAsync().ConfigureAwait(false));
        }

        private async Task ShowPageAsync()
        {
            await WaitForPageAnimationEndsAsync();
            await ShowButtonAsync();
        }

        private async Task HidePageAsync()
        {
            await HideButtonAsync();
        }

        private async Task ShowButtonAsync()
        {
            await Shadows.ScaleTo(1, easing: Easing.SpringOut);
        }

        private async Task HideButtonAsync()
        {
            await Shadows.ScaleTo(0, easing: Easing.SpringIn);
        }

        private async Task WaitForPageAnimationEndsAsync()
        {
            await Task.Delay(300);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, EventArgs.Empty);

            if (Command != null &&
                Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }
        #endregion
    }
}
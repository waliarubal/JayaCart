
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Shared.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageCard : ContentView
    {
        public static readonly BindableProperty MessageProperty;

        static MessageCard()
        {
            MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(MessageCard), string.Empty);
        }

        public MessageCard()
        {
            InitializeComponent();
        }

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }
    }
}
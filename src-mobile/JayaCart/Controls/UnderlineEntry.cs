using Xamarin.Forms;

namespace JayaCart.Mobile.Controls
{
    public class UnderlineEntry: Entry
    {
        public static readonly BindableProperty UnderlineColorProperty;

        static UnderlineEntry()
        {
            UnderlineColorProperty = BindableProperty.Create(nameof(UnderlineColor), typeof(Color), typeof(UnderlineEntry), Color.White, BindingMode.OneWay);
        }

        public Color UnderlineColor
        {
            get => (Color)GetValue(UnderlineColorProperty);
            set => SetValue(UnderlineColorProperty, value);
        }
    }
}

using Xamarin.Forms;

namespace JayaCart.Controls
{
    public class FontAwesomeIcon : Label
    {
        public static readonly string Typeface;

        static FontAwesomeIcon()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    Typeface = "fa-solid-900";
                    break;

                case Device.iOS:
                    Typeface = "FontAwesome5Free-Solid";
                    break;
            }
        }

        public FontAwesomeIcon()
        {
            FontFamily = Typeface;
        }

        public FontAwesomeIcon(string icon): this()
        {
            Text = icon;
        }
    }
}

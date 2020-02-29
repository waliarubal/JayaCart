using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using JayaCart.Mobile.Controls;
using JayaCart.Mobile.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(UnderlineEntry), typeof(UnderlineEntryRenderer))]
namespace JayaCart.Mobile.Droid
{
    class UnderlineEntryRenderer: EntryRenderer
    {
        public UnderlineEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null)
                return;

            var color = (e.NewElement as UnderlineEntry).UnderlineColor;
            var platformColor = color.ToAndroid();

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(platformColor);
            else
                Control.Background.SetColorFilter(platformColor, PorterDuff.Mode.SrcAtop);
        }
    }
}
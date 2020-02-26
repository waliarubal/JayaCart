using Android.Content;
using JayaCart.Mobile.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(BorderlessEntryRenderer))]
namespace JayaCart.Mobile.Droid
{
    class BorderlessEntryRenderer: EntryRenderer
    {
        public BorderlessEntryRenderer(Context context): base(context)
        {
           
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
                Control.Background = null;
        }
    }
}
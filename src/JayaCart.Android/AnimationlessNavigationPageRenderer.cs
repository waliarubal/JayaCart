using Android.Content;
using JayaCart.Mobile.Controls;
using JayaCart.Mobile.Droid;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(AnimationlessNavigationPage), typeof(AnimationlessNavigationPageRenderer))]
namespace JayaCart.Mobile.Droid
{
    class AnimationlessNavigationPageRenderer: NavigationPageRenderer
    {
        public AnimationlessNavigationPageRenderer(Context c) : base(c)
        {

        }

        protected override Task<bool> OnPopToRootAsync(Page page, bool animated)
        {
            return base.OnPopToRootAsync(page, false);
        }

        protected override Task<bool> OnPopViewAsync(Page page, bool animated)
        {
            return base.OnPopViewAsync(page, false);
        }

        protected override Task<bool> OnPushAsync(Page view, bool animated)
        {
            return base.OnPushAsync(view, false);
        }

    }
}
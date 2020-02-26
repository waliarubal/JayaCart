﻿using CoreAnimation;
using CoreGraphics;
using JayaCart.Mobile.Controls;
using JayaCart.Mobile.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(UnderlineEntry), typeof(UnderlineEntryRenderer))]
namespace JayaCart.Mobile.iOS
{
    class UnderlineEntryRenderer: EntryRenderer
    {
        private CALayer _line;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            _line = null;

            if (Control == null || e.NewElement == null)
                return;

            Control.BorderStyle = UITextBorderStyle.None;

            _line = new CALayer
            {
                BorderColor = UIColor.FromRGB(174, 174, 174).CGColor,
                BackgroundColor = UIColor.FromRGB(174, 174, 174).CGColor,
                Frame = new CGRect(0, Frame.Height / 2, Frame.Width * 2, 1f)
            };

            Control.Layer.AddSublayer(_line);
        }
    }
}
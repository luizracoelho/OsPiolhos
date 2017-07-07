using Android.Graphics;
using Android.Text;
using Android.Widget;
using Piolhos.App.Core.Components;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Piolhos.App.Core.Components.HtmlLabel), typeof(Piolhos.App.Droid.Renderers.HtmlLabelRenderer))]
namespace Piolhos.App.Droid.Renderers
{
    public class HtmlLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            Control?.SetText(Html.FromHtml(Element.Text), TextView.BufferType.Spannable);

            if ((Element as HtmlLabel).IsUnderlined)
                Control.PaintFlags = PaintFlags.UnderlineText;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                Control?.SetText(Html.FromHtml(Element.Text), TextView.BufferType.Spannable);

                if ((Element as HtmlLabel).IsUnderlined)
                    Control.PaintFlags = PaintFlags.UnderlineText;
            }
        }
    }
}
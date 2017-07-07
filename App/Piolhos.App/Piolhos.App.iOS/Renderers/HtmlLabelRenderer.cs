using Foundation;
using Piolhos.App.Core.Components;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Piolhos.App.Core.Components.HtmlLabel), typeof(Piolhos.App.iOS.Renderers.HtmlLabelRenderer))]
namespace Piolhos.App.iOS.Renderers
{
    public class HtmlLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
            {
                var attr = new NSAttributedStringDocumentAttributes();
                var nsError = new NSError();
                attr.DocumentType = NSDocumentType.HTML;

                var myHtmlData = NSData.FromString(Element.Text, NSStringEncoding.Unicode);
                this.Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);

                var label = (HtmlLabel)this.Element;
                if (label.IsUnderlined)
                    this.Control.AttributedText = new NSAttributedString(label.Text, underlineStyle: NSUnderlineStyle.Single);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
                {
                    var attr = new NSAttributedStringDocumentAttributes();
                    var nsError = new NSError();
                    attr.DocumentType = NSDocumentType.HTML;

                    var myHtmlData = NSData.FromString(Element.Text, NSStringEncoding.Unicode);
                    this.Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);

                    var label = (HtmlLabel)this.Element;
                    if (label.IsUnderlined)
                        this.Control.AttributedText = new NSAttributedString(label.Text, underlineStyle: NSUnderlineStyle.Single);
                }
            }
        }
    }
}

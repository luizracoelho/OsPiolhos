using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Piolhos.App.Core.Components
{
    public class Rating : StackLayout
    {
        #region Value (Bindable double)   
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(double), typeof(Rating), -1.0);

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        #endregion

        public ImageSource IconEmpty { get; set; }
        public ImageSource IconHalf { get; set; }
        public ImageSource IconFull { get; set; }
        public int? IconHeightRequest { get; set; }

        public Rating()
        {
            Orientation = StackOrientation.Horizontal;

        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Value))
            {
                var intValue = (int)Value;
                var fracValue = Value - intValue;

                for (int i = 0; i < intValue; i++)
                    Children.Add(new Image
                    {
                        Source = IconFull,
                        HeightRequest = IconHeightRequest ?? 24
                    });

                if (fracValue != 0)
                {
                    Children.Add(new Image
                    {
                        Source = IconHalf,
                        HeightRequest = IconHeightRequest ?? 24
                    });
                    intValue++;
                }

                for (int i = 0; i < (5 - intValue); i++)
                    Children.Add(new Image
                    {
                        Source = IconEmpty,
                        HeightRequest = IconHeightRequest ?? 24
                    });
            }
        }
    }
}

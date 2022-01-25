using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp17
{
    /// <summary>
    /// Логика взаимодействия для ColorValue.xaml
    /// </summary>
    public partial class ColorValue : UserControl
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                nameof(Color),
                typeof(Color),
                typeof(ColorValue),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged))
                );
        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(
                nameof(Red),
                typeof(byte),
                typeof(ColorValue),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged))
                );
        public static readonly DependencyProperty GreenProperty =
            DependencyProperty.Register(
                nameof(Green),
                typeof(byte),
                typeof(ColorValue),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged))
                );
        public static readonly DependencyProperty BlueProperty =
            DependencyProperty.Register(
                nameof(Blue),
                typeof(byte),
                typeof(ColorValue),
                 new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged))
                 );
        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent(
                nameof(ColorChanged),
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>),
                typeof(ColorValue)
                );

        public ColorValue()
        {
            InitializeComponent();
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }
        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }
        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorValue colorvalue = (ColorValue)d;
            colorvalue.Red = newColor.R;
            colorvalue.Green = newColor.G;
            colorvalue.Blue = newColor.B;
        }

        private static void OnColorRGBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorValue colorValue = (ColorValue)d;
            Color color = colorValue.Color;
            if (e.Property == RedProperty)
            {
                color.R = (byte)e.NewValue;
            }
            else
            if (e.Property == GreenProperty)
            {
                color.G = (byte)e.NewValue;
            }
            else
            if (e.Property == BlueProperty)
            {
                color.B = (byte)e.NewValue;
            }
            colorValue.Color = color;
        }
    }
}
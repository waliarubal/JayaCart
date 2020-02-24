
using JayaCart.Mobile.Shared.Commands;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NumericUpDown : ContentView
	{
        public static readonly BindableProperty MaximumProperty, MinimumProperty, ValueProperty;
        ICommand _increase, _decrease;

        static NumericUpDown()
        {
            MaximumProperty = BindableProperty.Create(nameof(Maximum), typeof(long), typeof(NumericUpDown), 100L, BindingMode.OneWay);
            MinimumProperty = BindableProperty.Create(nameof(Minimum), typeof(long), typeof(NumericUpDown), 0L, BindingMode.OneWay);
            ValueProperty = BindableProperty.Create(nameof(Value), typeof(long), typeof(NumericUpDown), 0L, BindingMode.TwoWay);
        }

        public NumericUpDown()
        {
            InitializeComponent();
        }

        public ICommand IncreaseCommand
        {
            get
            {
                if (_increase == null)
                    _increase = new RelayCommand(IncreaseAction);

                return _increase;
            }
        }

        public ICommand DecreaseCommand
        {
            get
            {
                if (_decrease == null)
                    _decrease = new RelayCommand(DecreaseAction);

                return _decrease;
            }
        }

        public long Maximum
        {
            get => (long)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public long Minimum
        {
            get => (long)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public long Value
        {
            get => (long)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        void IncreaseAction()
        {
            if (Value < Maximum)
                Value += 1;
        }

        void DecreaseAction()
        {
            if (Value > Minimum)
                Value -= 1;
        }
    }
}
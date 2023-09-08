using System.Windows.Input;

namespace MauiCustomControls.Controls;

public partial class ButtonWithProgressBar : Frame
{
	public static readonly BindableProperty TextProperty = BindableProperty.Create(
		propertyName: nameof(Text), 
		returnType: typeof(string), 
		declaringType: typeof(ButtonWithProgressBar),
		defaultValue: "DefaultText",
		defaultBindingMode: BindingMode.TwoWay
	);

    public static readonly BindableProperty LoadingTextProperty = BindableProperty.Create(
        propertyName: nameof(LoadingText),
        returnType: typeof(string),
        declaringType: typeof(ButtonWithProgressBar),
        defaultValue: "Please Wait...",
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty IsInProgressProperty = BindableProperty.Create(
        propertyName: nameof(IsInProgress),
        returnType: typeof(bool),
        declaringType: typeof(ButtonWithProgressBar),
        defaultValue: true,
        propertyChanged: IsInProgressPropertyChanged
    );

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        propertyName: nameof(Command),
        returnType: typeof(ICommand),
        declaringType: typeof(ButtonWithProgressBar),
        defaultBindingMode: BindingMode.TwoWay);




    public string Text { 
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value); 
	}
    public string LoadingText
    {
        get => (string)GetValue(LoadingTextProperty);
        set => SetValue(LoadingTextProperty, value);
    }
    public bool IsInProgress 
    {
        get => (bool)GetValue(IsInProgressProperty);
        set => SetValue(IsInProgressProperty, value);
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set { SetValue(CommandProperty, value); }
    }

    public event EventHandler<EventArgs> Tapped;

    public ButtonWithProgressBar()
	{
		InitializeComponent();
	}

    private static void IsInProgressPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ButtonWithProgressBar)bindable;
        if(newValue != null)
        {
            bool isInProgress = (bool) newValue;
            if(isInProgress)
            {
                control.lblButtonText.Text = control.LoadingText;
            }
            else
            {
                control.lblButtonText.Text = control.Text;
            }
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Tapped?.Invoke(sender, e);
    }
}
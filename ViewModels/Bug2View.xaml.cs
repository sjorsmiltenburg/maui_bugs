using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using zz_MauiBugs.Messages;

namespace zz_MauiBugs.ViewModels;

public partial class Bug2View : ContentPage
{
    public Bug2View()
    {
        InitializeComponent();

        MyLabel.Text =
            "a" + Environment.NewLine +
            "b" + Environment.NewLine +
            "c" + Environment.NewLine +
            "d" + Environment.NewLine +
            "e" + Environment.NewLine +
            "f" + Environment.NewLine +
            "g" + Environment.NewLine +
            "h" + Environment.NewLine +
            "i" + Environment.NewLine +
            "j" + Environment.NewLine +
            "k" + Environment.NewLine +
            "l" + Environment.NewLine +
            "m" + Environment.NewLine +
            "n" + Environment.NewLine +
            "o" + Environment.NewLine +
            "p" + Environment.NewLine +
            "q" + Environment.NewLine +
            "r" + Environment.NewLine +
            "s" + Environment.NewLine +
            "t" + Environment.NewLine +
            "u" + Environment.NewLine +
            "v" + Environment.NewLine +
            "w" + Environment.NewLine +
            "x" + Environment.NewLine +
            "y" + Environment.NewLine +
            "z" + Environment.NewLine +
            "a" + Environment.NewLine +
            "b" + Environment.NewLine +
            "c" + Environment.NewLine +
            "d" + Environment.NewLine +
            "e" + Environment.NewLine +
            "f" + Environment.NewLine +
            "g" + Environment.NewLine +
            "h" + Environment.NewLine +
            "i" + Environment.NewLine +
            "j" + Environment.NewLine +
            "k" + Environment.NewLine +
            "l" + Environment.NewLine +
            "m" + Environment.NewLine +
            "n" + Environment.NewLine +
            "o" + Environment.NewLine +
            "p" + Environment.NewLine +
            "q" + Environment.NewLine +
            "r" + Environment.NewLine +
            "s" + Environment.NewLine +
            "t" + Environment.NewLine +
            "u" + Environment.NewLine +
            "v" + Environment.NewLine +
            "w" + Environment.NewLine +
            "x" + Environment.NewLine +
            "y" + Environment.NewLine +
            "z" + Environment.NewLine;

        WeakReferenceMessenger.Default.Register<Bug2Message>(this, (r, m) =>
        {
            Application.Current.Dispatcher.DispatchAsync(async () =>
            {
                try
                {
                    //this is where the bug occurs
                    await MyScrollView.ScrollToAsync(0, 0, false);

                    //THE FOLLOWING CODE DOES NOT GET EXECUTED UNTILL YOU SCROLL MANUALLY AND LEAVE THE SCROLLBAR IN A POSITION > 0
                    MyLabel.Text = "The text is successfully changed";
                }
                catch (Exception ex)
                {
                    //WE ARE NOT ARRIVING HERE
                    Debugger.Break();
                }
            });
        });
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //this works
        MyScrollView.ScrollToAsync(0, 0, true);
        MyLabel.Text = "The text is successfully changed";
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        //this does not work
        Application.Current.Dispatcher.DispatchAsync(async () =>
        {
            try
            {
                await MyScrollView.ScrollToAsync(0, 0, true);
                MyLabel.Text = "The text is successfully changed";
            }
            catch (Exception e)
            {
                Debugger.Break();
            }
        });
    }
}
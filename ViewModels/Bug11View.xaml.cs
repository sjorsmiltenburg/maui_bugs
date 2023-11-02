using System.Diagnostics;

namespace zz_MauiBugs.ViewModels;

public partial class Bug11View : ContentPage
{
    public Bug11View()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Debugger.Break();
    }
}
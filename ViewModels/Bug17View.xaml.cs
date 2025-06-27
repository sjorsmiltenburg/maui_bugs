namespace zz_MauiBugs.ViewModels;

public partial class Bug17View : ContentPage
{

    public Bug17View()
    {
        InitializeComponent();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {

            await BottomImage.RotateYTo(-90, 250);
            await BottomImage.RotateYTo(0, 250);


        });
    }
}
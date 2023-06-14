namespace zz_MauiBugs.ViewModels;

public partial class Bug5View : ContentPage
{
    public Bug5View()
    {
        InitializeComponent();
        this.Unloaded += Bug5View_Unloaded;
    }

    private void Bug5View_Unloaded(object sender, EventArgs e)
    {
        MyMediaElement.Handler?.DisconnectHandler();
    }
}
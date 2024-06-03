using System.Text;

namespace zz_MauiBugs.ViewModels;

public partial class Bug14View : ContentPage
{
    public Bug14View()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Scroll(0);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Scroll(0.5d);
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Scroll(1);
    }

    private void Button_Clicked_test(object sender, EventArgs e)
    {
        MyScrollView.ScrollToAsync(test, ScrollToPosition.MakeVisible, true);
    }

    private void Button_Clicked_PrintScrollPos(object sender, EventArgs e)
    {
        reportLabel.Text = "DesiredSize.Width=" + MyScrollView.DesiredSize.Width + " Scrollpos = " + MyScrollView.ScrollX;
    }

    private async Task Scroll(double x)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"ScrollPosition before action: {MyScrollView.ScrollX}");
        var scrollpos = MyScrollView.DesiredSize.Width * x;

        await MyScrollView.ScrollToAsync(scrollpos, 0, false);

        sb.AppendLine($"ScrollPosition after action: {MyScrollView.ScrollX}");
        reportLabel.Text = sb.ToString();
    }
}
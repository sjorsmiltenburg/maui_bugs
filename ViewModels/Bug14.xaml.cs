using System.Text;

namespace zz_MauiBugs.ViewModels;

public partial class Bug14View : ContentPage
{
    public Bug14View()
    {
        InitializeComponent();
    }

    private void ScrollToBegin(object sender, EventArgs e)
    {
        //this does what i expect
        Scroll(0);
    }

    private void ScrollToMiddle(object sender, EventArgs e)
    {
        Scroll(0.5d);
    }

    private void ScrollToEnd(object sender, EventArgs e)
    {
        Scroll(1);
    }

    private void ScrollToLabel(object sender, EventArgs e)
    {
        //this does what i expect
        MyScrollView.ScrollToAsync(Working, ScrollToPosition.End, true);
    }

    private void ScrollToSpan(object sender, EventArgs e)
    {
        //BUG this does not what i expect
        MyScrollView.ScrollToAsync(NotWorking, ScrollToPosition.End, true);
    }

    private void Button_Clicked_PrintScrollPos(object sender, EventArgs e)
    {
        reportLabel.Text = "DesiredSize.Height=" + MyScrollView.DesiredSize.Height + " Scrollpos = " + MyScrollView.ScrollY;
    }

    private async Task Scroll(double y)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"ScrollPosition before action: {MyScrollView.ScrollY}");
        var scrollposY = MyScrollView.ContentSize.Height * y;

        await MyScrollView.ScrollToAsync(0, scrollposY, false);

        sb.AppendLine($"ScrollPosition after action: {MyScrollView.ScrollY}");
        reportLabel.Text = sb.ToString();
    }
}
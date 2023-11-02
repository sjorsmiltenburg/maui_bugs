namespace zz_MauiBugs.ViewModels;

public partial class Bug13View : ContentPage
{
    public Bug13View()
    {
        InitializeComponent();
        string text = @"1
2";
        MyLabel.Text = text;

        var fs = new FormattedString();
        fs.Spans.Add(new Span() { Text = text, TextDecorations = TextDecorations.Underline });
        MyLabel2.FormattedText = fs;
    }


}
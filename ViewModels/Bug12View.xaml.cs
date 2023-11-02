using System.Diagnostics;

namespace zz_MauiBugs.ViewModels;

public partial class Bug12View : ContentPage
{
    public Bug12View()
    {
        InitializeComponent();
        _cutLength = 0;
        UpdateLabel();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Debugger.Break();
    }

    private int _cutLength;
    public void UpdateLabel()
    {
        MyLabel.FormattedText = null;

        string text = @"1
2";

        _cutLength++;
        CutCharacterLabel.Text = _cutLength.ToString(); ;

        //FormattedString result = new FormattedString();
        //var sub = text.Substring(0, 5);
        //result.Spans.Add(new Span() { Text = sub, TextDecorations = TextDecorations.Underline });
        //var sub2 = text.Substring(5);
        //result.Spans.Add(new Span() { Text = sub2 });
        //MyLabel.FormattedText = result;
        MyLabel.Text = text;

        //cut text at different position

        FormattedString result2 = new FormattedString();
        if (_cutLength == 0)
        {
            var fs = new FormattedString();
            fs.Spans.Add(new Span() { Text = text });
            MyLabel2.FormattedText = fs;
        }
        else
        {
            var actualCutPos = GetCutLength(_cutLength, text);
            var sub3 = text.Substring(0, actualCutPos);
            result2.Spans.Add(new Span() { Text = sub3, TextDecorations = TextDecorations.Underline });
            var sub4 = text.Substring(actualCutPos);
            result2.Spans.Add(new Span() { Text = sub4 });
            MyLabel2.FormattedText = result2;
        }

    }
    //linebreak: char0: \r char1: \n char2: \

    public int GetCutLength(int wantedLength, string input)
    {
        if (wantedLength >= input.Length) { return input.Length; }
        int cutPos = wantedLength;
        var chars = input.ToCharArray();

        while (IsPartOfNewLineChar(chars[cutPos - 1]))
        {
            Debug.WriteLine($"found newline char at pos {cutPos - 1}, moving back");
            cutPos--;
        }
        return cutPos;
    }

    public bool IsPartOfNewLineChar(char c)
    {
        return c == '\r' || c == '\n';
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        UpdateLabel();
    }
}
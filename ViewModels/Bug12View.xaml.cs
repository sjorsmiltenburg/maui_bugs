using System.Diagnostics;

namespace zz_MauiBugs.ViewModels;

public partial class Bug12View : ContentPage
{
    public Bug12View()
    {
        InitializeComponent();
        _wantedCutLength = 20;
        UpdateLabel();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Debugger.Break();
    }

    private int _wantedCutLength;
    public void UpdateLabel()
    {
        MyLabel.FormattedText = null;

        string text = @"Lola heeft een prachtige tekening gemaakt.
'Papa, mama kijk eens'";

        _wantedCutLength++;
        WantCutCharacterLabel.Text = _wantedCutLength.ToString(); ;

        FormattedString result = new FormattedString();
        var sub = text.Substring(0, 5);
        result.Spans.Add(new Span() { Text = sub, TextDecorations = TextDecorations.Underline });
        var sub2 = text.Substring(5);
        result.Spans.Add(new Span() { Text = sub2 });
        MyLabel.FormattedText = result;
        MyLabel.Text = text;

        //cut text at different position

        FormattedString result2 = new FormattedString();
        if (_wantedCutLength == 0)
        {
            var fs = new FormattedString();
            fs.Spans.Add(new Span() { Text = text });
            MyLabel2.FormattedText = fs;
        }
        else
        {
            var actualCutLength = GetCutLength(_wantedCutLength, text);
            NotCuttingOnWanted.IsVisible = actualCutLength != _wantedCutLength;
            ActualCutCharacterLabel.Text = actualCutLength.ToString();
            var sub3 = text.Substring(0, actualCutLength);
            result2.Spans.Add(new Span() { Text = sub3, TextDecorations = TextDecorations.Underline }); //IF YOU REMOVE THE UNDERLINE, THE VERTICAL SHIFTING PROBLEM STILL PERSISTS
            var sub4 = text.Substring(actualCutLength);
            result2.Spans.Add(new Span() { Text = sub4 });
            MyLabel2.FormattedText = result2;
        }

    }
    //linebreak: \r\n

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
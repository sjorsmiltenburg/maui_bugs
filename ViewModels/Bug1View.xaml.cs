using CommunityToolkit.Mvvm.Messaging;
using zz_MauiBugs.Messages;

namespace zz_MauiBugs.ViewModels;

public partial class Bug1View : ContentPage
{
    bool _useFirstOption;

    public Bug1View()
    {
        InitializeComponent();

        var fs = new FormattedString();
        fs.Spans.Add(new Span() { Text = "This is the text on Line1" + Environment.NewLine + "This is the text on Line2" });
        MyChangeFontFormattedTextCorrectLabel.FormattedText = fs;



        var fsWrong = new FormattedString();
        fsWrong.Spans.Add(new Span() { Text = "This is the text on Line1" + Environment.NewLine + "This is the text on Line2" });

        MyChangeFontFormattedTextWrongLabel.FormattedText = fsWrong;
        MyChangeNormalTextFont.Text = fsWrong.ToString();


        WeakReferenceMessenger.Default.Register<ChangeFontMessage>(this, (r, m) =>
        {
            Application.Current.Dispatcher.DispatchAsync(() =>
            {
                string fontFamily1 = "OpenSansRegular";
                string fontFamily2 = "opendyslexic";
                int fontSize1 = 20;
                int fontSize2 = 40;
                int lineHeight1 = 0;
                int lineHeight2 = 2;
                Color color1 = Colors.White;
                Color color2 = Colors.Green;

                if (_useFirstOption)
                {
                    foreach (var span in fs.Spans)
                    {
                        span.FontFamily = fontFamily1; //this works
                    }

                    MyChangeFontFormattedTextCorrectLabel.FontSize = fontSize1;
                    MyChangeFontFormattedTextCorrectLabel.TextColor = color1;
                    MyChangeFontFormattedTextCorrectLabel.LineHeight = lineHeight1;

                    MyChangeFontFormattedTextWrongLabel.FontSize = fontSize1;
                    MyChangeFontFormattedTextWrongLabel.TextColor = color1;
                    MyChangeFontFormattedTextWrongLabel.LineHeight = lineHeight1;
                    MyChangeFontFormattedTextWrongLabel.FontFamily = fontFamily1; //this is not working

                    MyChangeNormalTextFont.FontFamily = fontFamily1; //this works because we don't use the FormattedText property for this label
                    MyChangeNormalTextFont.FontSize = fontSize1;
                    MyChangeNormalTextFont.TextColor = color1;
                    MyChangeNormalTextFont.LineHeight = lineHeight1;
                }
                else
                {
                    foreach (var span in fs.Spans)
                    {
                        span.FontFamily = fontFamily2;  //this works                        
                    }
                    MyChangeFontFormattedTextCorrectLabel.FontSize = fontSize2;
                    MyChangeFontFormattedTextCorrectLabel.TextColor = color2;
                    MyChangeFontFormattedTextCorrectLabel.LineHeight = lineHeight2;

                    MyChangeFontFormattedTextWrongLabel.FontSize = fontSize2;
                    MyChangeFontFormattedTextWrongLabel.TextColor = color2;
                    MyChangeFontFormattedTextWrongLabel.LineHeight = lineHeight2;
                    MyChangeFontFormattedTextWrongLabel.FontFamily = fontFamily2; //this is not working

                    MyChangeNormalTextFont.FontFamily = fontFamily2; //this works because we don't use the FormattedText property for this label
                    MyChangeNormalTextFont.FontSize = fontSize2;
                    MyChangeNormalTextFont.TextColor = color2;
                    MyChangeNormalTextFont.LineHeight = lineHeight2;
                }


                _useFirstOption = !_useFirstOption;
            });
        });
    }
}
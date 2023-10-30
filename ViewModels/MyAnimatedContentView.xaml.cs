namespace zz_MauiBugs.ViewModels;

public partial class MyAnimatedContentView : ContentView
{
    public MyAnimatedContentView()
    {
        InitializeComponent();
        var animation = new Microsoft.Maui.Controls.Animation(v => MyImage.Rotation = v, 0, 359);
        animation.Commit(this, "myanimation", 16, 250, Easing.Default, null, () => { return true; });
    }
}
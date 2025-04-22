using System.Diagnostics;

namespace zz_MauiBugs.ViewModels;

public partial class Bug16View : ContentPage
{
    int _spancount = 5;
    public Bug16View()
    {
        InitializeComponent();
        this.SizeChanged += Bug16View_SizeChanged;
    }

    CancellationTokenSource _resizeCts;
    private void Bug16View_SizeChanged(object sender, EventArgs e)
    {
        _resizeCts?.Cancel();
        _resizeCts = new CancellationTokenSource();
        var token = _resizeCts.Token;

        Task.Delay(200, token).ContinueWith(t =>
        {
            if (!token.IsCancellationRequested)
                MainThread.BeginInvokeOnMainThread(UpdateWidth);
        });
    }

    private void Span6_Clicked(object sender, EventArgs e)
    {
        _spancount = 6;
        UpdateWidth();
    }

    private void Span4_Clicked(object sender, EventArgs e)
    {
        _spancount = 4;
        UpdateWidth();
    }

    public void UpdateWidth()
    {
        //MyCollectionView.IsVisible = false;        
        var vm = (this.BindingContext as Bug16ViewModel);
        foreach (var item in vm.MyItems)
        {
            var itemWidth = Width / (double)_spancount;
            item.MyWidth = itemWidth;
            Debug.WriteLine($"Control Width: {Width} / spancount {_spancount} = ItemWidth:" + itemWidth);
        }
        ((GridItemsLayout)MyCollectionView.ItemsLayout).Span = _spancount;
        //MyCollectionView.IsVisible = true;
    }
}
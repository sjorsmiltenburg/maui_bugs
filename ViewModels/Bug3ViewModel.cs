namespace zz_MauiBugs.ViewModels
{
    public class Bug3ViewModel : BaseViewModel
    {
        public List<MyItemVM> MyItems { get; set; } = new List<MyItemVM>();

        public Bug3ViewModel()
        {
            MyItems.Add(new MyItemVM("a"));
            MyItems.Add(new MyItemVM("b"));
            MyItems.Add(new MyItemVM("c"));
            MyItems.Add(new MyItemVM("d"));
        }
    }

    public class MyItemVM
    {
        public MyItemVM(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
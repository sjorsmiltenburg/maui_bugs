namespace zz_MauiBugs.ViewModels
{
    internal class LoadViewMessage
    {
        public LoadViewMessage(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }

        public Type ViewModelType { get; }
    }
}
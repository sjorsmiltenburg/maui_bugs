namespace zz_MauiBugs.Messages
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
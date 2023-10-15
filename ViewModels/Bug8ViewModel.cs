﻿using System.Collections.ObjectModel;
using System.Windows.Input;

namespace zz_MauiBugs.ViewModels
{
    public class Bug8ViewModel : BaseViewModel
    {
        public ObservableCollection<Bug6ItemViewModel> FlexItemsObservableCollection { get; set; } = new ObservableCollection<Bug6ItemViewModel>();
        public List<Bug6ItemViewModel> FlexItemsList
        {
            get => _flexItemsList;
            set
            {
                _flexItemsList = value;
                OnPropertyChanged();
            }
        }
        public Bug8ViewModel()
        {
            ReloadItems();
        }

        public void ReloadItems()
        {
            FlexItemsObservableCollection.Clear();
            var newList = new List<Bug6ItemViewModel>();
            for (int i = 0; i < 15; i++)
            {
                FlexItemsObservableCollection.Add(new Bug6ItemViewModel(GetRandomImageUrl()));
                newList.Add(new Bug6ItemViewModel(GetRandomImageUrl()));
            }

            FlexItemsList = newList;
        }

        int _random = 0;
        private List<Bug6ItemViewModel> _flexItemsList = new List<Bug6ItemViewModel>();

        private string GetRandomImageUrl()
        {
            _random++;
            return "https://source.unsplash.com/random/200x200?sig=" + _random;
        }

        public ICommand ReloadListCommand
        {
            get
            {
                return new Command(() =>
                {
                    ReloadItems();
                });
            }
        }
    }
}
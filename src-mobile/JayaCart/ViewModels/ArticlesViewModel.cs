﻿using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Models;
using JayaCart.Mobile.Shared.Base;
using JayaCart.Mobile.Shared.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace JayaCart.Mobile.ViewModels
{
    public class ArticlesViewModel: ViewModelBase
    {
        ICommand _search;
        readonly IArticleService _articleService;

        public ArticlesViewModel(IArticleService articleService)
        {
            _articleService = articleService;

            SearchCommand.Execute("<suggested>");
        }

        public ObservableCollection<ShoppingCartArticle> Articles
        {
            get => Get<ObservableCollection<ShoppingCartArticle>>();
            private set => Set(value);
        }

        public string SearchKeywoard
        {
            get => Get<string>();
            set => Set(value);
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_search == null)
                    _search = new RelayCommand<string>(SearchAction);

                return _search;
            }
        }

        async void SearchAction(string keywoard)
        {
            var articles = await _articleService.Search(keywoard);

            var cartArticles = new List<ShoppingCartArticle>();
            foreach (var product in articles)
                cartArticles.Add(new ShoppingCartArticle { Article = product });

            Articles = new ObservableCollection<ShoppingCartArticle>(cartArticles);
        }
    }
}

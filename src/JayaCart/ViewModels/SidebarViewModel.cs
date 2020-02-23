﻿using JayaCart.DataAccess.Models;
using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Models;
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared.Base;
using JayaCart.Mobile.Shared.Commands;
using JayaCart.Mobile.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JayaCart.Mobile.ViewModels
{
    public class SidebarViewModel : ViewModelBase
    {
        ICommand _itemClick;
        readonly INavigationService _navigationService;
        readonly IUserAccountService _accountService;

        public SidebarViewModel(INavigationService navigationService, IUserAccountService userAccountService)
        {
            _navigationService = navigationService;
            _accountService = userAccountService;

            Task.Run(async() => await SignIn());
        }

        public IEnumerable<SidebarItem> Items => _navigationService?.GetSidebarItems();

        public UserAccount Account
        {
            get => Get<UserAccount>();
            private set => Set(value);
        }

        public ICommand ItemClickCommand
        {
            get
            {
                if (_itemClick == null)
                    _itemClick = new RelayCommand<SidebarItem>(ItemClickAction);

                return _itemClick;
            }
        }

        async Task SignIn()
        {
            Account = _accountService.GetLocalAccount();
            if (Account == null)
                await _navigationService.Navigate(typeof(SignInView), true);
        }

        async void ItemClickAction(SidebarItem item)
        {
            await _navigationService.Navigate(item.ViewType);
        }
    }
}

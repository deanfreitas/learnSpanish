using System;
using System.Windows.Input;
using learnSpanish.Enums.Error;
using learnSpanish.Enums.Service;
using learnSpanish.Enums.Success;
using learnSpanish.Enums.View;
using learnSpanish.Model;
using learnSpanish.ModelView.Services;
using learnSpanish.Sqlite;
using Xamarin.Forms;

namespace learnSpanish.ModelView
{
    class MainView
    {
        private readonly IMessageService _messageService;
        private readonly INavigationService _navigationService;
        private readonly SqliteService _sqliteService;
        private readonly User _user;

        public MainView(User user)
        {
            PlayCommand = new Command(Play);
            UpdateCommand = new Command(Update);
            DeleteCommand = new Command(Delete);
            _sqliteService = new SqliteService();
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
            _user = user;
        }

        public ICommand PlayCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private async void Play()
        {
        }

        private async void Update()
        {
        }

        private async void Delete()
        {
            var response = await _messageService.ShowOnAlertYesNoClicked("Do you want to delete your user?");
            if (!response) return;

            try
            {
                await _sqliteService.DeleteWithChildren(_user);
                await _messageService.ShowMessage(EnumsService.GetMessageSuccessUser(SuccessUser.UserDeleted, _user.Name));
                await _navigationService.NavigationWithoutBackButton(ViewName.LoginPage);
            }
            catch (Exception e)
            {
                Logs.Logs.Error(e);
                await _messageService.ShowMessageError(EnumsService.GetMessageErrorSystem(ErrorSystem.Generic));
            }
        }
    }
}
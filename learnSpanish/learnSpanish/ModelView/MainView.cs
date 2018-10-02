using System.Windows.Input;
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
        
        public MainView()
        {
            PlayCommand = new Command(Play);
            UpdateCommand = new Command(Update);
            DeleteCommand = new Command(Delete);
            _sqliteService = new SqliteService();
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
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
            await _messageService.ShowOnAlertYesNoClicked("Do you want to delete your user?");
        }
    }
}
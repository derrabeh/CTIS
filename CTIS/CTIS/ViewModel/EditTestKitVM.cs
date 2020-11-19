using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    class EditTestKitVM: BaseVM
    {
        public static TestKit TestKit { get; set; }
        public ObservableCollection<string> StatusList { get; set; }
        public Command SaveCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command BackCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public EditTestKitVM()
        {
            StatusList = new ObservableCollection<string>();
            SaveCommand = new Command(SaveExecute);
            CancelCommand = new Command(CancelExecute);
            DeleteCommand = new Command(DeleteExecute);
            StatusList.Add("Low stock");
            StatusList.Add("Restocked");
            StatusList.Add("New stock");
            StatusList.Add("Other");
            Status = TestKit.Status;
            KitName = TestKit.KitName;
            CurrentStock = TestKit.CurrentStock;
            LastUpdated = TestKit.LastUpdated;
        }

        public string KitName
        {
            get { return TestKit.KitName; }
            set
            {
                TestKit.KitName = value;
                OnPropertyChanged();
            }
        }

        public string CurrentStock
        {
            get { return TestKit.CurrentStock; }
            set
            {
                TestKit.CurrentStock = value;
                OnPropertyChanged();
            }
        }

        public DateTime LastUpdated
        {
            get { return TestKit.LastUpdated; }
            set
            {
                TestKit.LastUpdated = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get { return TestKit.Status; }
            set
            {
                TestKit.Status = value;
                OnPropertyChanged();
            }
        }

        private async void DeleteExecute(object obj)
        {
            await Application.Current.MainPage.DisplayAlert("Delete Confirmation", "Are you sure to delete this test kit?", "Yes", "No");
            await FirebaseDBConnection.DeleteKitAsync(TestKit);
            Application.Current.MainPage = new NavigationPage(new ManageTestKit());
        }


        private async void CancelExecute(Object obj)
        {
            await Application.Current.MainPage.DisplayAlert("Cancel Confirmation", "Your changes will not be saved. Are you sure?", "Yes", "No");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        //Update Test Kit 
        private async void SaveExecute(Object obj)
        {
            if (string.IsNullOrWhiteSpace(TestKit.KitName) &&
                string.IsNullOrWhiteSpace(TestKit.CurrentStock))
            {
                await Application.Current.MainPage.DisplayAlert("Missing field", "Test kit name or current stock cannot be empty.", "OK");
                return;
            }
            else
            {
                await FirebaseDBConnection.EditKitAsync(TestKit);
                Application.Current.MainPage = new NavigationPage(new ManageTestKit());
            }
        }

    }
}

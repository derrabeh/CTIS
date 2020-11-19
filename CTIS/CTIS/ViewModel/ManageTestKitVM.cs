using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    public class ManageTestKitVM : BaseVM
    {
        public ObservableCollection<TestKit> KitsList { get; set; }
        public TestKit TestKit { get; set; }
        public Command AddCommand { get; set; }
        public Command BackCommand { get; set; }

        public ManageTestKitVM()
        {
            KitsList = new ObservableCollection<TestKit>();
            GetAllKits();
            BackCommand = new Command(BackExecute);
            AddCommand = new Command(AddExecute);
        }

        public TestKit SelectedItem
        {
            get { return TestKit; }
            set
            {
                TestKit = value;
                OnPropertyChanged();
                OpenEditKitView();
            }
        }

        private async void OpenEditKitView()
        {
            if (TestKit != null)
            {
                EditTestKitVM.TestKit = new TestKit
                {
                    KitID = TestKit.KitID,
                    KitName = TestKit.KitName,
                    CurrentStock = TestKit.CurrentStock,
                    LastUpdated = TestKit.LastUpdated,
                    Status = TestKit.Status
                };
                await Application.Current.MainPage.Navigation.PushAsync(new EditTestKit());
                this.SelectedItem = null;
            }
        }

        private async void AddExecute(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddTestKit());
        }

        private async void BackExecute(Object obj)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async void GetAllKits()
        {
            List<TestKit> kits = await FirebaseDBConnection.GetAllKitsAsync();
            foreach (TestKit kit in kits)
            {
                KitsList.Add(kit);
            }
        }

    }
}

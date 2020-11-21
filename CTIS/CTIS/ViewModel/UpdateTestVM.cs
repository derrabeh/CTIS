using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    public class UpdateTestVM : BaseVM
    {
        public ObservableCollection<CovidTest> TestList { get; set; }
        public CovidTest CovidTest { get; set; }
        public Command AddCommand { get; set; }
        public Command BackCommand { get; set; }


        public UpdateTestVM()
        {
            TestList = new ObservableCollection<CovidTest>();
            GetAllTest();
            AddCommand = new Command(AddExecute);
            BackCommand = new Command(BackExecute);
        }

        public CovidTest SelectedItem
        {
            get { return CovidTest; }
            set
            {
                CovidTest = value;
                OnPropertyChanged();
                OpenTestView();
            }
        }

        private async void OpenTestView()
        {
            if (CovidTest != null)
            {
                EditTestVM.CovidTest = new CovidTest
                {
                    PatientName = CovidTest.PatientName,
                    Result = CovidTest.Result,
                    ResultDate = CovidTest.ResultDate,
                    Status = CovidTest.Status,
                    TestDate = CovidTest.TestDate,
                    TestID = CovidTest.TestID,
                    TestedBy = CovidTest.TestedBy
                };
                await Application.Current.MainPage.Navigation.PushAsync(new EditTest());
                this.SelectedItem = null;
            }
        }

        private async void AddExecute(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RecordNewTest());
        }

        private async void BackExecute(Object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TesterInterface());
        }

        public async void GetAllTest()
        {
            List<CovidTest> tests = await FirebaseDBConnection.GetAllTestsAsync();
            foreach (CovidTest test in tests)
            {
                TestList.Add(test);
            }
        }

    }
}

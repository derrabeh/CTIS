using CTIS.Model;
using CTIS.View;
using CTIS.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace CTIS.ViewModel
{
    class ViewTestingHistoryVM : BaseVM
    {
        

        public ObservableCollection<User> UsersList { get; set; }
        public ObservableCollection<CovidTest> CovidTestList { get; set; }
        public CovidTest CovidTest { get; set; }
        public User User { get; set; }
        public Command AddCommand { get; set; }
        public Command BackCommand { get; set; }

        public ViewTestingHistoryVM()
        {
            CovidTestList = new ObservableCollection<CovidTest>();
            UsersList = new ObservableCollection<User>();
            GetAllTests();
            BackCommand = new Command(BackExecute);
        }

        public CovidTest SelectedItem
        {
            get { return CovidTest; }
            set
            {
                CovidTest = value;
                OnPropertyChanged();
                OpenViewTestReport();
            }
        }

        private async void OpenViewTestReport()
        {
            if (CovidTest != null)
            {
                ViewTestReportVM.CovidTest = new CovidTest
                {
                    PatientName = CovidTest.PatientName,
                    Result = CovidTest.Result,
                    ResultDate = CovidTest.ResultDate,
                    Status = CovidTest.Status,
                    TestDate = CovidTest.TestDate,
                    TestID = CovidTest.TestID,
                    TestedBy = CovidTest.TestedBy
                };
                await Application.Current.MainPage.Navigation.PushAsync(new ViewTestReport());
                this.SelectedItem = null;
            }
        }

        private async void BackExecute(Object obj)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async void GetAllTests()
        {

            List<CovidTest> tests = await FirebaseDBConnection.GetAllTestsAsync();
            foreach (CovidTest test in tests)
            {
                CovidTestList.Add(test);
            }
        }

        public async void GetPatientTests()
        {

            List<CovidTest> tests = await FirebaseDBConnection.GetAllTestsAsync();
            List<User> users = await FirebaseDBConnection.GetAllUsersAsync();


                foreach (CovidTest test in tests)
                {
                    CovidTestList.Add(test);
                }

            }
        }



    }



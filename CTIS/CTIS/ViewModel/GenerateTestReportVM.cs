using CTIS.Model;
using CTIS.View;
using CTIS.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    class GenerateTestReportVM : BaseVM
    {
        public ObservableCollection<CovidTest> CovidTestList { get; set; }

        public CovidTest CovidTest { get; set; }

        public CovidTest SelectedItem
        {
            get { return CovidTest; }
            set
            {
                CovidTest = value;
                OnPropertyChanged();
            }
        }


        public async void GetAllTest()
        {
            List<CovidTest> tests = await FirebaseDBConnection.GetAllTestsAsync();
            foreach (CovidTest test in tests)
            {
                CovidTestList.Add(test);
            }
        }



    }
}

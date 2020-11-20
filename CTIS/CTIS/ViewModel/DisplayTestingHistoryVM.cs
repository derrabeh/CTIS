using CTIS.Model;
using CTIS.Utilities;
using CTIS.View;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CTIS.ViewModel
{
    class DisplayTestingHistoryVM : BaseVM
    {
        public static CovidTest CovidTest { get; set; }
        public Command SaveCommand { get; set; }
        public Command BackCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public DisplayTestingHistoryVM()
        {


            PatientName = CovidTest.PatientName;
            Result = CovidTest.Result;
            ResultDate = CovidTest.ResultDate;
            Status = CovidTest.Status;
            TestDate = CovidTest.TestDate;
            TestID = CovidTest.TestID;
            TestedBy = CovidTest.TestedBy;
        }

        public string PatientName
        {
            get { return CovidTest.PatientName; }
            set
            {
                CovidTest.PatientName = value;
                OnPropertyChanged();
            }
        }


        public string Result
        {
            get { return CovidTest.Result; }
            set
            {
                CovidTest.Result = value;
                OnPropertyChanged();
            }
        }

        public DateTime ResultDate
        {
            get { return CovidTest.ResultDate; }
            set
            {
                CovidTest.ResultDate = value;
                OnPropertyChanged();
            }
        }


        public DateTime TestDate
        {
            get { return CovidTest.TestDate; }
            set
            {
                CovidTest.TestDate = value;
                OnPropertyChanged();
            }
        }

        public string Status
        {
            get { return CovidTest.Status; }
            set
            {
                CovidTest.Status = value;
                OnPropertyChanged();
            }
        }

        public string TestID
        {
            get { return CovidTest.TestID; }
            set
            {
                CovidTest.TestID = value;
                OnPropertyChanged();
            }
        }

        public string TestedBy
        {
            get { return CovidTest.TestedBy; }
            set
            {
                CovidTest.TestedBy = value;
                OnPropertyChanged();
            }
        }
    }
}

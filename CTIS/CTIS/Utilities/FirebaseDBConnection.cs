using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using CTIS.Model;

namespace CTIS.Utilities
{
    public class FirebaseDBConnection
    {
        static FirebaseClient firebaseClient = new FirebaseClient("https://ctis-bmc208.firebaseio.com/");

        #region User methods
        public static async Task<List<User>> GetAllUsersAsync()
        {
            return (await firebaseClient.Child("User").OnceAsync<User>()).Select(
                item => new User
                {
                    UserID = item.Object.UserID,
                    Name = item.Object.Name,
                    Email = item.Object.Email,
                    Password = item.Object.Password,
                    Passport = item.Object.Passport,
                    DOB = item.Object.DOB,
                    Type = item.Object.Type
                }).ToList();
        }

        public static async Task<User> GetUserAsync(User user)
        {
            List<User> allUsers = await GetAllUsersAsync();
            return allUsers.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
        }

        //add patients 
        public static async Task AddUserAsync(User user)
        {
            user.UserID = Guid.NewGuid().ToString();
            user.Type = "Patient";
            await firebaseClient.Child("User").PostAsync(user);
        }

        //add testers
        public static async Task AddTesterAsync(User tester)
        {
            tester.UserID = Guid.NewGuid().ToString();
            tester.Type = "Tester";
            await firebaseClient.Child("User").PostAsync(tester);
        }

        #endregion

        #region CovidTest Methods
        public static async Task<List<CovidTest>> GetAllTestsAsync()
        {
            return (await firebaseClient.Child("CovidTest").OnceAsync<CovidTest>()).Select(
                item => new CovidTest
                {
                    TestID = item.Object.TestID,
                    PatientName = item.Object.TestID,
                    TestDate = item.Object.TestDate,
                    Result = item.Object.Result,
                    ResultDate = item.Object.ResultDate,
                    Status = item.Object.Status,
                    TestedBy = item.Object.TestedBy
                }).ToList();
        }

        public static async Task AddTestAsync(CovidTest test)
        {
            test.TestID = Guid.NewGuid().ToString();
            test.TestedBy = App.User.Name;
            await firebaseClient.Child("CovidTest").PostAsync(test);
        }
        #endregion

        #region TestCentre Methods

        public static async Task<List<TestCentre>> GetAllCentresAsync()
        {
            return (await firebaseClient.Child("TestCentre").OnceAsync<TestCentre>()).Select(
                item => new TestCentre
                {
                    CentreID = item.Object.CentreID,
                    CentreName = item.Object.CentreName,
                    PhoneNum = item.Object.PhoneNum,
                    OpeningTime = item.Object.OpeningTime,
                    ClosingTime = item.Object.ClosingTime,
                    Address = item.Object.Address
                }).ToList();
        }

        public static async Task AddCentreAsync(TestCentre centre)
        {
            centre.CentreID = Guid.NewGuid().ToString();
            await firebaseClient.Child("TestCentre").PostAsync(centre);
        }
        #endregion

        #region TestKit Methods
        public static async Task<List<TestKit>> GetAllKitsAsync()
        {
            return (await firebaseClient.Child("TestKit").OnceAsync<TestKit>()).Select(
                item => new TestKit
                {
                    //TestID = item.Object.TestID,
                    //PatientName = item.Object.TestID,
                    //TestDate = item.Object.TestDate,
                    //Result = item.Object.Result,
                    //ResultDate = item.Object.ResultDate,
                    //Status = item.Object.Status,
                    //TestedBy = item.Object.TestedBy
                }).ToList();
        }

        #endregion
    }
}

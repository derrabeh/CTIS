using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using CTIS.Model;

namespace CTIS.Utilities
{
    public class FirebaseDBConnection
    {
        static FirebaseClient firebaseClient = new FirebaseClient("https://ctis-bmc208.firebaseio.com/");

        //get all users, get specific user, add patient, add tester
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
            user.Type = "Officer";
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

        //Get all test, update test, add test
        #region CovidTest Methods
        public static async Task<List<CovidTest>> GetAllTestsAsync()
        {
            return (await firebaseClient.Child("CovidTest").OnceAsync<CovidTest>()).Select(
                item => new CovidTest
                {
                    TestID = item.Object.TestID,
                    PatientName = item.Object.PatientName,
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

        public static async Task DeleteTestAsync(CovidTest test)
        {
            var item = (await firebaseClient.Child("CovidTest").OnceAsync<CovidTest>()).
                Where(k => k.Object.TestID == test.TestID).FirstOrDefault();
            await firebaseClient.Child("CovidTest").Child(item.Key).DeleteAsync();
        }

        //Update test 
        public static async Task EditTestAsync(CovidTest test)
        {
            var item = (await firebaseClient.Child("CovidTest").OnceAsync<CovidTest>()).
                Where(t => t.Object.TestID == test.TestID).FirstOrDefault();
            await firebaseClient.Child("CovidTest").Child(item.Key).PutAsync(test);
        }
        #endregion

        //get all centre, add centre
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

        //get all kits, add kit, update kit, delete kit
        #region TestKit Methods
        public static async Task<List<TestKit>> GetAllKitsAsync()
        {
            return (await firebaseClient.Child("TestKit").OnceAsync<TestKit>()).Select(
                item => new TestKit
                {
                    KitID = item.Object.KitID,
                    KitName = item.Object.KitName,
                    CurrentStock = item.Object.CurrentStock,
                    LastUpdated = item.Object.LastUpdated,
                    Status = item.Object.Status,
                }).ToList();
        }

        public static async Task AddKitAsync(TestKit kit)
        {
            kit.KitID = Guid.NewGuid().ToString();
            await firebaseClient.Child("TestKit").PostAsync(kit);
        }

        //update kit
        public static async Task EditKitAsync(TestKit kit)
        {
            var item = (await firebaseClient.Child("TestKit").OnceAsync<TestKit>()).
                Where(k => k.Object.KitID == kit.KitID).FirstOrDefault();
            await firebaseClient.Child("TestKit").Child(item.Key).PutAsync(kit);
        }

        public static async Task DeleteKitAsync(TestKit kit)
        {
            var item = (await firebaseClient.Child("TestKit").OnceAsync<TestKit>()).
                Where(k => k.Object.KitID == kit.KitID).FirstOrDefault();
            await firebaseClient.Child("TestKit").Child(item.Key).DeleteAsync();
        }

        #endregion
    }
}

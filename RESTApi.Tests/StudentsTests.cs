using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RESTApi.Tests.Entities;

namespace RESTApi.Tests
{
    [TestClass]
    public class StudentsTests
    {
        [TestMethod]
        public void GetStudent()
        {
            var client = new RestClient("http://localhost:63348/api/Student/1");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            //IRestResponse response = client.Execute(request);

            IRestResponse<Student> response = client.Execute<Student>(request);

            Console.Out.WriteLine(response.IsSuccessful);
            Console.Out.WriteLine(response.Content);
            Console.Out.Write($"\n{response.Data.FirstName}\n{response.Data.LastName}\n{response.Data.Group.Name}");

            Assert.IsTrue(response.IsSuccessful);
       
        }
    }
}

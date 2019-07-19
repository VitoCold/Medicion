using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Auth;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApi.Models;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            var users = new Users();
            users.Request = new System.Web.HttpRequestBase();
            var result = await users.ValidateLoginAsync("administrador@contugas.com.pe", "Ctg2019.Admin");

            Assert.AreEqual(null, result);
        }
    }
}

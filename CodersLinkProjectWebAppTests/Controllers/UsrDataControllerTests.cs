using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using CodersLinkProjectWebApp.Models;
using CodersLinkProjectWebApp.Paths;
using CodersLinkProjectWebApp.Controllers;
using CodersLinkProjectWebApp.Repository.IRepository;

namespace CodersLinkProjectWebApp.Controllers.Tests
{
    [TestFixture()]
    public class UsrDataControllerTests
    {
        private UsrDataController _controller;
        private readonly IUsrDataRepo _usrDataRepo;

        [SetUp]
        public void SetUp()
        {
            _controller = new UsrDataController(_usrDataRepo);            
        }

        [Test]
        [Order(1)]
        public void IndexTest()
        {
            var result = _controller.Index();
            Assert.IsInstanceOf<ViewResult>(result);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lunchinator.Tests
{
    [TestClass]
    public class LunchServiceTests
    {
        //private Mock<IUserRepository> _userRepository;
        //private Mock<ILunchRepository> _lunchRepository;
        //private LunchService _lunchService;

        //[TestInitialize]
        //public void SetUp()
        //{
        //    var users = GetFakeUsers();
        //    _userRepository = new Mock<IUserRepository>();
        //    _userRepository.Setup(u => u.GetByLunchId(It.IsAny<int>())).Returns(users);

        //    _lunchRepository = new Mock<ILunchRepository>();
        //    _lunchService = new LunchService(_lunchRepository.Object);
        //}

       

        //[TestMethod]
        //public void CreateLunchAndAddToRepository()
        //{
        //    var form = new LunchForm
        //                   {
        //                      Name = "Test",
        //                      Date = DateTime.Today,
        //                      Time = "12",
        //                      Distance = 25
        //                   };

            
        //    var lunch = _lunchService.CreateLunch(form);
            
           
        //    Assert.IsNotNull(lunch.LunchId);
        //    Assert.AreEqual(form.Name, lunch.Name);
        //    Assert.AreEqual(form.Date, lunch.Date);
        //    Assert.AreEqual(form.Where, lunch.Where);
        //    Assert.AreEqual(form.Distance, lunch.Distance);

        //    _lunchRepository.Verify(l => l.Add(It.IsAny<Lunch>()), Times.Once());
        //}

        //[TestMethod]
        //public void AddUserToLunch()
        //{
        //    var lunch = new Lunch();
        //    string id = "lunchId";
        //    _lunchRepository.Setup(l => l.GetById(id)).Returns(lunch);

        //    string emailAddress = "my email address";
        //    var form = new InviteForm { LunchId = id, EmailAddress = emailAddress };
        //    _lunchService.InviteUserToLunch(form);

        //    Assert.AreEqual(1, lunch.Invitations.Count);

        //}

        //[TestMethod]
        //[ExpectedException(typeof(LunchDoesNotExistException))]
        //public void ThrowExceptionWhenAddingUserToLunchThatDoesntExsit()
        //{
        //    var form = new InviteForm { LunchId = "123", EmailAddress = "emailAddress" };
        //    _lunchService.InviteUserToLunch(form);
        //}


        //private IEnumerable<User> GetFakeUsers()
        //{
        //    return new List<User>
        //               {
        //                   new User{PreferredCategories = new List<string>{"hotdogs", "pizza"}},
        //                   new User{PreferredCategories = new List<string>{"hotdogs", "burgers"}}
        //               };
        //}

    }
}

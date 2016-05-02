
namespace FizzBuzz.Tests.Controllers
{
    using FizzBuzzBL;
    using FizzBuzzWebsite.Controllers;
    using FizzBuzzDomainModel;
    using FizzBuzzWebsite.Models;
    using Moq;
    using NUnit.Framework;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class FizzBuzzControllerTest
    {

        [TestFixture]
        public class FizzBuzzUITest
        {
            FizzBuzzViewModel fizzBuzzViewModelCollection = new FizzBuzzViewModel();
            FizzBuzzController fizzBuzzController;
            private Mock<IFizzBuzzManager> fizzBuzzManager;

            [SetUp]
            public void IntialTestSetup()
            {
                //Create Mock object FizzBuzz Business Logic
                fizzBuzzManager = new Mock<IFizzBuzzManager>();
            }

            /// <summary>
            /// tests to Validate the min and max numbers
            /// </summary>
            [Test]
            public void MinNumberValidation()
            {
                //Arrange
                fizzBuzzViewModelCollection.InputNumber = 1;

                //Act
                var result = Validator.TryValidateObject(fizzBuzzViewModelCollection, new ValidationContext(fizzBuzzViewModelCollection, null, null), null, true);

                //Assert
                Assert.AreEqual(true, result);
            }

            [Test]
            public void MaxNumberValidation()
            {
                //Arrange
                fizzBuzzViewModelCollection.InputNumber = 1000;

                //Asct
                var result = Validator.TryValidateObject(fizzBuzzViewModelCollection, new ValidationContext(fizzBuzzViewModelCollection, null, null), null, true);

                //Assert
                Assert.AreEqual(true, result);
            }
            /// <summary>
            /// Test to check both View and Model by Mocking the business logic layer
            /// </summary>
            [Test]
            public void DisplayFizzBuzzReturnsViewModel()
            {
                // Arrange                   
                fizzBuzzViewModelCollection.InputNumber = 50;
                //Mockup function call in FizzBuzz Business logic
                fizzBuzzManager.Setup(FizzBuzzMock => FizzBuzzMock.Generate(It.IsAny<int>())).Returns(GetMockFizzBuzz(50));
                fizzBuzzController = new FizzBuzzController(fizzBuzzManager.Object);

                // Act
                var result = fizzBuzzController.DisplayFizzBuzz(fizzBuzzViewModelCollection) as ViewResult;
                fizzBuzzViewModelCollection = (FizzBuzzViewModel)result.Model;

                // Assert
                Assert.AreEqual("FizzBuzzViewModel", result.Model.GetType().Name);
                Assert.AreEqual(50, fizzBuzzViewModelCollection.DisplayList.Count);
                Assert.AreEqual("Display", result.ViewName);
            }


            /// <summary>
            /// Mock Function to mock the businesslogic
            /// </summary>
            /// <param name="inputNum"></param>
            /// <returns>DomainModeCollectionMock</returns>
            private FizzBuzzDomainModel GetMockFizzBuzz(int inputNum)
            {
                var fizzBuzzDomainModelCollection = new FizzBuzzDomainModel();
                for (int i = 1; i <= inputNum; i++)
                {
                    fizzBuzzDomainModelCollection.DisplayList.Add(new FizzBuzzDomainData { ItemValue = i.ToString(), DisplayText = i.ToString() });
                }
                return fizzBuzzDomainModelCollection;
            }

        }
    }
}

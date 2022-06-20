using NUnit.Framework;
using SES.Models.Enumerations;
using SES.Models.ViewModels;
using SES.Services.Abstract;
using SES.Services.Concrete;

namespace SES.Api.Test
{
	public class KataServiceTests
	{
		private IKataService kataService;

		[SetUp]
		public void Setup()
		{
			this.kataService = new KataService();
		}

		[Test]
		public void FindOddNumberTimes_ShouldResultAreEqualToSuccess()
		{
			//Arrange
			int[] numberList = { 0 };
			var kataRequestModel = new KataRequestModel
			{
				NumberList = numberList
			};

			//Act
			var result = this.kataService.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.AreEqual(ResultModelTypeEnum.SUCCESS, result.Type);
			var resultMessage = int.Parse(result.Message.Split('=')[1]);
			Assert.AreEqual(0, resultMessage);
		}

		[Test]
		public void FindOddNumberTimes_ShouldResultAreEqualToError()
		{
			//Arrange
			var kataRequestModel = new KataRequestModel();

			//Act
			var result = this.kataService.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.AreEqual(ResultModelTypeEnum.ERROR, result.Type);
		}
	}
}
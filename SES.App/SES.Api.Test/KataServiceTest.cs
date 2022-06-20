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
		public void FindOddNumberTimes_ShouldResultTypeAreEqualToSuccess()
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
		public void FindOddNumberTimes_ShouldResultTypeAreEqualToError()
		{
			//Arrange
			var kataRequestModel = new KataRequestModel();

			//Act
			var result = this.kataService.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.AreEqual(ResultModelTypeEnum.ERROR, result.Type);
		}

		[Test]
		public void FindOddNumberTimes_ShouldResultAreEqualToNumber()
		{
			//Arrange
			int[] numberList = { 0, 0, 1 };
			var kataRequestModel = new KataRequestModel
			{
				NumberList = numberList
			};

			//Act
			var result = this.kataService.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.AreEqual(ResultModelTypeEnum.SUCCESS, result.Type);
			var resultMessage = int.Parse(result.Message.Split('=')[1]);
			Assert.AreEqual(1, resultMessage);
		}

		[Test]
		public void FindOddNumberTimes_ShouldResultTypeAreEqualToWarning()
		{
			//Arrange
			int[] numberList = { 0, 1 };
			var kataRequestModel = new KataRequestModel
			{
				NumberList = numberList
			};

			//Act
			var result = this.kataService.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.AreEqual(ResultModelTypeEnum.WARNING, result.Type);
		}

		[Test]
		public void FindOddNumberTimes_ShouldResultTypeAreEqualToErrorWithoutOddNumber()
		{
			//Arrange
			int[] numberList = { 0, 0, 1, 1 };
			var kataRequestModel = new KataRequestModel
			{
				NumberList = numberList
			};

			//Act
			var result = this.kataService.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.AreEqual(ResultModelTypeEnum.ERROR, result.Type);
		}
	}
}
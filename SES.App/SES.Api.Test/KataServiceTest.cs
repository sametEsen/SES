using Moq;
using NUnit.Framework;
using SES.Models.Enumerations;
using SES.Models.ViewModels;
using SES.Services.Abstract;

namespace SES.Api.Test
{
	public class KataServiceTests
	{
		private Mock<IKataService> kataServiceMock;

		[SetUp]
		public void Setup()
		{
			this.kataServiceMock = new Mock<IKataService>();
		}

		[Test]
		public void FindOddNumberTimes_ShouldResultTypeAreEqualToError()
		{
			//Arrange
			var kataRequestModel = new KataRequestModel();
			var kataResponseModel = new ResultModel
			{
				Type = ResultModelTypeEnum.ERROR,
				Message = "The integer list should be declared!"
			};
			this.kataServiceMock.Setup(x => x.FindOddNumberTimes(kataRequestModel.NumberList)).Returns(kataResponseModel);

			//Act
			var result = this.kataServiceMock.Object.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.That(result, Is.EqualTo(kataResponseModel));
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
			var kataResponseModel = new ResultModel
			{
				Type = ResultModelTypeEnum.SUCCESS,
				Message = "Result = 0"
			};
			this.kataServiceMock.Setup(x => x.FindOddNumberTimes(kataRequestModel.NumberList)).Returns(kataResponseModel);
			
			//Act
			var result = this.kataServiceMock.Object.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.That(result, Is.EqualTo(kataResponseModel));
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
			var kataResponseModel = new ResultModel
			{
				Type = ResultModelTypeEnum.ERROR,
				Message = "There has been nothing found odd numbers of times."
			};
			this.kataServiceMock.Setup(x => x.FindOddNumberTimes(kataRequestModel.NumberList)).Returns(kataResponseModel);

			//Act
			var result = this.kataServiceMock.Object.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.That(result, Is.EqualTo(kataResponseModel));
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
			var kataResponseModel = new ResultModel
			{
				Type = ResultModelTypeEnum.WARNING,
				Message = "There has been found more then one results -> 0, 1"
			};
			this.kataServiceMock.Setup(x => x.FindOddNumberTimes(kataRequestModel.NumberList)).Returns(kataResponseModel);

			//Act
			var result = this.kataServiceMock.Object.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.That(result, Is.EqualTo(kataResponseModel));
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
			var kataResponseModel = new ResultModel
			{
				Type = ResultModelTypeEnum.SUCCESS,
				Message = "Result = 1"
			};
			this.kataServiceMock.Setup(x => x.FindOddNumberTimes(kataRequestModel.NumberList)).Returns(kataResponseModel);

			//Act
			var result = this.kataServiceMock.Object.FindOddNumberTimes(kataRequestModel.NumberList);

			//Assert
			Assert.That(result, Is.EqualTo(kataResponseModel));
		}
	}
}
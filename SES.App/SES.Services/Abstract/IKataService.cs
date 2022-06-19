using SES.Models.ViewModels;

namespace SES.Services.Abstract
{
	public interface IKataService
	{
		ResultModel FindOddNumberTimes(int[] seq);
	}
}

using SES.Models.Enumerations;

namespace SES.Models.ViewModels
{
	public class ResultModel
	{
		public ResultModelTypeEnum Type { get; set; }
		public string Message { get; set; } = string.Empty;
	}
}

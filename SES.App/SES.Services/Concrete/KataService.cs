using SES.Models.Enumerations;
using SES.Models.ViewModels;
using SES.Services.Abstract;

namespace SES.Services.Concrete
{
	public class KataService : IKataService
	{
        public ResultModel FindOddNumberTimes(int[] seq)
        {
            if (seq.Length == 1)
            {
                return new ResultModel
                {
                    Type = ResultModelTypeEnum.SUCCESS,
                    Message = "Result = " + seq[0]
                };
            }

            var seqGroupedBy = seq.GroupBy(s => s).Select(x => new {
                Val = x.First(),
                Count = x.Count()
            }).ToList();

            var results = seqGroupedBy.Where(sq => sq.Count % 2 != 0).ToList();
            if (results.Count == 0)
            {
                return new ResultModel
                {
                    Type = ResultModelTypeEnum.ERROR,
                    Message = "There has been nothing found odd numbers of times."
                };
            }

            if (results.Count > 1)
            {
                var duplicatedValues = results.Select(r => r.Val);
                return new ResultModel
                {
                    Type = ResultModelTypeEnum.WARNING,
                    Message = "There has been found more then one results -> " + string.Join(",", duplicatedValues)
                };
            }

            return new ResultModel
            {
                Type = ResultModelTypeEnum.SUCCESS,
                Message = "Result = " + results.First().Val
            };
        }
    }
}

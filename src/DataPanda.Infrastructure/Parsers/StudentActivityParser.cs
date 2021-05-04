using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using ExcelDataReader;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataPanda.Infrastructure.Parsers
{
    public class StudentActivityParser : IParser<IEnumerable<StudentActivity>>
    {
        public Task<Result<IEnumerable<StudentActivity>>> Parse(Stream streamToParse)
        {
            streamToParse.Position = 0;
            var reader = ExcelReaderFactory.CreateReader(streamToParse);

            var studentActivities = new List<StudentActivity>();
            var isHeaderRow = true;

            while (reader.Read())
            {
                if (isHeaderRow)
                {
                    var idHeader = reader.GetValue(0)?.ToString();
                    if (idHeader is null || idHeader != "Time")
                    {
                        return Result.Failure<IEnumerable<StudentActivity>>("The file type is not StudentActivity.");
                    }

                    isHeaderRow = false;
                    continue;
                }

                var eventContext = reader.GetValue(1)?.ToString();
                if (eventContext is null)
                {
                    continue;
                }

                var component = reader.GetValue(2)?.ToString();
                if (component is null)
                {
                    continue;
                }

                var eventName = reader.GetValue(3)?.ToString();
                if (eventName is null)
                {
                    continue;
                }

                var description = reader.GetValue(4)?.ToString();
                if (description is null)
                {
                    continue;
                }

                var studentActivity = new StudentActivity(eventContext, component, eventName, description);
                studentActivities.Add(studentActivity);
            }

            return Task.FromResult(Result.Success(studentActivities.AsEnumerable()));
        }
    }
}

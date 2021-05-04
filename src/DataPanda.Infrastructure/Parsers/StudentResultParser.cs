using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataPanda.Infrastructure.Parsers
{
    public class StudentResultParser : IParser<IEnumerable<StudentResult>>
    {
        public Task<Result<IEnumerable<StudentResult>>> Parse(Stream streamToParse)
        {
            streamToParse.Position = 0;
            var reader = ExcelReaderFactory.CreateReader(streamToParse);

            var studentResults = new List<StudentResult>();
            var isHeaderRow = true;

            while (reader.Read())
            {
                if (isHeaderRow)
                {
                    var idHeader = reader.GetValue(0)?.ToString();
                    if (idHeader is null || idHeader != "ID")
                    {
                        return Result.Failure<IEnumerable<StudentResult>>("The file type is not StudentResult.");
                    }

                    isHeaderRow = false;
                    continue;
                }

                var studentIdParseResult = ParseColumnValue(reader.GetValue(0)?.ToString(), int.Parse);
                if (!studentIdParseResult.Succeeded)
                {
                    continue;
                }

                var studentResultParseResult = ParseColumnValue(reader.GetValue(1)?.ToString(), double.Parse);
                if (!studentResultParseResult.Succeeded)
                {
                    continue;
                }

                var studentResult = new StudentResult(studentIdParseResult.SuccessPayload, studentResultParseResult.SuccessPayload);
                studentResults.Add(studentResult);
            }

            return Task.FromResult(Result.Success(studentResults.AsEnumerable()));
        }

        private Result<TColumnValue> ParseColumnValue<TColumnValue>(string? value, Func<string, TColumnValue> parseDelegate)
        {
            var failedResult = "The file contains an invalid column value.";

            if (value is null)
            {
                return failedResult;
            }

            try
            {
                return parseDelegate(value);
            }
            catch (Exception)
            {
                return failedResult;
            }
        }
    }
}

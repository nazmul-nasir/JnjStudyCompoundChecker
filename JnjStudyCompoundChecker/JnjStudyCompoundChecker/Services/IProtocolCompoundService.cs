using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JnjStudyCompoundChecker.Models.ResponseModels;

namespace JnjStudyCompoundChecker.Services
{
    public interface IProtocolCompoundService
    {
        Task<List<ProtocolCompoundResponse>> GetProtocolCompoundResponse(List<string> protocolNumbers, DateTime dateTime);
    }
}

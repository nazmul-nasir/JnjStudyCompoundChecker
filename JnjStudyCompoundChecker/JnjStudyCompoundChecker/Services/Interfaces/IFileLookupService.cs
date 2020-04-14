using System.Collections.Generic;

namespace JnjStudyCompoundChecker.Services.Interfaces
{
    public interface IFileLookupService
    {
        Dictionary<string, string> GetFiles();
    }
}

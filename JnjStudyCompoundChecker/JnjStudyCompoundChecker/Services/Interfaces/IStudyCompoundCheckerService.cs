using System;
using System.Collections.Generic;

namespace JnjStudyCompoundChecker.Services.Interfaces
{
    public interface IStudyCompoundCheckerService
    {
        Tuple<int, List<string>> ExecuteChecking();
    }
}

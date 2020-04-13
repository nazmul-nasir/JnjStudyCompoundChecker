using System.IO;

namespace JnjStudyCompoundChecker.Services
{
    public interface IEntityModelLoaderService
    {
        string ReadLocalFile(string file);
        StreamReader GetStreamReader(string text);
        string GetSubString(string text, string startText, string endText, bool replace = false);
        void GetEntityModels(string file);
    }
}

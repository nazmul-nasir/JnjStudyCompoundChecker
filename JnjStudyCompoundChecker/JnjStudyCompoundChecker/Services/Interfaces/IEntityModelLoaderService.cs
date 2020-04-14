using JnjStudyCompoundChecker.Models.HelperModels;

namespace JnjStudyCompoundChecker.Services.Interfaces
{
    public interface IEntityModelLoaderService
    {
        ModelContainer GetEntityModels(string file);
    }
}

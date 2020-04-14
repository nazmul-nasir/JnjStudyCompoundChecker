using System;
using System.IO;
using System.Text;
using JnjStudyCompoundChecker.Constants;
using JnjStudyCompoundChecker.Helper;
using JnjStudyCompoundChecker.Models.EntityModels;
using JnjStudyCompoundChecker.Models.HelperModels;
using JnjStudyCompoundChecker.Services.Interfaces;

namespace JnjStudyCompoundChecker.Services.Implementations
{
    public class EntityModelLoaderService : IEntityModelLoaderService
    {
        private static string OldValue { get; set; }
        private static string NewValue { get; set; }

        private static string ReadLocalFile(string file)
        {
            try
            {
                var xmlText = File.ReadAllText(file, Encoding.UTF8);
                return xmlText;
            }
            catch (Exception e)
            {
                LogHelper.PrintLog($"File read error for file: {file}, error details: {e}");
                throw;
            }
        }

        private static StreamReader GetStreamReader(string text)
        {
            var byteArray = Encoding.UTF8.GetBytes(text);
            var stream = new MemoryStream(byteArray);
            var reader = new StreamReader(stream);
            return reader;
        }

        private static string GetSubString(string text, string startText, string endText, bool replace = false)
        {
            var start = text.IndexOf(startText, StringComparison.Ordinal);
            if (start < 0) return string.Empty;
            var end = text.IndexOf(endText, StringComparison.Ordinal) + endText.Length;
            var subStr = text.Substring(start, end - start);

            if (!replace) return subStr;
            subStr = subStr.Replace(OldValue, NewValue);
            return subStr;
        }

        public ModelContainer GetEntityModels(string file)
        {
            LogHelper.PrintLog($"Start loading entity models for file: {file}");

            try
            {
                StreamReader reader;
                var container = new ModelContainer();
                var text = ReadLocalFile(file);

                #region Load ClinicalTrialData
                OldValue = Common.EndTag;
                NewValue = Common.ClinicalTrialDataEnd;
                var subStr = GetSubString(text, Common.ClinicalTrialDataStart, Common.EndTag, true);
                container.ClinicalTrialData = XmlSerializer.LoadClinicalTrialData(subStr);
                #endregion

                #region Compound
                subStr = GetSubString(text, Common.CompoundsStart, Common.CompoundsEnd);
                if (!string.IsNullOrEmpty(subStr))
                {
                    reader = GetStreamReader(subStr);
                    container.Compounds = XmlSerializer.Deserializer<Compound>(reader, RootName.Compounds);
                    LogHelper.PrintLog($"Total Compound found: {container.Compounds.Count}");
                }
                #endregion

                #region Study
                OldValue = Common.CountryText;
                NewValue = Common.StringText;
                subStr = GetSubString(text, Common.StudiesStart, Common.StudiesEnd, true);
                if (!string.IsNullOrEmpty(subStr))
                {
                    reader = GetStreamReader(subStr);
                    container.Studies = XmlSerializer.Deserializer<Study>(reader, RootName.Studies);
                    LogHelper.PrintLog($"Total Study found: {container.Studies.Count}");
                }
                #endregion
                
                LogHelper.PrintLog($"Completed loading entity models for file : {file}");
                return container;
            }
            catch (Exception e)
            {
                LogHelper.PrintLog($"Exception occurred while loading entity models. Details: {e}");
                throw;
            }
        }
    }
}
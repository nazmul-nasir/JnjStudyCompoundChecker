using System;
using System.IO;
using System.Text;
using JnjStudyCompoundChecker.Constants;
using JnjStudyCompoundChecker.Helper;
using JnjStudyCompoundChecker.Models.EntityModels;
using JnjStudyCompoundChecker.Models.HelperModels;

namespace JnjStudyCompoundChecker.Services
{
    public class EntityModelLoaderService : IEntityModelLoaderService
    {
        private static string OldValue { get; set; }
        private static string NewValue { get; set; }

        public string ReadLocalFile(string file)
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

        public StreamReader GetStreamReader(string text)
        {
            var byteArray = Encoding.UTF8.GetBytes(text);
            var stream = new MemoryStream(byteArray);
            var reader = new StreamReader(stream);
            return reader;
        }

        public string GetSubString(string text, string startText, string endText, bool replace = false)
        {
            var start = text.IndexOf(startText, StringComparison.Ordinal);
            if (start < 0) return string.Empty;
            var end = text.IndexOf(endText, StringComparison.Ordinal) + endText.Length;
            var subStr = text.Substring(start, end - start);

            if (!replace) return subStr;
            subStr = subStr.Replace(OldValue, NewValue);
            return subStr;
        }

        public void LoadEntityModels(string file)
        {
            LogHelper.PrintLog($"Start loading entity models for file: {file}");

            try
            {
                StreamReader reader;
                var _container = new ModelContainer();
                var text = ReadLocalFile(file);

                #region Load ClinicalTrialData

                OldValue = Common.EndTag;
                NewValue = Common.ClinicalTrialDataEnd;
                var subStr = GetSubString(text, Common.ClinicalTrialDataStart, Common.EndTag, true);
                _container.ClinicalTrialData = XmlSerializer.LoadClinicalTrialData(subStr);

                #endregion

                #region Compound

                subStr = GetSubString(text, Common.CompoundsStart, Common.CompoundsEnd);
                if (!string.IsNullOrEmpty(subStr))
                {
                    reader = GetStreamReader(subStr);
                    _container.Compounds = XmlSerializer.Deserializer<Compound>(reader, RootName.Compounds);
                    LogHelper.PrintLog($"Total Compound found: {_container.Compounds.Count}");
                }

                #endregion

                #region TA

                subStr = GetSubString(text, Common.TherapeuticAreasStart, Common.TherapeuticAreasEnd);
                if (!string.IsNullOrEmpty(subStr))
                {
                    reader = GetStreamReader(subStr);
                    _container.TherapeuticAreas =
                        XmlSerializer.Deserializer<TherapeuticArea>(reader, RootName.TherapeuticAreas);
                    LogHelper.PrintLog($"Total Therapeutic Area found: {_container.TherapeuticAreas.Count}");
                }

                #endregion

                #region Indication

                subStr = GetSubString(text, Common.IndicationsStart, Common.IndicationsEnd);
                if (!string.IsNullOrEmpty(subStr))
                {
                    reader = GetStreamReader(subStr);
                    _container.Indications = XmlSerializer.Deserializer<Indication>(reader, RootName.Indications);
                    LogHelper.PrintLog($"Total Indication found: {_container.Indications.Count}");
                }

                #endregion

                #region Study

                OldValue = Common.CountryText;
                NewValue = Common.StringText;
                subStr = GetSubString(text, Common.StudiesStart, Common.StudiesEnd, true);
                if (!string.IsNullOrEmpty(subStr))
                {
                    reader = GetStreamReader(subStr);
                    _container.Studies = XmlSerializer.Deserializer<Study>(reader, RootName.Studies);
                    LogHelper.PrintLog($"Total Study found: {_container.Studies.Count}");
                }

                #endregion
            }
            catch (Exception e)
            {
                LogHelper.PrintLog($"Exception occurred while loading entity models. Details: {e}");
                throw;
            }
            LogHelper.PrintLog($"Completed loading entity models for file : {file}");
        }
    }
}
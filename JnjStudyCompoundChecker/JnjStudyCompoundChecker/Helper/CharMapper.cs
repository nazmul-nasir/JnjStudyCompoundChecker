using System;
using System.Collections.Generic;

namespace JnjStudyCompoundChecker.Helper
{
    public enum CharMapperType
    {
        SetToNormalChar,
        SetToSpecialChar
    }

    public class CharMapper
    {
        private const string TagStartString = "<string>";
        private const string TagStartCountry = "<Country>";

        private const string TagEndString = "</string>";
        private const string TagEndCountry = "</Country>";

        private const string EndTag = "/>";
        private const string EndTagSpecial = " />";

        private const string Empty = "";
        private const string StudyAssociations = "<StudyAssociations />";
        private const string StudyCountryAssociations = "<StudyCountryAssociations />";
        private const string StudySiteAssociations = "<StudySiteAssociations />";
        private const string CompoundAssociations = "<CompoundAssociations />";
        private const string CountryAssociations = "<CountryAssociations />";

        public static readonly List<Tuple<string, string>> SpecialCharMap = new List<Tuple<string, string>>
        {
            //Tuple.Create(EndTagSpecial, EndTag),

            Tuple.Create(TagStartString, TagStartCountry),
            Tuple.Create(TagEndString, TagEndCountry),

            Tuple.Create(StudyAssociations, Empty),
            Tuple.Create(StudyCountryAssociations, Empty),
            Tuple.Create(StudySiteAssociations, Empty),
            Tuple.Create(CompoundAssociations, Empty),
            Tuple.Create(CountryAssociations, Empty)
        };

        public static string MapToActualText(string text)
        {
            try
            {
                foreach (var item in SpecialCharMap)
                {
                    var oldVal = item.Item1;
                    var newVal = item.Item2;
                    
                    if (text.Contains(oldVal))
                        text = text.Replace(oldVal, newVal);
                }

                return text;
            }
            catch (Exception e)
            {
                LogHelper.PrintLog($"Error occured during mapping: {e}");
                return "";
            }
        }
    }
}

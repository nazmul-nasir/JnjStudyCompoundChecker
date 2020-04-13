using System.IO;
using System.Reflection;

namespace JnjStudyCompoundChecker.Constants
{
    public class Common
    {
        #region other
        public const string Invalid = "Invalid";
        public const string ErrorLog = "ErrorLog";
        public const string CountryText = "Country";
        public const string StringText = "string";
        public const string TrialDataNode = @"<ClinicalTrialData correlationId=""{0}"" creationDateTime=""{1}"" clientName=""{2}"" clientType=""{3}"" notificationEmail=""{4}"">";
        public const string TrialFailuresNode = @"<ClinicalTrialFailures xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" correlationId=""{0}"" creationDateTime=""{1}"">";
        #endregion

        #region xml values
        public const string XmlnsText = @"xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""";
        public const string XmlVersion = @"<?xml version=""1.0"" encoding=""utf-16""?>";
        public const string XmlHeader = @"<?xml version=""1.0"" encoding=""utf-8""?>";
        #endregion

        #region file path
        public static readonly string ContentsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Contents");
        #endregion

        #region entity nodes
        public const string ClinicalTrialDataStart = "<ClinicalTrialData";
        public const string ClinicalTrialDataEnd = "\"></ClinicalTrialData>";
        public const string EndTag = "\">";

        public const string CompoundsStart = "<Compounds>";
        public const string CompoundsEnd = "</Compounds>";
        public const string TherapeuticAreasStart = "<TherapeuticAreas>";
        public const string TherapeuticAreasEnd = "</TherapeuticAreas>";
        public const string IndicationsStart = "<Indications>";
        public const string IndicationsEnd = "</Indications>";
        public const string StudiesStart = "<Studies>";
        public const string StudiesEnd = "</Studies>";
        public const string StudyTeamsStart = "<StudyTeams>";
        public const string StudyTeamsEnd = "</StudyTeams>";
        public const string StudySitesStart = "<StudySites>";
        public const string StudySitesEnd = "</StudySites>";
        public const string UserAccountsStart = "<UserAccounts>";
        public const string UserAccountsEnd = "</UserAccounts>";
        #endregion

        #region clinical trial data attributes
        public const string CorrelationId = "correlationId";
        public const string CreationDateTime = "creationDateTime";
        public const string ClientName = "clientName";
        public const string ClientType = "clientType";
        public const string NotificationEmail = "notificationEmail";
        public const string NotificationEmailRemove = "notificationEmail=\"\"";
        #endregion
    }
}

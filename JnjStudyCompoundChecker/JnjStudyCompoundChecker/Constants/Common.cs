﻿namespace JnjStudyCompoundChecker.Constants
{
    public class Common
    {
        #region Other
        public const string CountryText = "Country";
        public const string StringText = "string";
        public const string Ctms = "Ctms_";
        public const string _2020 = "_2020";
        public const string ProtocolName = "<Protocol_Name>";
        public const string EnvironmentName = "<Environment_Name>";
        public const string TrialDataNode = @"<ClinicalTrialData correlationId=""{0}"" creationDateTime=""{1}"" clientName=""{2}"" clientType=""{3}"" notificationEmail=""{4}"">";
        public const string TrialFailuresNode = @"<ClinicalTrialFailures xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" correlationId=""{0}"" creationDateTime=""{1}"">";
        #endregion

        #region Entity Nodes
        public const string ClinicalTrialDataStart = "<ClinicalTrialData";
        public const string ClinicalTrialDataEnd = "\"></ClinicalTrialData>";
        public const string EndTag = "\">";

        public const string CompoundsStart = "<Compounds>";
        public const string CompoundsEnd = "</Compounds>";
        public const string StudiesStart = "<Studies>";
        public const string StudiesEnd = "</Studies>";
        #endregion

        #region Clinical Trial Data Attributes
        public const string CorrelationId = "correlationId";
        public const string CreationDateTime = "creationDateTime";
        public const string ClientName = "clientName";
        public const string ClientType = "clientType";
        public const string NotificationEmail = "notificationEmail";
        #endregion
    }
}

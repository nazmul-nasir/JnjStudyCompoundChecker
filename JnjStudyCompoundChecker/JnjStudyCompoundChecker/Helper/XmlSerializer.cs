using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using JnjStudyCompoundChecker.Constants;
using JnjStudyCompoundChecker.Models.EntityModels;

namespace JnjStudyCompoundChecker.Helper
{
    public class XmlSerializer
    {
        public static List<T> Deserializer<T>(StreamReader reader, string root) where T : class
        {
            try
            {
                var deserializer = new System.Xml.Serialization.XmlSerializer
                (
                    typeof(List<T>),
                    new XmlRootAttribute(root)
                );

                var obj = (List<T>)deserializer.Deserialize(reader);
                return obj;
            }
            catch (Exception e)
            {
                LogHelper.PrintLog($"Error during deserializing, due to: {e}");
                throw;
            }
        }

        public static ClinicalTrialData LoadClinicalTrialData(string trialData)
        {
            var doc = new XmlDocument();
            doc.LoadXml($"<xml>{trialData}</xml>");
            var node = doc.DocumentElement.SelectSingleNode(RootName.ClinicalTrialData);

            var correlationId = node.Attributes[Common.CorrelationId]?.InnerText;
            var creationDateTime = node.Attributes[Common.CreationDateTime]?.InnerText;
            var clientName = node.Attributes[Common.ClientName]?.InnerText;
            var clientType = node.Attributes[Common.ClientType]?.InnerText;
            var notificationEmail = node.Attributes[Common.NotificationEmail]?.InnerText;

            return new ClinicalTrialData
            {
                CorrelationId = correlationId,
                CreationDateTime = creationDateTime,
                ClientName = clientName,
                ClientType = clientType,
                NotificationEmail = notificationEmail
            };
        }
    }
}

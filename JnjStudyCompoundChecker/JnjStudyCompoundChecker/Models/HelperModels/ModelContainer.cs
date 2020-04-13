using System.Collections.Generic;
using JnjStudyCompoundChecker.Models.EntityModels;

namespace JnjStudyCompoundChecker.Models.HelperModels
{
    public class ModelContainer
    {
        public Dictionary<string, string> EntityLastModified;
        public Dictionary<string, string> EntityXmlString;

        public ClinicalTrialData ClinicalTrialData;

        public List<Sponsor> Sponsors;
        public List<Compound> Compounds;
        public List<TherapeuticArea> TherapeuticAreas;
        public List<Indication> Indications;
        public List<Study> Studies;
        public List<StudyTeam> StudyTeams;
        public List<StudySite> StudySites;

        public List<UserAccount> UserAccounts;
        public List<UserAccount> SiteUserAccounts;
        public List<UserAccount> SiteUserAccountsForIteration;
        public List<UserAccount> InactiveSiteUserAccounts;
        public List<UserAccount> TeamUserAccounts;
        public List<UserAccount> TeamUserAccountsForIteration;
        public List<UserAccount> InactiveTeamUserAccounts;
        public List<UserAccount> PortalUserAccounts;

        public ModelContainer()
        {
            EntityLastModified = new Dictionary<string, string>();
            EntityXmlString = new Dictionary<string, string>();

            ClinicalTrialData = new ClinicalTrialData();

            Sponsors = new List<Sponsor>();
            Compounds = new List<Compound>();
            TherapeuticAreas = new List<TherapeuticArea>();
            Indications = new List<Indication>();
            Studies = new List<Study>();
            StudyTeams = new List<StudyTeam>();
            StudySites = new List<StudySite>();

            UserAccounts = new List<UserAccount>();
            SiteUserAccounts = new List<UserAccount>();
            SiteUserAccountsForIteration = new List<UserAccount>();
            InactiveSiteUserAccounts = new List<UserAccount>();
            TeamUserAccounts = new List<UserAccount>();
            TeamUserAccountsForIteration = new List<UserAccount>();
            InactiveTeamUserAccounts = new List<UserAccount>();
            PortalUserAccounts = new List<UserAccount>();
        }

        public void ClearModelContainer()
        {
            EntityLastModified.Clear();
            EntityXmlString.Clear();

            ClinicalTrialData = null;

            Sponsors.Clear();
            Compounds.Clear();
            TherapeuticAreas.Clear();
            Indications.Clear();
            Studies.Clear();
            StudyTeams.Clear();
            StudySites.Clear();

            UserAccounts.Clear();
            SiteUserAccounts.Clear();
            TeamUserAccounts.Clear();
            PortalUserAccounts.Clear();
        }
    }
}

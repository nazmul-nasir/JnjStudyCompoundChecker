namespace JnjStudyCompoundChecker.Constants
{
    public class Enums
    {
        public enum LookupPath
        {
            Archived,
            Failed,
            Processing
        }

        public enum MailBody
        {
            FileNotFoundBody,
            ProcessingFailedBody,
            CompoundMismatchBody
        }
    }
}

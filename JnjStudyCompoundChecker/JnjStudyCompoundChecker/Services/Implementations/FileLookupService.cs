using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JnjStudyCompoundChecker.Constants;
using JnjStudyCompoundChecker.Models.AppSettingsModels;
using JnjStudyCompoundChecker.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace JnjStudyCompoundChecker.Services.Implementations
{
    public class FileLookupService : IFileLookupService
    {
        public bool LookupInAllPaths { get; set; }

        private readonly IOptions<LookupPathSettings> _lookupPathSettings;
        private Dictionary<int, Enums.LookupPath> LookupSequence { get; }
        
        public FileLookupService(IOptions<LookupPathSettings> lookupPathSettings)
        {
            _lookupPathSettings = lookupPathSettings;

            bool.TryParse(Program.Configuration.GetSection("LookupInAllPaths").Value, out var lookupInAllPaths);
            LookupInAllPaths = lookupInAllPaths;

            LookupSequence = new Dictionary<int, Enums.LookupPath>
            {
                {1, Enums.LookupPath.Failed},
                {2, Enums.LookupPath.Processing},
                {3, Enums.LookupPath.Archived}
            };
        }

        private string GetLookupPath(Enums.LookupPath lookupPath)
        {
            switch (lookupPath)
            {
                case Enums.LookupPath.Failed:
                    return _lookupPathSettings.Value.Failed;

                case Enums.LookupPath.Processing:
                    return _lookupPathSettings.Value.Processing;
                
                case Enums.LookupPath.Archived:
                    return _lookupPathSettings.Value.Archived;
                
                default:
                    return _lookupPathSettings.Value.Archived;
            }
        }

        private static string GetCorrelationId(string file)
        {
            var name = Path.GetFileNameWithoutExtension(file);
            var start = name.IndexOf(Common.Ctms, StringComparison.Ordinal) + Common.Ctms.Length;
            var end = name.IndexOf(Common._2020, StringComparison.Ordinal);
            var correlationId = name.Substring(start, end - start);
            return correlationId;
        }

        public Dictionary<string, string> GetFiles()
        {
            var files = new Dictionary<string, string>();

            for (var i = 1; i <= 3; i++)
            {
                var lookupPath = GetLookupPath(LookupSequence[i]);
                 
                var todayFiles = Directory.GetFiles(lookupPath)
                                .Where(x => x.ToLower().EndsWith(".xml") &&
                                            Path.GetFileName(x).ToLower().StartsWith(Common.Ctms.ToLower()) &&
                                            new FileInfo(x).CreationTime.Date == DateTime.Today.Date).ToList();

                var correlationIds = todayFiles.Select(GetCorrelationId).ToList();

                if (correlationIds.Any())
                {
                    var mappingDictionary = correlationIds.Zip(todayFiles, (k, v) => new {Key = k, Value = v})
                                            .ToDictionary(x => x.Key, x => x.Value);

                    foreach (var (key, value) in mappingDictionary)
                    {
                        if (!files.ContainsKey(key))
                            files.Add(key, value);
                    }
                }

                if (!LookupInAllPaths) break;
            }

            return files;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using JnjStudyCompoundChecker.Models.HelperModels;
using JnjStudyCompoundChecker.Models.ResponseModels;
using JnjStudyCompoundChecker.Services.Interfaces;

namespace JnjStudyCompoundChecker.Services.Implementations
{
    public class StudyCompoundCheckerService : IStudyCompoundCheckerService
    {
        private readonly IFileLookupService _lookupService;
        private readonly IEntityModelLoaderService _modelLoaderService;
        private readonly IProtocolCompoundService _protocolCompoundService;
        
        public StudyCompoundCheckerService(IFileLookupService lookupService,
                                            IEntityModelLoaderService modelLoaderService,
                                            IProtocolCompoundService protocolCompoundService)
        {
            _lookupService = lookupService;
            _modelLoaderService = modelLoaderService;
            _protocolCompoundService = protocolCompoundService;
        }

        private static List<string> FindProtocolsForMismatchCompounds(ModelContainer entityModels, List<ProtocolCompoundResponse> protocolCompoundResponses)
        {
            // Contains the Protocol Numbers those have mismatch compound count between xml and database
            var protocolsForMismatchCompounds = new List<string>();

            // Todo: Add logic to find out protocols for mismatched compounds. Add logs where needed.
            return protocolsForMismatchCompounds;
        }

        public Tuple<int, List<string>> Execute()
        {
            var files = _lookupService.GetFiles();
            var totalProtocolsForMismatchCompounds = new List<string>();

            foreach (var file in files)
            {
                var entityModels = _modelLoaderService.GetEntityModels(file.Value);
                var protocolNumbers = entityModels.Studies.Select(o => o.ProtocolNumber).ToList();
                var protocolCompoundResponse = _protocolCompoundService.GetProtocolCompoundResponse(protocolNumbers).Result;
                var protocolsForMismatchCompounds = FindProtocolsForMismatchCompounds(entityModels, protocolCompoundResponse);
                totalProtocolsForMismatchCompounds.AddRange(protocolsForMismatchCompounds); 
            }

            return Tuple.Create(files.Count, totalProtocolsForMismatchCompounds.Distinct().ToList());
        }
    }
}
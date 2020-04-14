using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JnjStudyCompoundChecker.DbContext;
using JnjStudyCompoundChecker.Models.ResponseModels;
using JnjStudyCompoundChecker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JnjStudyCompoundChecker.Services.Implementations
{
    public class ProtocolCompoundService : IProtocolCompoundService
    {
        private SafetyRepositoryContext Context { get; }

        public ProtocolCompoundService(SafetyRepositoryContext context)
        {
            Context = context;
        }

        public async Task<List<ProtocolCompoundResponse>> GetProtocolCompoundResponse(List<string> protocolNumbers)
        {
            var result = await (from pc in Context.ProtocolCompound
                                join p in Context.Protocol on pc.ProtocolsId equals p.Id
                                join c in Context.Compound on pc.CompoundsId equals c.Id
                                where protocolNumbers.Contains(p.Number) 
                                  select new 
                                  {
                                      ProtocolId = pc.ProtocolsId,
                                      ProtocolNumber = p.Number,
                                      ProtocolSourceId = p.SourceId,
                                      pc.Created,
                                      CompoundId = pc.CompoundsId,
                                      CompoundName = c.Name,
                                      CompoundSourceId = c.SourceId
                                  }).OrderBy(o => o.ProtocolId).ToListAsync();
            
            var response = ConvertToResponseModel(result);
            return response;
        }

        private static List<ProtocolCompoundResponse> ConvertToResponseModel(dynamic items)
        {
            var responses = new List<ProtocolCompoundResponse>();

            var getNewItem = new Func<dynamic, ProtocolCompoundResponse>(item =>
            {
                var protocolCompoundResponse = new ProtocolCompoundResponse
                {
                    ProtocolId = item.ProtocolId,
                    ProtocolNumber = item.ProtocolNumber,
                    ProtocolSourceId = item.ProtocolSourceId
                };

                protocolCompoundResponse.CompoundResponses.Add(
                    new CompoundResponse
                    {
                        Created = item.Created,
                        CompoundId = item.CompoundId,
                        CompoundName = item.CompoundName,
                        CompoundSourceId = item.CompoundSourceId
                    });

                return protocolCompoundResponse;
            });
            
            foreach (var item in items)
            {
                if (responses.Any())
                {
                    var isNewItem = true;
                    var currentItem = responses.Find(o => o.ProtocolId == item.ProtocolId);

                    if (currentItem == null)
                    {
                        currentItem = getNewItem(item);
                    }
                    else
                    {
                        isNewItem = false;
                        currentItem.CompoundResponses.Add(
                            new CompoundResponse
                            {
                                Created = item.Created,
                                CompoundId = item.CompoundId,
                                CompoundName = item.CompoundName,
                                CompoundSourceId = item.CompoundSourceId
                            });
                    }

                    if (isNewItem)
                    {
                        responses.Add(currentItem);
                    }
                }
                else
                {
                    responses.Add(getNewItem(item));
                }
            }

            return responses;
        }
    }
}
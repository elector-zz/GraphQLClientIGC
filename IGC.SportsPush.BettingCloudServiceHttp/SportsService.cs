using IGC.SportsPush.BettingCloud.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ICG.SportsPush.BettingCloud.DTOs;

namespace IGC.SportsPush.BettingCloud.ServiceHttp
{
    public class SportsServiceHttp : ISportsService
    {
        public SportTypeDTO GetSport(List<KeyValuePair<string, object>> queryVariables)
        {
            try
            {
                // TODO: Extract the URL into configuration or factory creator (becuse of different operators)
                var client = new GraphQLClient("https://stage.bettingcloud.com/api/customerdata/guts/graphql");
                // TODO: Extract the Query strings to an external file
                var query = @"query GetSport($sportid: ID, $isActive: Boolean) {
                              sports(id: $sportid, isActive: $isActive) {
                                id,
                                name
                              }
                            }";

                var obj = client.Query(query, queryVariables, "GetSport").Get<List<SportTypeDTO>>("sports");
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    throw new Exception("Response was a NULL object");
                }
            }
            catch (Exception ex)
            {
                // TODO: Logging
                return null;
            }
        }

        public List<SportTypeDTO> GetSports(List<KeyValuePair<string, object>> queryVariables)
        {
            try
            {
                // TODO: Extract the URL into configuration or factory creator (becuse of different operators)
                var client = new GraphQLClient("https://stage.bettingcloud.com/api/customerdata/guts/graphql");
                // TODO: Extract the Query strings to an external file
                var query = @"query GetSports($sportid: ID, $isActive: Boolean) {
                              sports(id: $sportid, isActive: $isActive) {
                                id,
                                name,
                                prematchEventCount,
                                liveEventCount,
                                prematchMarketCount,
                                liveMarketCount
                              }
                            }";

                var obj = client.Query(query, queryVariables, "GetSports").Get<List<SportTypeDTO>>("sports");
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    throw new Exception("Response was a NULL object");
                }
            }
            catch(Exception ex)
            {
                // TODO: Logging
                return null;
            }
        }
    }
}

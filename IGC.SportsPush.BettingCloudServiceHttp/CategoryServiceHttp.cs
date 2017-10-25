using IGC.SportsPush.BettingCloud.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ICG.SportsPush.BettingCloud.DTOs;

namespace IGC.SportsPush.BettingCloud.ServiceHttp
{
    public class CategoryServiceHttp : ICategoriesService
    {
        public List<CategoryTypeDTO> GetCategories(List<KeyValuePair<string, object>> queryVariables)
        {
            try
            {
                // TODO: Extract the URL into configuration or factory creator (becuse of different operators)
                var client = new GraphQLClient("https://stage.bettingcloud.com/api/customerdata/guts/graphql");
                // TODO: Extract the Query strings to an external file
                var query = @"query {
                              categories{
                                id,
                                name
                              }
                            }";

                var obj = client.Query(query, null, null).Get<List<CategoryTypeDTO>>("sports");
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

        public CategoryTypeDTO GetCategory(List<KeyValuePair<string, object>> queryVariables)
        {
            try
            {
                // TODO: Extract the URL into configuration or factory creator (becuse of different operators)
                var client = new GraphQLClient("https://stage.bettingcloud.com/api/customerdata/guts/graphql");
                // TODO: Extract the Query strings to an external file
                var query = @"query GetCategory($categoryid: ID, $isActive: Boolean) {
                              sports(id: $categoryid, isActive: $isActive) {
                                id,
                                name,
                                prematchEventCount,
                                liveEventCount,
                                prematchMarketCount,
                                liveMarketCount
                              }
                            }";

                var obj = client.Query(query, queryVariables, "GetCategory").Get<List<CategoryTypeDTO>>("sports");
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
    }
}

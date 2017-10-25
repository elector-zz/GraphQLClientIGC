using IGC.SportsPush.BettingCloud.ServiceHttp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Introspection
{
    public class IntrospectionService
    {
        public List<SchemaType> GetSchema()
        {
            try
            {
                // TODO: Extract the URL into configuration or factory creator (becuse of different operators)
                var client = new GraphQLClient("https://stage.bettingcloud.com/api/customerdata/guts/graphql");
                // TODO: Extract the Query strings to an external file
                var query = @"query IntrospectionTypeQuery {
                                  __schema {
                                    types {
                                      name
                                      kind
                                      description
                                      fields {
                                        name
                                        description
                                        type {
                                          kind
                                          name
                                          description    
                  
                                        }
                                        args {
                                          name
                                          description
                                          defaultValue
                                          type {
                                            kind
                                            name
                                            description
                                          }
                                        }
                                      }
                                      inputFields {
                                        name
                                        description
                                        defaultValue
                                      }              
                                    }
                                  }
                                }";

                List<SchemaType> obj = client.Query(query, null, "IntrospectionTypeQuery").GetSchema<List<SchemaType>>("types");

                //SchemaType q = obj.Find(s => s.name == "Query");
                //StringBuilder str = new StringBuilder();
                //creating the variables enums
                //foreach(Field item in q.fields)
                //{
                //    str.Append("public class " + item.name + "Variables" + System.Environment.NewLine);
                //    str.Append("{" + System.Environment.NewLine);
                //    foreach(FieldArgs itt in item.args)
                //    {
                //        str.Append("    " + itt.name + "," + System.Environment.NewLine);
                //    }
                //    str.Append("}" + System.Environment.NewLine);
                //    str.Append(System.Environment.NewLine);
                //}
                string[] typesToDo = { "SportType", "SettingType", "CategoryType", "TournamentType", "EventType", "MarketGraphType", "OutcomeType", "SpecifierType", "SeasonType", "CompetitorType", "MarketTemplateType", "MarketTypeOutcomeTemplateType", "Mutation" };
                StringBuilder str = new StringBuilder();
                foreach (string todo in typesToDo)
                {
                    SchemaType q = obj.Find(s => s.name == todo);
                    
                    str.Append("public class " + q.name + "DTO" + System.Environment.NewLine);
                    str.Append("{" + System.Environment.NewLine);
                    foreach (Field item in q.fields)
                    {
                        str.Append("    /// <summary>" + System.Environment.NewLine);
                        str.Append("    /// " + item.description + System.Environment.NewLine);
                        str.Append("    /// </summary>" + System.Environment.NewLine);
                        str.Append("    public " + item.type.name + " " + item.name + " { get; set; }" + System.Environment.NewLine);


                    }
                    str.Append("}" + System.Environment.NewLine);
                    str.Append(System.Environment.NewLine);
                }

                var sssss = str.ToString();

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

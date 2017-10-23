using CF.RESTClientDotNet;
using System;
using Newtonsoft;
using GraphQL;
using System.Collections.Generic;

namespace ConsoleTestForGraphQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new GraphQLClient("https://stage.bettingcloud.com/api/customerdata/guts/graphql");
            //var query = @"
            //                query{
            //                  sports {
            //                    id
            //                    name
            //                  }
            //                }
            //            ";
            //var obj = client.Query(query, null, null).Get<List<sports>>("sports");
            //if (obj != null)
            //{
            //    Console.WriteLine(obj[0].name);
            //}
            //else
            //{
            //    Console.WriteLine("Null :(");
            //}

            //query = @"
            //            query { 
            //                sports(id: 70) {
            //                    id,
            //                    name
            //                }
            //            }
            //        ";
            //obj = client.Query(query, null).Get<List<sports>>("sports");
            //if (obj != null)
            //{
            //    Console.WriteLine(obj[0].name);
            //}
            //else
            //{
            //    Console.WriteLine("Null :(");
            //}

            var query = @"
                        query GetSportById($sportid: ID) {
                            sports(id: $sportid) {
                                id
                                name
                            }
                        }";

            var obj = client.Query(query, new { sportid = 70 }, "GetSportById").Get<List<sports>>("sports");
            if (obj != null)
            {
                Console.WriteLine(obj[0].name);
            }
            else
            {
                Console.WriteLine("Null :(");
            }

            Console.WriteLine("That's it!");
        }
    }

    class sports
    {
        public string id { get; set; }
        public string name { get; set; }        
    }

}

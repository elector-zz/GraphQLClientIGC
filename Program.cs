using CF.RESTClientDotNet;
using System;
using Newtonsoft;
using System.Collections.Generic;
using ICG.SportsPush.BettingCloud.DTOs;
using IGC.SportsPush.BettingCloud.ServiceInterfaces;

namespace ConsoleTestForGraphQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //ISportsService sportsService = new Sports

            //var query = @"query GetSportById($sportid: ID, $isActive: Boolean) {
            //              sports(id: $sportid, isActive: $isActive) {
            //                id,
            //                name
            //              }
            //            }";

            //List<KeyValuePair<string, object>> variables = new List<KeyValuePair<string, object>>();

            //variables.Add(new KeyValuePair<string, object>("sportid", 70));
            //variables.Add(new KeyValuePair<string, object>("isActive", "true")); // Boolean values need to be strings because getting values returns "True" insted of "true" 

            //var obj = client.Query(query, variables, "GetSportById").Get<List<SportsDTO>>("sports");
            //if (obj != null)
            //{
            //    Console.WriteLine(obj[0].name);
            //}
            //else
            //{
            //    Console.WriteLine("Null :(");
            //}

            Console.WriteLine("That's it!");
        }
    }

}

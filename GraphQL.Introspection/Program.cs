using System;

namespace GraphQL.Introspection
{
    class Program
    {
        static void Main(string[] args)
        {
            IntrospectionService service = new IntrospectionService();
            var tyeps = service.GetSchema();

            Console.ReadLine();
        }


    }
}

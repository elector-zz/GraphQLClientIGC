using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Introspection
{
    public class SchemaType
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<Field> fields { get; set; }
    }
    public class Field
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool isDeprecated { get; set; }
        public FieldType type { get; set; }
        public List<FieldArgs> args { get; set; }
    }

    public class FieldType
    {
        public string kind { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class FieldArgs
    {
        public string defaultValue { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public FieldType type { get; set; }
    }
}

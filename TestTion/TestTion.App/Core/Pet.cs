using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestTion.App.Core
{
    public sealed class Pet : DomainObject
    {
        public string NickName { get; set; }

        public DateTime BirthDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PetType Type { get; set; }
    }
}
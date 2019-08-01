using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SuperheroBattle.Core.Entities
{
    public class Superhero
    {
        public int SuperheroID { get; set; }
        [Required]
        public string SuperheroName { get; set; }
        public string SecretIdentity { get; set; }
        public int? AgeAtOrigin { get; set; }
        public int YearOfAppearance { get; set; }
        public bool IsAlien { get; set; }

        [JsonConverter(typeof(EnumConverter<Planets>))]
        public Planets? PlanetOfOrigin { get; set; }

        public string OriginStory { get; set; }

        [JsonConverter(typeof(EnumConverter<Universes>))]
        public Universes Universe { get; set; }
        
        [JsonIgnore]
        public int AbilityModifier { get; set; }

        [JsonIgnore]
        public IList<SuperheroAbility> SuperheroAbilities { get; set; }

        public IEnumerable<string> Abilities
        {
            get
            {
                return SuperheroAbilities.Select(sa => sa.Ability.Name);
            }
        }

        public Superhero()
        {
            SuperheroAbilities = new List<SuperheroAbility>();
        }
    }

    internal class EnumConverter<TEnum> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Enum.Parse(typeof(TEnum), reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((TEnum)value).ToString());
        }
    }

    public enum Universes
    {
        None = 0,
        Marvel = 1,
        DC = 2,
        Valiant = 3,
        MillarWorld = 4,
        Archie = 5,
        Other = 6,
        Image = 7
    }

    public enum Planets
    {
        Earth = 0,
        Krypton = 1,
        Hala = 2,
        Ego = 3,
        Oa = 4,
        Titan = 5,
        Xandar = 6,
        Viltrumite = 7
    }
}

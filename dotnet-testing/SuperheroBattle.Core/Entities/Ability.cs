using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SuperheroBattle.Core.Entities
{
    public class Ability
    {
        public int AbilityID { get; set; }
        public string Name { get; set; }

        public int StrengthLevel { get; set; }

        [JsonIgnore]
        public IList<SuperheroAbility> SuperheroAbilities { get; set; }

        public IEnumerable<string> Superheroes
        {
            get
            {
                return SuperheroAbilities.Select(sa => sa.Superhero.SuperheroName);
            }
        }

        public Ability()
        {
            SuperheroAbilities = new List<SuperheroAbility>();
        }
    }
}

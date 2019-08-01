using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuperheroBattle.Core.Entities
{
    public class SuperheroAbility
    {
        public int SuperheroID { get; set; }
        [JsonIgnore]
        public Superhero Superhero { get; set; }

        public int AbilityID { get; set; }
        public Ability Ability { get; set; }
    }
}

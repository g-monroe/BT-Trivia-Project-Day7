using SuperheroBattle.Core.Entities;
using SuperheroBattle.Core.Managers;
using SuperheroBattle.DataAccessHandlers.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperheroBattle.BusinessLogic.Managers
{
    public class BattleManager : IBattleManager
    {
        private ISuperheroHandler _superheroHandler;
        public BattleManager(ISuperheroHandler superheroHandler)
        {
            _superheroHandler = superheroHandler;
        }

        public void ExampleUseCase()
        {
            throw new NotImplementedException();
        }

        public async Task<Battle> Fight(Battle battle)
        {
            var superheroIDs = new List<int>();
            superheroIDs.Add(battle.DefenderID);
            superheroIDs.Add(battle.AttackerID);

            List<Superhero> superheroes = await _superheroHandler.GetSuperheroes(superheroIDs);

            int firstSuperheroScore = superheroes[0].SuperheroAbilities.Sum(a => a.Ability.StrengthLevel) + superheroes[0].AbilityModifier;
            int secondSuperheroScore;
            if (superheroes.Count() > 1)
            {
                secondSuperheroScore = superheroes[1].SuperheroAbilities.Sum(a => a.Ability.StrengthLevel) + superheroes[1].AbilityModifier;
            }
            else
            {
                secondSuperheroScore = firstSuperheroScore;
            }

            if (firstSuperheroScore > secondSuperheroScore)
            {
                battle.WinnerID = superheroes[0].SuperheroID;
            }
            else if (firstSuperheroScore < secondSuperheroScore)
            {
                battle.WinnerID = superheroes[1].SuperheroID;
            }
            else
            {
                // Returning null indicates a draw.
                battle.WinnerID = null;
            }

            return battle;
        }
    }
}

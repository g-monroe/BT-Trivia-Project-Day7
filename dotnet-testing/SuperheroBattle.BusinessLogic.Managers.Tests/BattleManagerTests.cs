using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperheroBattle.Core.Entities;
using SuperheroBattle.DataAccessHandlers.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperheroBattle.BusinessLogic.Managers.Tests
{
    [TestClass]
    public class BattleManagerTests
    {
        private BattleManager _battleManager;
        private ISuperheroHandler _superheroHandler;

        [TestInitialize]
        public void TestInitialize()
        {
            _superheroHandler = A.Fake<ISuperheroHandler>();
            _battleManager = new BattleManager(_superheroHandler);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ExampleUseCase_ThrowsNotImplementedException()
        {
            _battleManager.ExampleUseCase();
        }

        [TestMethod]
        public async Task Fight_SameSuperheroLeadsToADraw()
        {
            var battle = new Battle
            {
                AttackerID = 10,
                DefenderID = 10
            };

            var superheroes = new List<Superhero>
            {
                new Superhero()
                {
                    SuperheroID = 10,
                    AbilityModifier = 100,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 0
                            }
                        }
                    }
                }
            };

            A.CallTo(() => _superheroHandler.GetSuperheroes(A<List<int>>._)).Returns(superheroes);

            Battle result = await _battleManager.Fight(battle);

            Assert.IsNull(result.WinnerID);
        }

        [TestMethod]
        public async Task Fight_DefenderWinsBecauseOfAbilityModifier()
        {
            var battle = new Battle
            {
                AttackerID = 10,
                DefenderID = 20
            };

            var superheroes = new List<Superhero>
            {
                new Superhero()
                {
                    SuperheroID = 10,
                    AbilityModifier = 0,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                        }
                    }
                },
                new Superhero()
                {
                    SuperheroID = 20,
                    AbilityModifier = 100,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                        }
                    }
                }
            };

            A.CallTo(() => _superheroHandler.GetSuperheroes(A<List<int>>._)).Returns(superheroes);

            Battle result = await _battleManager.Fight(battle);

            int? expected = 20;
            int? actual = result.WinnerID;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task Fight_AttackerWinsBecauseOfAbilities()
        {
            var battle = new Battle
            {
                AttackerID = 10,
                DefenderID = 20
            };

            var superheroes = new List<Superhero>
            {
                new Superhero()
                {
                    SuperheroID = 10,
                    AbilityModifier = 0,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 100
                            }
                        }
                    }
                },
                new Superhero()
                {
                    SuperheroID = 20,
                    AbilityModifier = 0,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 0
                            }
                        }
                    }
                }
            };

            A.CallTo(() => _superheroHandler.GetSuperheroes(A<List<int>>._)).Returns(superheroes);

            Battle result = await _battleManager.Fight(battle);

            int? expected = 10;
            int? actual = result.WinnerID;
            Assert.AreEqual(expected, actual);
        }
    }
}

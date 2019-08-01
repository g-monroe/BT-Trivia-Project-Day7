using SuperheroBattle.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroBattle.Core.Managers
{
    public interface IBattleManager
    {
        void ExampleUseCase();

        Task<Battle> Fight(Battle battle);
    }
}

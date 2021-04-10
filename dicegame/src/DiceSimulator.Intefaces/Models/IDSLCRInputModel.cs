using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceSimulator.Intefaces.Models
{
    public interface IDSLCRInputModel :IDS
    {

        #region Accessor Properties

         int ChipsPerPlayer { get; set; }

         int NumberOfPlayer { get; set; }

         int NumberOfGames { get; set; }

        #endregion
    }
}

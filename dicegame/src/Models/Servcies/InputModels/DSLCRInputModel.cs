using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceSimulator.Intefaces.Models;

namespace DiceSimulator.Models.InputModels
{
    public class DSLCRInputModel : IDSLCRInputModel
    {
        #region Accessor Properties

        public int ChipsPerPlayer { get; set; }

        public int NumberOfPlayer { get; set; }

        public int NumberOfGames { get; set; }

        #endregion
    }
}

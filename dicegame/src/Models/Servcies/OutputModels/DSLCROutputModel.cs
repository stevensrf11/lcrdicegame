using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceSimulator.Intefaces.Models;

namespace DiceSimulator.Models.Servcies.OutputModels
{
    public class DSLCROutputModel : IDSLCROutputModel
    {
        #region Accessor Properties
        public double AverageTurns { get; set; }

        public int LongesrTurns { get; set; }

        public int MinimumTurns { get; set; }

        #endregion
    }
}

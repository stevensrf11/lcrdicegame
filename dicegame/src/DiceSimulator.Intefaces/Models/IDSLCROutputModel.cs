using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceSimulator.Intefaces.Models
{
    public interface IDSLCROutputModel :IDS
    {
        #region Accessor Properties
         double AverageTurns { get; set; }

         int LongesrTurns { get; set; }

         int MinimumTurns { get; set; }

        #endregion
    }
}

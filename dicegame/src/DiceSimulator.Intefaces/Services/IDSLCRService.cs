using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceSimulator.Intefaces.Models;

namespace DiceSimulator.Intefaces.Services
{
    public interface IDSLCRService :IDS
    {
        IDSLCROutputModel PlayLCRGame(IDSLCRInputModel inputModel);
    }
}

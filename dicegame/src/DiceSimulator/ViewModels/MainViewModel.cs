using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using DiceSimulator.Intefaces.Services;
using Prism.Commands;
using DiceSimulator.Services;
using DiceSimulator.Models.InputModels;

namespace DiceSimulator.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Fields
        private int _numberOfChips = 3;

        private int _numberOfPlayers = 4;

        private int _numberOfGames = 7;

        private string _averageTurns;
        private string _longestTurns;
        private string _shortestTurns;

        private readonly IDSLCRService _dSLCRService;

        public DelegateCommand<object> PlayLCRGame { get; private set; }
        #endregion


        #region Constructors
        public MainViewModel()
        {
        _dSLCRService = new DSLCRService();
         PlayLCRGame = new DelegateCommand<object>(PlayLCRCommand_Execute, PlayLCRCommand_CanExecute);

        }
        #endregion
        #region Property Accessors
        public int NumberOfChips
        {
            get
            {
                return _numberOfChips;
            }

            set
            {
                if (_numberOfChips == value)
                {
                    return;
                }
                SetProperty(ref _numberOfChips, value);
               
            }
        }

        public int NumberOfPlayers
        {
            get
            {
                return _numberOfPlayers;
            }

            set
            {
                if (_numberOfPlayers == value)
                {
                    return;
                }

                SetProperty(ref _numberOfPlayers, value);

            }
        }


        public int NumberOfGames
        {
            get
            {
                return _numberOfGames;
            }

            set
            {
                if (_numberOfGames == value)
                {
                    return;
                }

                SetProperty(ref _numberOfGames, value);
            }
        }


        public string AverageTurns
        {
            get
            {
                return _averageTurns;
            }

            set
            {
                if (_averageTurns == value)
                {
                    return;
                }

                SetProperty(ref _averageTurns, value);

            }
        }

        public string LongestTurns
        {
            get
            {
                return _longestTurns;
            }

            set
            {
                if (_longestTurns == value)
                {
                    return;
                }

                SetProperty(ref _longestTurns, value);

            }
        }

        public string ShortestTurns
        {
            get
            {
                return _shortestTurns;
            }

            set
            {
                if (_shortestTurns == value)
                {
                    return;
                }

                SetProperty(ref _shortestTurns, value);

            }
        }


        #endregion

        #region DelegateCommand Implementation

        void PlayLCRCommand_Execute(object arg)

        {

            // obviously this should not be done in the viewmodel

            var res = _dSLCRService.PlayLCRGame(new DSLCRInputModel
            {
                ChipsPerPlayer = NumberOfChips,
                NumberOfGames = NumberOfGames,
                NumberOfPlayer = NumberOfPlayers
            }); ;

            AverageTurns = res.AverageTurns.ToString();
            LongestTurns = res.LongesrTurns.ToString();
            ShortestTurns = res.MinimumTurns.ToString();

        }

        bool PlayLCRCommand_CanExecute(object arg)

        {

            return true;

        }
        #endregion 


    }
}

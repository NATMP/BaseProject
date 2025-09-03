using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Utils;

namespace Battle
{
    public class BattleController : Singleton<BattleController>
    {
        [Title("Battle Manager")] 

        [Title("Holder")] 
        [SerializeField] private Transform vfxHolder;
        
        #region public API
        public Transform VfxHolder => vfxHolder;
        public int CurrentLevelPlaying => _currentLevelPlaying;
        public int CurrentWave => _currentWave;
        public int TotalWave => _totalWave;
        
        public static List<UnitBase> Characters => Instance._characters;
        public static List<UnitBase> PlayerUnits => Instance._playerUnits;
        public static List<UnitBase> EnemyUnits => Instance._enemyUnits;
        #endregion
        #region private API

        [Title("List")] 
        [ShowInInspector] private readonly List<UnitBase> _characters = new List<UnitBase>();
        [ShowInInspector] private readonly List<UnitBase> _playerUnits = new List<UnitBase>();
        [ShowInInspector] private readonly List<UnitBase> _enemyUnits = new List<UnitBase>();

        private int _currentLevelPlaying;
        private int _currentWave;
        private int _totalWave;
        
        #endregion
        
        #region Unity Functions
        private void Awake()
        {
            SetStateBattle(BattleState.None);
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }

        #endregion
        #region BattleSingal
        private BattleState _stateBattle;

        public static BattleState StateBattle
        {
            get => Instance._stateBattle;
            private set
            {
                Instance._stateBattle = value;
                switch (value)
                {
                    case BattleState.None:
                        Debug.Log("Battle End");
                        break;
                    case BattleState.StartBattle:
                        Debug.Log($"Start Battle Level: {Instance._currentLevelPlaying}");
                        break;
                    case BattleState.Fight:
                        Debug.Log($"Start Fight Wave: {Instance._currentWave} / {Instance._totalWave}");
                        break;
                    case BattleState.EndFight:
                        Debug.Log($"End Fight Wave: {Instance._currentWave} / {Instance._totalWave}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }
        public void SetStateBattle(BattleState battleState)
        {
            StateBattle = battleState;
        }

        private void StartBattle(int level)
        {
            _currentWave = 1;
            //_totalWave = SOCampaign.Instance.GetTotalWavesInLevel(level);
        }

        private void EndBattle()
        {
            foreach (var baseCharacter in Characters)
            {
            }
            Characters.Clear();
        }

        private void StartFight()
        {
            Characters.Clear();
        }

        private void EndFight()
        {
            _currentWave++;
            foreach (var baseCharacter in Characters)
            {
            }
            Characters.Clear();
        }

        private void OnCharacterDeadSignal(UnitBase character)
        {
            Characters.Remove(character);
            PlayerUnits.Remove(character);
            EnemyUnits.Remove(character);
            CheckWin();
        }
        
        #endregion
        #region Battle Functions

        public void BeginStartBattle(int level)
        {
            _currentLevelPlaying = level;
            SetStateBattle(BattleState.StartBattle);
        }

        private void CheckWin()
        {
            //if (!spawnObjInBattle.IsSpawnEnemyAll) return;
            if (EnemyUnits.Count != 0) return;
            if (TotalWave == CurrentWave)
            {
                Debug.LogError("Win");
                SetStateBattle(BattleState.None);
                return;
            }
            Debug.LogError("Wave Win");
            SetStateBattle(BattleState.EndFight);
        }
        
        private void CheckLose(UnitBase unit)
        {

        }
        #endregion
    }

    public enum BattleState
    {
        None,
        StartBattle,
        Fight,
        EndFight
    }
}
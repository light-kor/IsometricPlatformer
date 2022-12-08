using System;
using UI;
using UnityEngine;

namespace Crystals
{
    public class CrystalCollector : MonoBehaviour
    {
        public Action<int, int> CrystalCountChanged;
        public static Action AllCollected;

        private Crystal[] _crystals;
        private int _crystalCount;
        private int _crystalsCollected;

        private void Start()
        {
            Crystal.CollectCrystal += CollectCrystal;
            ResetGame.ResetLevel += ResetCrystals;
            
            _crystals = GetComponentsInChildren<Crystal>();
            _crystalCount = _crystals.Length;
            CrystalCountChanged?.Invoke(_crystalsCollected, _crystalCount);
        }

        private void CollectCrystal(Crystal crystal)
        {
            crystal.gameObject.SetActive(false);
        
            _crystalsCollected++;
            CrystalCountChanged?.Invoke(_crystalsCollected, _crystalCount);

            TryFinishGame();
        }
    
        private void TryFinishGame()
        {
            if (_crystalsCollected == _crystalCount)
            {
                AllCollected?.Invoke();
            }
        }

        private void ResetCrystals()
        {
            foreach (var crystal in _crystals)
            {
                crystal.gameObject.SetActive(true);
            }
            
            _crystalsCollected = 0;
            CrystalCountChanged?.Invoke(_crystalsCollected, _crystalCount);
        }

        private void OnDestroy()
        {
            Crystal.CollectCrystal -= CollectCrystal;
            ResetGame.ResetLevel -= ResetCrystals;
        }
    }
}

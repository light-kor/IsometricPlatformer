using UnityEngine;
using UnityEngine.Events;

public class CrystalCollector : MonoBehaviour
{
    public UnityAction<int, int> ValueChanged;
    public UnityAction<bool> AllCollected;

    private Crystal[] _crystals;
    private int _crystalCount = 0;
    private int _crystalsCollected = 0;

    private void Start()
    {
        ResetGame.ResetLevel += ResetCrystals;
        _crystals = GetComponentsInChildren<Crystal>();
        _crystalCount = _crystals.Length;
        ValueChanged?.Invoke(_crystalsCollected, _crystalCount);
    }

    public void Collect()
    {
        _crystalsCollected++;
        ValueChanged?.Invoke(_crystalsCollected, _crystalCount);

        TryFinidhGame();
    }
    
    private void TryFinidhGame()
    {
        if (_crystalsCollected == _crystalCount)
        {
            AllCollected?.Invoke(true);
        }
    }

    private void ResetCrystals()
    {
        foreach (Crystal crystal in _crystals)
        {
            crystal.gameObject.SetActive(true);
            _crystalsCollected = 0;
            ValueChanged?.Invoke(_crystalsCollected, _crystalCount);
        }
    }

    private void OnDestroy()
    {
        ResetGame.ResetLevel -= ResetCrystals;
    }
}

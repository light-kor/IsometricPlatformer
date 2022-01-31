using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BulletDisplay : MonoBehaviour
{
    [SerializeField] private SimpleGun _gun;
    [SerializeField] private Color _available;
    [SerializeField] private Color _used;

    private Image[] _points;

    private void Start()
    {
        _gun.AmmoInClip += UpdateBulletsDisplay;
        _gun.Reload += ResetAll;

        List<Image> pointsBuffer = GetComponentsInChildren<Image>().ToList();
        pointsBuffer.RemoveAt(0);
        _points = pointsBuffer.ToArray();
        ResetAll();
    }

    private void UpdateBulletsDisplay(int availableCount)
    {
        for (int i = availableCount; i < _points.Length; i++)
        {
            _points[i].color = _used;
        }
    }

    private void ResetAll()
    {
        foreach (Image point in _points)
        {
            point.color = _available;
        }
    }

    private void OnDestroy()
    {
        _gun.AmmoInClip -= UpdateBulletsDisplay;
        _gun.Reload -= ResetAll;
    }
}

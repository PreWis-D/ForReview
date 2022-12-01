using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZoneInitializer : MonoBehaviour
{
    [SerializeField] private int _step;
    [SerializeField] private Vector2Int _spawnZoneSize;
    [SerializeField] private SpawnZone _spawnZone;

    private int _minValue = 1;
    private Vector2Int _currentSize;

    public SpawnZone SpawnZone => _spawnZone;

    private void Awake()
    {
        _currentSize = _spawnZoneSize;

        if (_step <= 0)
            _step = _minValue;

        Init();
    }

    public void ChangeSize()
    {
        _spawnZoneSize = new Vector2Int(_currentSize.x, _currentSize.y);
        _currentSize = _spawnZoneSize;
        Init();
    }

    private void Init()
    {
        _spawnZone.Initialize(_spawnZoneSize, _step);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 1, 0.1f);
        Gizmos.DrawCube(_spawnZone.transform.position, new Vector3(_spawnZoneSize.x, 0.5f, _spawnZoneSize.y));
    }

}

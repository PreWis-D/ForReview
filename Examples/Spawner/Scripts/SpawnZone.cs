using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnPoint;

    private float _offset = 0.5f;

    private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

    public List<SpawnPoint> SpawnPoints => _spawnPoints;

    public void Initialize(Vector2Int size, int step)
    {
        Vector2 offset = new Vector2((size.x - step) * _offset, (size.y - step) * _offset);

        for (int y = 0; y < size.y; y+= step)
        {
            for (int x = 0; x < size.x; x+= step)
            {
                SpawnPoint spawnPoint = Instantiate(_spawnPoint);
                spawnPoint.transform.SetParent(transform, false);
                spawnPoint.transform.localPosition = new Vector3(x - offset.x, 0, y - offset.y);
                _spawnPoints.Add(spawnPoint);
            }
        }
    }
}

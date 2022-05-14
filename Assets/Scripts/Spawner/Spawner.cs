using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _target;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _waitArea;
    [SerializeField] private Vector2 _boardWaitArea;

    private Vector2 _movePoint;
    private Wave _curentWave;
    private int _curentWaveNumber;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction GameEnded;

    private void Start()
    {
        SetWave(_curentWaveNumber);
    }

    private void Update()
    {
        if (_curentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn > _curentWave.DelayBetweenEnemy)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }
        if (_curentWave.Count <= _spawned)
        {
            if (_waves.Count >= _curentWaveNumber + 1)
                AllEnemySpawned.Invoke();
            
            _curentWave = null;
        }
    }

    private void SetWave(int index)
    {
        if(index+1 > _waves.Count)
            GameEnded.Invoke();
        else
            _curentWave = _waves[index];
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_curentWave.Teamplate, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        _movePoint = new Vector2(Random.Range(_waitArea.position.x + _boardWaitArea.x, _waitArea.position.x - _boardWaitArea.x), Random.Range(_waitArea.position.y + _boardWaitArea.y, _waitArea.position.y - _boardWaitArea.y));
        enemy.Init(_target,_movePoint);
        enemy.Diyng += OnEnemyDying;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Diyng -= OnEnemyDying;
        _target.AddScore(enemy.Reward);
    }

    public void NextWave()
    {
        _spawned = 0;
        SetWave(++_curentWaveNumber);
    }

    public void ResetWaves()
    {
        _curentWaveNumber = -1;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemys.Length; i++)
        {
            Destroy(enemys[i]); 
        }
    }
}

[System.Serializable]
public class Wave
{
    [SerializeField] private GameObject _teamplate;
    [SerializeField] private int _count;
    [SerializeField] private float _delayBetweenEnemy;

    public GameObject Teamplate => _teamplate;
    public int Count => _count;
    public float DelayBetweenEnemy => _delayBetweenEnemy;
}
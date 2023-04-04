using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Spawner_Manager : MonoBehaviour
{
    [SerializeField]
    private float _distance = 40f;

    [SerializeField]
    private GameObject _treasure;

    [SerializeField]
    private Transform _centerPoint;

    private float _angle = 0f;

    [SerializeField]
    private Vector3 _spawnPoint;

    [SerializeField]
    private EnemyBehavior _enemyBasic;

    [SerializeField]
    private EnemyBehavior _enemyGunner;

    [SerializeField]
    private float _spawnDelay = 1f;

    [SerializeField]
    private float _spawnModifier = 0.9f;

    private EnemyBehavior _enemyToSpawn;

    private float _waveDelay = 5f;
    private float _time = 0f;
    private float _spawntime = 0f;
    private float _basicSpawnChance = 80f;

    private int _waveNumber = 0;

    
    private List<EnemyBehavior> _enemiesList = new List<EnemyBehavior>();

    private bool _canSpawn;

    private void Start()
    {
        _canSpawn = false;
    }

    public void StartGame()
    {
        _canSpawn = true;
    }

    public void EndGame()
    {
        _canSpawn = false;

        foreach(EnemyBehavior enemy in _enemiesList)
        {
            if(enemy != null)
            {
                enemy.IsWinning();
            }
            
        }
    }

    private void Update()
    {
        if (_canSpawn)
        {
            _time += Time.deltaTime;
            if (_time >= _waveDelay)
            {
                _spawnDelay = _spawnDelay * _spawnModifier;
                _time = 0f;
                _waveNumber++;
                Debug.Log(_waveNumber);

            }

            _spawntime += Time.deltaTime;

            if (_spawntime >= _spawnDelay)
            {
                SetSpawnPoint();
                SpawnEnemies();
                _spawntime = 0f;
            }
        }
             
        
    }


    private void SetSpawnPoint()
    {
        _centerPoint.position = _treasure.transform.position;
        _angle = UnityEngine.Random.Range(0,360);


        _spawnPoint = _centerPoint.position;
        Vector3 direction  = Quaternion.AngleAxis(_angle, Vector3.up)*transform.forward;

        _spawnPoint = _spawnPoint + direction * _distance;
    }

    private void ChooseEnemyToSpawn()
    {
        float spawnRoll = UnityEngine.Random.Range(0, 100);
        if(spawnRoll <= _basicSpawnChance)
        {
            _enemyToSpawn = _enemyBasic;
        }
        else
        {
            _enemyToSpawn = _enemyGunner;
        }
    }


    private void SpawnEnemies()
    {
        ChooseEnemyToSpawn();
        EnemyBehavior newEnemy = Instantiate(_enemyToSpawn, _spawnPoint, _enemyBasic.transform.rotation);
        newEnemy.StartNavigation(this.gameObject.transform);
        _enemiesList.Add(newEnemy);

        
    }


}

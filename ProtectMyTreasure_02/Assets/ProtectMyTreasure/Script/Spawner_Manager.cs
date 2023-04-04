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

    
    private Vector3 _spawnPoint;

    [SerializeField]
    private EnemyBehavior _enemyBasic;

    [SerializeField]
    private EnemyBehavior _enemyGunner;

    [SerializeField]
    private float _spawnDelay = 1f;

    [SerializeField]
    private float _spawnModifier = 0.9f;

    [SerializeField]
    private Transform _player = null;

    [SerializeField]
    private float _waveDelay = 15f;

    private float _time = 0f;
    private float _spawntime = 0f;
    private float _basicSpawnChance = 0f;
    private EnemyBehavior _enemyToSpawn;

    private int _waveNumber = 0;

    
    private List<EnemyBehavior> _enemiesList = new List<EnemyBehavior>();


    private void Update()
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
            _spawntime = 0f;
            SetSpawnPoint();
            SpawnEnemies();
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
        if(spawnRoll < _basicSpawnChance)
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

        GunPirateBehavior gunPirateConfirmation = newEnemy.GetComponent<GunPirateBehavior>();
        if (gunPirateConfirmation != null)
        {
            PreviewFireLine previewFireLine = gunPirateConfirmation.PreviewFireLine;
            previewFireLine.SetPlayerCharacter(_player.transform); 
        }
        _enemiesList.Add(newEnemy);


    }


}

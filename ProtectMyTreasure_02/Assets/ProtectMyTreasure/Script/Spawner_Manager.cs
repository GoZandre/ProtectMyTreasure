using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner_Manager : MonoBehaviour
{
    [SerializeField]
    private float _distance = 1000f;

    [SerializeField]
    private GameObject _treasure;

    [SerializeField]
    private Transform _centerPoint;

    private float _angle = 0f;

    [SerializeField]
    private Vector3 _spawnPoint;

    [SerializeField]
    private GameObject _enemy;


    private void Update()
    {
        SetSpawnPoint();
        SpawnEnemies();
    }


    private void SetSpawnPoint()
    {
        _centerPoint.position = _treasure.transform.position;
        _angle = UnityEngine.Random.Range(0,360);


        _spawnPoint = _centerPoint.position;
        Vector3 direction  = Quaternion.AngleAxis(_angle, Vector3.up)*transform.forward;

        _spawnPoint = _spawnPoint + direction * _distance;
    }

    private void SpawnEnemies()
    {
        Instantiate(_enemy, _spawnPoint, _enemy.transform.rotation);
    }


}

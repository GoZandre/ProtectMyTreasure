using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPirateBehavior : MonoBehaviour
{
    [SerializeField]
    private float _minDelayBetweenShot;
    [SerializeField]
    private float _maxDelayBetweenShot;

    private float _delayBetweenShot;

    private bool _canShoot = false;

    [Header("References")]
    [SerializeField]
    private Projectile _projectilePrefab;

    [SerializeField]
    private Transform _projectileSpawn;

    private void Start()
    {
        SetupDelay();
    
    }

    private void SetupDelay()
    {
        _delayBetweenShot = Random.Range(_minDelayBetweenShot, _maxDelayBetweenShot);
        _time = 0;
        _canShoot = true;
    }


    private float _time;
    void Update()
    {
        if (_canShoot)
        {
            if (_time >= _delayBetweenShot)
            {
                _canShoot = false;
                Shoot();
            }
            else
            {
                _time += Time.deltaTime;
            }
        }     
    }

    private void Shoot()
    {
        Projectile newProjectile = Instantiate(_projectilePrefab, _projectileSpawn);
        newProjectile.transform.parent = null;

        SetupDelay();
    }
}

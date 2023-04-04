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

    [SerializeField]
    private float _loadShootTime;

    private bool _canShoot = false;

    [Header("References")]
    [SerializeField]
    private Projectile _projectilePrefab;

    [SerializeField]
    private Transform _projectileSpawn;

    [SerializeField]
    private PreviewFireLine _previewFireLine;

    public PreviewFireLine PreviewFireLine => _previewFireLine;

    private EnemyBehavior _enemyBehavior;

    private void Start()
    {
        _enemyBehavior = GetComponent<EnemyBehavior>();
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
                if(_time >= _delayBetweenShot + _loadShootTime)
                {
                    _canShoot = false;
                    Shoot();
                }
                else if (_time >= _delayBetweenShot + _loadShootTime * .5f)
                {

                    _previewFireLine.AlertPreview();
                    _enemyBehavior.SetActiveLookAt(false);
                }
                else
                {
                    PreviewShoot();
                }
            }

            _time += Time.deltaTime;
        }     
    }

    private void PreviewShoot()
    {
        _previewFireLine.ActivePreview();

        _enemyBehavior.StopNavigation();
        _enemyBehavior.SwithcLookAtTransform(_previewFireLine.GetPlayerCharacter());
    }

    private void Shoot()
    {


        Projectile newProjectile = Instantiate(_projectilePrefab, _projectileSpawn);
        newProjectile.transform.parent = null;

        _previewFireLine.DisablePreview();


        SetupDelay();

        _enemyBehavior.StartNavigation();
        _enemyBehavior.SetActiveLookAt(true);
    }

    public void StopGun()
    {
        _canShoot = false;
        _previewFireLine.DisablePreview();


    }
}

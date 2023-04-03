using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _projectileSpeed = 1;

    [SerializeField]
    private float _lifetime;
    private float _time;

    void FixedUpdate()
    {
        transform.position = transform.position + (transform.forward * (_projectileSpeed / 100));

        if(_time > _lifetime & _lifetime > 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _time += Time.fixedDeltaTime;
        }
    }
}

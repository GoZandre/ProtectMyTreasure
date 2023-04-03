using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{

    [SerializeField]
    int _damageStrength = 1;

    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();

        EnableDamage(false);
    }

    public void EnableDamage(bool isDamage)
    {
        _boxCollider.enabled = isDamage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Damageable damageable = collision.gameObject.GetComponent<Damageable>();

                if (damageable != null)
                {
                    damageable.TakeDamage(_damageStrength, transform);
                }
            }
        }
    }
}

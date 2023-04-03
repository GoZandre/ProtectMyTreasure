using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Damager : MonoBehaviour
{

    [SerializeField]
    int _damageStrength = 1;

    [SerializeField]
    private List<string> _detectionTag = new List<string>();

    [SerializeField]
    private bool _destroyOnDamage = false;

    [SerializeField]
    private bool _destroyOnHit = false;

    private BoxCollider _boxCollider;

    [SerializeField]
    private bool _enableDamage = false;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();

        EnableDamage(_enableDamage);
    }

    public void EnableDamage(bool isDamage)
    {
        _boxCollider.enabled = isDamage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject);
        if (collision != null)
        {

            bool rightActor = false;

            for(int i =0; i < _detectionTag.Count; i++)
            {
                if (collision.gameObject.CompareTag(_detectionTag[i]))
                {
                    rightActor = true;
                }
            }

            if (rightActor)
            {
                Damageable damageable = collision.gameObject.GetComponent<Damageable>();

                if (damageable != null)
                {
                    damageable.TakeDamage(_damageStrength, transform);

                    if(_destroyOnDamage)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }

        if (_destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int _maxLife;

    [SerializeField]
    private int _life;

    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _life = _maxLife;
      
    }


    public void TakeDamage(int damage, Transform damageOrigin = null)
    {
        _life -= damage;

        if( _life <= 0)
        {
            if(damageOrigin != null)
            {
                Vector3 damageDirection = (damageOrigin.position - transform.position);
                
            }
            Death();
        }

        DamageFeedback();
    }


    private void Death()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        _animator.SetTrigger("Death");
    }
    
    private void DamageFeedback()
    {

    }

    [SerializeField]
    float _delayBeforeDestroy;
    float _delayValue = 0f;

    private void Update()
    {
        if(_life <= 0)
        {
            _delayValue += Time.deltaTime;

            if(_delayValue >= _delayBeforeDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}

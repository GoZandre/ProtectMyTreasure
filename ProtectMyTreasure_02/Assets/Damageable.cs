using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int _maxLife;

    [SerializeField]
    private int _life;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    UnityEvent m_OnHitEvent = new UnityEvent();

    [SerializeField]
    UnityEvent m_OnDeathEvent = new UnityEvent();



    private void Start()
    {
        _life = _maxLife;
      
    }

    private void OnEnable()
    {
        m_OnDeathEvent.RemoveAllListeners();
        m_OnDeathEvent.AddListener(Death);

        m_OnHitEvent.RemoveAllListeners();
        m_OnHitEvent.AddListener(DamageFeedback);
    }


    public void TakeDamage(int damage, Transform damageOrigin = null)
    {
        _life -= damage;

        InstanceHitParticle(damageOrigin);

        if( _life <= 0)
        {
            if(damageOrigin != null)
            {
                Vector3 damageDirection = (damageOrigin.position - transform.position);
                
            }
            m_OnDeathEvent.Invoke();
        }

        m_OnHitEvent.Invoke();
    }


    private void Death()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        _animator.SetTrigger("Death");
        GetComponent<EnemyBehavior>().AddScore();
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

    [Header("Particles")]

    [SerializeField]
    private ParticleSystem _hitParticles;

    public void InstanceHitParticle(Transform damageOrigin)
    {

        ParticleSystem newParticles = Instantiate(_hitParticles, this.transform);

        newParticles.transform.rotation = Quaternion.LookRotation(damageOrigin.position - transform.position);
    }
}

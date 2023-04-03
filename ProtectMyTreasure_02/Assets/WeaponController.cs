using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField]
    private TrailRenderer _trailRanderer;

    private bool _canCombo = false;
    private bool _isCombo = false;
    private bool _canAttack = true;

    private int _comboInt;

    public bool CanCombo => _canCombo;
    public bool IsCombo => _isCombo;

    private Animator _animator;

    private void Start()
    {
        _canAttack = true;

        DeactivateTril();
        _animator = GetComponent<Animator>();
    }

    public void ActivateTril()
    {
        _trailRanderer.emitting = true;
    }

    public void DeactivateTril()
    {
        _trailRanderer.emitting = false;
    }

    public void ActiveCombo()
    {
        _canCombo = true;
    }

    public void DeactiveCombo()
    {
        _canCombo = false;
    }

    public void ResetAttack()
    {
        _isCombo = false;
        _canAttack = true;
        _canCombo = false;

        _animator.SetBool("AttackCombo", false);
    }

    public void Attack()
    {
        if (_canAttack)
        {
            _animator.SetTrigger("IsAttacking");
            _canAttack= false;
        }
       
        if (_canCombo)
        {
            _animator.SetBool("AttackCombo", true);
        }
    }


    public void ActiveDamage()
    {
        GetComponent<Damager>().EnableDamage(true);
    }

    public void DeactivateDamage()
    {
        GetComponent<Damager>().EnableDamage(false);
    }
}

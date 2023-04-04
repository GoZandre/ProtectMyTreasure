using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushBehavior : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem _leafParticles;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger("Move");
        ParticleSystem leafs = Instantiate(_leafParticles);
        leafs.transform.position = transform.position;
    }
}

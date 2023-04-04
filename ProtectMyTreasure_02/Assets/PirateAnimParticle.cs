using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateAnimParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    public void SpawnParticle()
    {
        ParticleSystem newParticle = Instantiate(_particleSystem);
        newParticle.transform.position = transform.position;
    }
}

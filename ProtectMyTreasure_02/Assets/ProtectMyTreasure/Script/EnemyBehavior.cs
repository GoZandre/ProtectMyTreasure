using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemyBehavior : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform _treasure;

    [SerializeField]
    private Transform _characterMesh;

    [Header("Statistics")]
    [SerializeField]
    private float _speed;

    [SerializeField]
    private bool _autoStart;

    [SerializeField]
    private Transform _lookAtTransform;

    [SerializeField]
    private bool activeLookAt;

    public void SetActiveLookAt(bool isActive)
    {
        activeLookAt = isActive;
    } 

    private NavMeshAgent _agent;

    private void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();

        if(_agent == null)
        {
            Debug.LogError("No agent fing on " + gameObject);
        }

        NavMeshHit hit;

        if (NavMesh.SamplePosition(this.transform.position, out hit, 10f, 0) == true)
        {
            this.transform.position = hit.position;
        }


        SetActiveLookAt(false);

        //Auto start
        if (_autoStart )
        {
            StartNavigation();
            
        }
        else
        {
            StopNavigation();
            
        }
        

    }

    public void SwithcLookAtTransform(Transform _newTransform)
    {
        _lookAtTransform = _newTransform;
    }

    public void ResetLookAtTransform()
    {
        _lookAtTransform = _treasure.transform;
    }

    private void Update()
    {
        if(activeLookAt)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_lookAtTransform.position - transform.position), 0.25f);
        }

    }

    public void StartNavigation(Transform newTreasure = null)
    {
        if(newTreasure != null)
        {
            _treasure = newTreasure;
        }

        _agent.enabled = true;

        _agent.SetDestination(_treasure.position);
        _agent.speed = _speed;

        _lookAtTransform = _treasure.transform;

        SetActiveLookAt(true);
    }

    public void StopNavigation()
    {
        _agent.enabled = false;
    }

    public void IsWinning()
    {
        _agent.enabled=false;
        _characterMesh.GetComponent<Animator>().SetTrigger("GetDiamond");
    }

}

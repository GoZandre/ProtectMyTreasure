using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewFireLine : MonoBehaviour
{
    [Header("References")]
    private LineRenderer _lineRenderer;

    [SerializeField]
    private Transform _playerCharacter;


    [Header("References")]
    [SerializeField]
    private Gradient _baseColor;
    [SerializeField]
    private Gradient _fireColor;

    [SerializeField]
    private float _timeToWaitBeforeShoot;

    [SerializeField]
    private float _lineDistance;

    private float _timerDelay;

    private bool _showPreview;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _showPreview = true;
    }

    public void OnStartFire()
    {
        _timerDelay = 0;
        _showPreview = true;
    }

    public void OnFire()
    {

    }

    void Update()
    {
        if (_showPreview)
        {

            Vector3 lineDirection = (_playerCharacter.position - transform.position).normalized;

            if(_timerDelay >= _timeToWaitBeforeShoot)
            {
                OnFire();
            }
            else if(_timerDelay >= _timeToWaitBeforeShoot * .75f)
            {
                _lineRenderer.colorGradient = _fireColor;
            }
            else
            {
                _lineRenderer.SetPosition(0, transform.position + new Vector3(0, 1, 0));

                _lineRenderer.SetPosition(1, transform.position + (lineDirection * _lineDistance) + new Vector3(0, 1, 0));

                _lineRenderer.colorGradient = _baseColor;

            }
            
            

        }
    }
}

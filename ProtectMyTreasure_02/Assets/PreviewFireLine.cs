using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewFireLine : MonoBehaviour
{
    [Header("References")]
    private LineRenderer _lineRenderer;

    [SerializeField]
    private Transform _playerCharacter;

    public Transform PlayerCharacter => _playerCharacter;

    [Header("References")]
    [SerializeField]
    private Gradient _baseColor;
    [SerializeField]
    private Gradient _fireColor;

    private float _timeToWaitBeforeShoot;

    [SerializeField]
    private float _lineDistance;

    private float _timerDelay;

    private bool _showPreview;

    private bool canAim;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
        _showPreview = false;
    }

    public void ActivePreview()
    {

        _lineRenderer.enabled = true;
        _lineRenderer.colorGradient = _baseColor;
        _showPreview = true;

        canAim = true;
    }

    public void AlertPreview()
    {
        _lineRenderer.colorGradient = _fireColor;

        canAim = false;
    }

    public void OnFire()
    {

        _lineRenderer.enabled = false;
        _showPreview = false;
    }

    

    void Update()
    {
        if (_showPreview)
        {

            Vector3 lineDirection = (_playerCharacter.position - transform.position).normalized;

            if(canAim)
            {
                _lineRenderer.SetPosition(0, transform.position + new Vector3(0, 1, 0));

                _lineRenderer.SetPosition(1, transform.position + (lineDirection * _lineDistance) + new Vector3(0, 1, 0));

                

            }
           
        }
    }


}

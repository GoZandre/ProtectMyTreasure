using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedLine : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    [SerializeField]
    private float _fillSize;
    [SerializeField]
    private float _spaceSize;

    private Material _baseMaterial;

    private void Awake()
    {
        
        GetMaterial();
    }

    public void GetMaterial()
    {
        if (GetComponent<LineRenderer>() != null)
        {
            _lineRenderer = GetComponent<LineRenderer>();

            _baseMaterial = new Material(_lineRenderer.material);
            _lineRenderer.material = _baseMaterial;
        }
        else
        {
            Debug.LogError("Component " + this.ToString() + " is not attached with a line renderer in" + this.gameObject);
            this.enabled = false;
        }
    }


    private void Update()
    {

        _baseMaterial.SetFloat("_FillSize", _fillSize);
        _baseMaterial.SetFloat("_SpaceSize", _spaceSize);
        _baseMaterial.SetFloat("_LineLength", LineSize());
        
    }


    private float LineSize()
    {
        float totalSize = 0;

        for (int i = 1; i < _lineRenderer.positionCount; i++)
        {
            totalSize += (_lineRenderer.GetPosition(i) - _lineRenderer.GetPosition(i - 1)).magnitude;
        }

        return totalSize;
    }
}

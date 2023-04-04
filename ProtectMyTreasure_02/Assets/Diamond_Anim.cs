using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond_Anim : MonoBehaviour
{
    [SerializeField]
    private float _maxHeight;
    [SerializeField]
    private float _minHeight;

    [SerializeField]
    private float _heightLoopDuration;

    [SerializeField]
    private AnimationCurve _animationCurve;



    private float _time;
    private Vector3 _basePosition;

    private void Start()
    {
        _basePosition = transform.position;
    }

    public void SetBasePosition(Vector3 basePosition)
    {
        _basePosition = basePosition;
    }

    private void Update()
    {
        if(_time >= _heightLoopDuration)
        {
            _time = 0;
        }
        else
        {
            _time += Time.deltaTime;
            float yPos = _basePosition.y + Mathf.Lerp(_minHeight, _maxHeight, _animationCurve.Evaluate(_time / _heightLoopDuration));

            transform.position = new Vector3(_basePosition.x, yPos, _basePosition.z);

        }

       
    }
}

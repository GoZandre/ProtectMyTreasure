using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    private float _lifetime;
    private float _time;
    // Update is called once per frame
    void Update()
    {
        if (_time > _lifetime & _lifetime > 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _time += Time.deltaTime;
        }
    }
}

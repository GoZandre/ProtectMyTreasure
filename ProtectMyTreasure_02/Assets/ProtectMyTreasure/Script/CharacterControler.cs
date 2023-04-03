using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControler : MonoBehaviour
{

    private Rigidbody _rigidBody;

    PlayerController _playerController;

    private Camera _camera;

    [SerializeField]
    private Transform _characterMesh;

    [SerializeField]
    private float Speed = 1;


    [Header("Weapons")]
    [SerializeField]
    private WeaponController _weaponController;

    private void Awake()
    {
        _playerController = new PlayerController();

        _playerController.Gameplay.Attack.performed += ctx => Attack();

        _camera = Camera.main;

        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    private void Attack()
    {
        Debug.Log("Attack");
        _weaponController.Attack();
    }

    private void OnEnable()
    {
        _playerController.Gameplay.Enable();
    }

    void FixedUpdate()
    {
        float velocityX = Input.GetAxis("Horizontal");
        float velocityY = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(velocityX, 0, velocityY) * Speed;

        _rigidBody.velocity = Vector3.Slerp(_rigidBody.angularVelocity, velocity, .5f) ;

        if(velocity != Vector3.zero)
        {
            _characterMesh.rotation = Quaternion.Slerp(_characterMesh.rotation, Quaternion.LookRotation(velocity), 0.25f);
        }
       
    }

}

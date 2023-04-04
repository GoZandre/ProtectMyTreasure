using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureTaken : MonoBehaviour
{
    [SerializeField]
    private Transform _enemyWinPos;

    [SerializeField]
    private Transform _diamondTakePos;

    [SerializeField]
    private Diamond_Anim _diamond;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy enter treasur");
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemiesWin(other.gameObject.GetComponent<EnemyBehavior>());
        }
    }


    private void EnemiesWin(EnemyBehavior enemyBehavior)
    {
        enemyBehavior.SetActiveLookAt(false);
        enemyBehavior.transform.position = _enemyWinPos.position;

        _diamond.SetBasePosition(_diamondTakePos.position);

        enemyBehavior.IsWinning();
    }
}

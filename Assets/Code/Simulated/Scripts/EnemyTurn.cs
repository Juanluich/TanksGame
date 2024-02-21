using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] EnemyMovement _enemyMovement;
    [SerializeField] EnemyShootController _shootController;

    [SerializeField] GameObject _circleTarget;
    public bool turnEnded;
    public void MovementTurn()
    {
        _enemyMovement.enabled = true;
        if (_enemyMovement != null && _enemyMovement.DestinationReached())
        {
            _shootController.enabled = true;
        }
    }

    public void DisableFunctionality()
    {
        _shootController.enabled = false;
        _enemyMovement.enabled = false;
        _circleTarget.SetActive(false);
    }
    public void TurnEnded(bool ended)
    {
        turnEnded = ended;
    }
}

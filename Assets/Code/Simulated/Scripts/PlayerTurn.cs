using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] ShootController _shotController;

    [SerializeField] GameObject _circleTarget;
    public bool turnEnded;
    public void MovementTurn()
    {
        _playerMovement.enabled = true;
        if (_playerMovement != null && _playerMovement.DestinationReached())
        {
            _shotController.enabled = true;
        }

    }
    public void DisableFunctionality()
    {
        _shotController.enabled = false;
        _playerMovement.enabled = false;
        _circleTarget.SetActive(false);
    }
    public void TurnEnded(bool ended)
    {
        turnEnded = ended;
    }
}

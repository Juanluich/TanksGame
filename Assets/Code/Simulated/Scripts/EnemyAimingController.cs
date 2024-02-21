using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAimingController : MonoBehaviour
{
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] EnemyShootController _shootController;

    float _marginOfError;
    float _heightAdded;

    public void CalcDirection(Transform targetPosition, Transform playerPosition)
    {
        CalcDifficulty();
        // Margin of error
        Vector3 accuracyPos = (Random.onUnitSphere * _marginOfError) + playerPosition.position;
        accuracyPos.y = -0.18f;

        targetPosition.DOMove(accuracyPos, 2f)
            .SetEase(Ease.Linear)
            .OnComplete(()=> CalcHeight());        
    }

    private void CalcDifficulty()
    { 
        // max height = 5, max accuracy = 3
        if (_playerHealth.currentHealth == 100)
        {
            _marginOfError = 3;
            _heightAdded = 2f;
        }
        else if (_playerHealth.currentHealth < 100 && _playerHealth.currentHealth > 50)
        {
            _marginOfError = 1;
            _heightAdded = 3f;
        }
        else if (_playerHealth.currentHealth < 50 && _playerHealth.currentHealth > 0)
        {
            _marginOfError = 0;
            _heightAdded = 5;
        }
    }
    private void CalcHeight() 
    {
        DOTween.To(() => _shootController.height, x => _shootController.height = x,
                _heightAdded, 1f)
            .SetEase(Ease.Linear).OnComplete(() => _shootController.attack = true);
    }
}

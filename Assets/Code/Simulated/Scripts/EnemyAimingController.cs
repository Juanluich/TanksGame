using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAimingController : MonoBehaviour
{
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] EnemyShootController _shootController;

    float _accuracyError;
    float _heightAdded;

    public void CalcDirection(Transform targetPosition, Transform playerPosition)
    {
        CalcDifficulty();
        // Margin of error
        Vector3 accuracyPos = (Random.onUnitSphere * _accuracyError) + playerPosition.position;
        accuracyPos.y = 0f;

        targetPosition.DOMove(accuracyPos, 2f)
            .SetEase(Ease.Linear)
            .OnComplete(()=> CalcHeight());        
    }

    private void CalcDifficulty()
    { 
        // max height = 5, max accuracy = 2
        if (_playerHealth.currentHealth == 100)
        {
            _accuracyError = 0;
            _heightAdded = 1;
        }
        else if (_playerHealth.currentHealth < 100 && _playerHealth.currentHealth > 50)
        {
            _accuracyError = 1;
            _heightAdded = 2;
        }
        else if (_playerHealth.currentHealth < 50 && _playerHealth.currentHealth > 0)
        {
            _accuracyError = 2;
            _heightAdded = 4;
        }
    }
    private void CalcHeight() 
    {
        DOTween.To(() => _shootController.height, x => _shootController.height = x,
                _shootController.height + _heightAdded, 1f)
            .SetEase(Ease.Linear).OnComplete(() => _shootController.attack = true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUD : MonoBehaviour
{
    [SerializeField] Image _heightBar;
    [SerializeField] EnemyShootController _shootController;

    private void Update()
    {
        _heightBar.fillAmount = _shootController.height / 5;
    }
}

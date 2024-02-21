using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image _heightBar;
    [SerializeField] ShootController _shootController;

    private void Update()
    {
        _heightBar.fillAmount = _shootController.height / 5;
    }
}

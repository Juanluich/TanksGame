using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarsUI : MonoBehaviour
{
    [SerializeField] Image heightBar;
    [SerializeField] ShootController shootController;

    private void Update()
    {
        heightBar.fillAmount = shootController.height / 5;
    }
}

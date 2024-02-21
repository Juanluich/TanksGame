using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileImpactBehaviour : MonoBehaviour
{
    public UnityEvent onEnemyHit;
    public UnityEvent onHit;

    [SerializeField] GameObject smokeFX;
    [SerializeField] GameObject hitText;
    private string text;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip impactSFX;
    private void OnCollisionEnter(Collision collision)
    {
        text = "Miss!";
        if (collision.collider.tag == "Enemy")
        {
            onEnemyHit.Invoke();
            text = "Hitted!";
        }
        onHit.Invoke();

        Instantiate(smokeFX, transform.position, Quaternion.identity);
        CreateTMP();
        audioSource.PlayOneShot(impactSFX);
        Invoke(nameof(Desactivate),.25f);
    }

    private void Desactivate()
    {
        this.gameObject.SetActive(false);

    }

    public void CreateTMP()
    {
        GameObject textGO = Instantiate(hitText, transform.position, Quaternion.identity);
        TextMeshPro textMeshPro = textGO.GetComponent<TextMeshPro>();
        textMeshPro.text = text;

        textMeshPro.rectTransform.DOMoveY(textMeshPro.rectTransform.position.y + 4f, .5f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => textMeshPro.DOFade(0f, .5f)
                .OnComplete(() => Destroy(textGO)));

        textGO.transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}

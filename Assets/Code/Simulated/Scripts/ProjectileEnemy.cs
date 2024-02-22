using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileEnemy : MonoBehaviour
{
    public UnityEvent onPlayerHit;
    public UnityEvent onHit;

    [SerializeField] GameObject smokeFX;
    [SerializeField] GameObject hitText;
    private string text;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _impactSFX;
    private void OnCollisionEnter(Collision collision)
    {
        text = "Miss!";
        if (collision.collider.tag == "Player")
        {
            onPlayerHit.Invoke();
            Debug.Log("Player hitted!");
            text = "Hit!";
        }
        onHit.Invoke();

        Instantiate(smokeFX, transform.position, Quaternion.identity);
        CreateTMP();
        _audioSource.PlayOneShot(_impactSFX);
        Invoke(nameof(Desactivate), .25f);
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

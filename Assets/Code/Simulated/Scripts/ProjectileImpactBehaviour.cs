using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileImpactBehaviour : MonoBehaviour
{
    public UnityEvent onNotifyHit;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip impactSFX;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") return;
        
        if (collision.collider.tag == "Enemy")
        {
            onNotifyHit.Invoke();
            Debug.Log("Enemy hitted!");
        }
        Debug.Log(collision.collider.name);
        audioSource.PlayOneShot(impactSFX);
        Invoke(nameof(Desactivate),.25f);
    }

    private void Desactivate()
    {
        this.gameObject.SetActive(false);

    }
}

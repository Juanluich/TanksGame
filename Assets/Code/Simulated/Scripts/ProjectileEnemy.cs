using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileEnemy : MonoBehaviour
{
    public UnityEvent onNotifyHit;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip impactSFX;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy") return;

        if (collision.collider.tag == "Player")
        {
            onNotifyHit.Invoke();
            Debug.Log("Player hitted!");
        }
        Debug.Log(collision.collider.name);
        audioSource.PlayOneShot(impactSFX);
        Invoke(nameof(Desactivate), .25f);
    }

    private void Desactivate()
    {
        this.gameObject.SetActive(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileEnemy : MonoBehaviour
{
    public UnityEvent onPlayerHit;
    public UnityEvent onHit;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _impactSFX;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            onPlayerHit.Invoke();
            Debug.Log("Player hitted!");
        }
        onHit.Invoke();

        _audioSource.PlayOneShot(_impactSFX);
        Invoke(nameof(Desactivate), .25f);
    }

    private void Desactivate()
    {
        this.gameObject.SetActive(false);

    }
}

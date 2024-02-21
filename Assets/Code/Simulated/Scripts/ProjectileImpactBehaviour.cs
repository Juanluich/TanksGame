using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileImpactBehaviour : MonoBehaviour
{
    public UnityEvent onEnemyHit;
    public UnityEvent onHit;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip impactSFX;
    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.collider.tag == "Enemy")
        {
            onEnemyHit.Invoke();
            Debug.Log("Enemy hitted!");
        }
        onHit.Invoke();

        audioSource.PlayOneShot(impactSFX);
        Invoke(nameof(Desactivate),.25f);
    }

    private void Desactivate()
    {
        this.gameObject.SetActive(false);

    }
}

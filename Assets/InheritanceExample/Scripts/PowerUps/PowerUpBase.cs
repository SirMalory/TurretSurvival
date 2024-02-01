using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] protected float PowerUpDuration = 2f;
    [Header("FX")]
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;

    private BoxCollider powerUpCollider;
    private MeshCollider powerUpVisuals;

    protected abstract void PowerUp();
    protected abstract void OnHit();

    //protected abstract void PowerDown();

    private void Awake()
    {
        powerUpCollider = GetComponent<BoxCollider>();
        powerUpVisuals = GetComponent<MeshCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            powerUpCollider.enabled = !powerUpCollider.enabled;
            powerUpVisuals.enabled = !powerUpVisuals.enabled;
            AudioHelper.PlayClip2D(_hitSound, 1, .1f);
            OnHit();
            PowerUp();

        }
    }

    private void Update()
    {
        PowerUpDuration -= 1;
        if (PowerUpDuration <= 0)
        {
            PowerDown();
        }
    }

    protected virtual void PowerDown()
    {
        gameObject.SetActive(false);
    }
}

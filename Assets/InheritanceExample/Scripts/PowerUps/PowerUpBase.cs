using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] private int _health = 2;
    [SerializeField] protected float PowerUpDuration = 3f;
    [Header("FX")]
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;

    private float _elapsedCooldownTime;
    private bool _isDisabled = false;
    private BoxCollider powerUpCollider;
    private MeshCollider powerUpVisuals;

    protected abstract void PowerUp();
    protected abstract void OnHit();

    //protected abstract void PowerDown();

    private void Awake()
    {
        _elapsedCooldownTime = 0;
        powerUpCollider = GetComponent<BoxCollider>();

    }

    private void DisablePowerUp()   
    {
        if (_isDisabled == false)
        {
            _elapsedCooldownTime += Time.deltaTime;
            if (_elapsedCooldownTime >= PowerUpDuration)
            {
                _isDisabled = true;
                PowerDown();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            _health -= 1;
            if (_health <= 0)
            {
                powerUpCollider.enabled = !powerUpCollider.enabled;

                AudioHelper.PlayClip2D(_hitSound, 1, .1f);
                OnHit();
                PowerUp();
            }
        }
    }

    private void Update()
    {
        DisablePowerUp();
    }

    protected virtual void PowerDown()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    [SerializeField] private GameObject _PowerUpSpawner;
    [SerializeField] private Transform _SpawnLocation;
    protected override void OnHit()
    {
        MoveSpeed *= 2;
    }

    public override void Kill()
    {
        Instantiate(_PowerUpSpawner, transform.position, transform.rotation);
        base.Kill();
    }
}

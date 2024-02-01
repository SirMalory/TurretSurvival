using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    public float MoveCooldown { get; set; } = 1f;
    public bool IsReadyToMove { get; private set; } = true;
    private float _elapsedCooldownTime;

    private void EnableMovement()
    {
        if (IsReadyToMove == false)
        {
            _elapsedCooldownTime += Time.deltaTime;
            if (_elapsedCooldownTime >= MoveCooldown)
            {
                IsReadyToMove = true;
                MoveSpeed = .05f;
            }
        }
    }

    private void Update()
    {
        EnableMovement();
    }

    protected override void OnHit()
    {
        MoveSpeed = 0f;
        StartCooldown();
    }

    private void StartCooldown()
    {
        IsReadyToMove = false;
        _elapsedCooldownTime = 0;
    }

    public override void Kill()
    {
        base.Kill();
    }
}

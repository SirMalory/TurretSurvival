using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    [SerializeField] float cooldown;
    float startTime;

    protected override void OnHit()
    {
        MoveSpeed = 0f;
        SlowTimer();
    }

    void SlowTimer()
    {
        if (Time.time - startTime < cooldown)
        {
            return;

        }
        startTime = cooldown;
        MoveSpeed = .05f;
    }

    public override void Kill()
    {
        base.Kill();
    }
}

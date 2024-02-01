using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePowerUp : PowerUpBase
{

    TurretController turretProperties;
    protected override void PowerUp()
    {
        turretProperties = FindAnyObjectByType<TurretController>();
        turretProperties.FireCooldown = 2f;
            
    }

    protected override void PowerDown()
    {
        turretProperties.FireCooldown = .5f;
        base.PowerDown();
    }

    protected override void OnHit()
    {
        
    }
}

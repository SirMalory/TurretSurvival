using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePowerUp : PowerUpBase
{
    TurretController turretController;
    protected override void PowerUp()
    {


        if (turretController.FireCooldown == .5)
        {
            turretController.FireCooldown = .25f;
        }
            
    }

    protected override void PowerDown()
    {
        //turretController.FireCooldown = .5f;
        base.PowerDown();
    }

    protected override void OnHit()
    {
        
    }
}

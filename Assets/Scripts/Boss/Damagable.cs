using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    private float crit = 0;
    private BossController bossController = null;

    private void OnCollisionEnter(Collision collision)
    {
        // TODO: GetSchaden von Spielerwaffe
        
        //bossController.TakeDamage(waffenSchaden + crit);
    }
}

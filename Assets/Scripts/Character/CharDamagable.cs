using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDamagable : MonoBehaviour
{
    [SerializeField] private GameObject attackManager; //the attack manager of the dragon
    [SerializeField] private float crit = 0; //crit is set for every collider on itself
    private CharController charController = null;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponentInParent<CharController>();
    }

    //called when hit
    private void OnCollisionEnter(Collision collision)
    {
        if (!charController.GetComponentInParent<Animator>().GetBool("Roll"))
        {
            //TODO: Check ob Dmg richtig gesetzt
            //float damage = attackManager.CurrentAttack.Damage;
            //test
            float damage = 5f;

            //call method to calculate damage
            charController.TakeDamage(damage + crit);
        }
    }
}

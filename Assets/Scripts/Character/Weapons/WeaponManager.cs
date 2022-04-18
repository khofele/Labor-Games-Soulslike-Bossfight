using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //access to character scripts and animator
    protected CharacterMovement charMovement;
    protected CharController charController;
    protected Animator animator;
    //weapon stats
    protected string weaponType = ""; //type of weapon
    protected float weaponWeight = 0f; //weight of the weapon
    protected float weaponMinDmg = 0f; //minimum damage the weapon makes
    protected float weaponMaxDmg = 0f; //maximum damage the weapon makes

    // Start is called before the first frame update
    void Start()
    {
        charMovement = gameObject.GetComponentInParent<CharacterMovement>();
        charController = gameObject.GetComponentInParent<CharController>();
        animator = charMovement.GetComponentInParent<Animator>();

        //set attack animations for current weapon
        //SetAttackAnimations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method to set animation methods suitable for the current weapon
    private void SetAttackAnimations()
    {

        //TODO: set animation motions for current weapon
        switch (weaponType)
        {
            case "shortsword":
                //Attack01R
                //Attack02R
                //Attack03R
                //HeavyAttack
                break;
            case "lance":
                break;
            default:
                Debug.Log("weaponType could not be set!");
                break;
        }
    }

    //--------------------------GETTER FOR DRAGON & CHAR-----------------------

    public float GetDamage()
    {
       //determine weapon damage regarding the characters attack power and a random value in the attack damage range
       //(between min dmg and max dmg)
       float damage = Random.Range(weaponMinDmg, weaponMaxDmg) + charController.GetAttackPower();
       return damage;
    }

    public string GetWeaponType()
    {
        return weaponType;
    }

    public float GetWeaponWeight()
    {
        return weaponWeight;
    }
}

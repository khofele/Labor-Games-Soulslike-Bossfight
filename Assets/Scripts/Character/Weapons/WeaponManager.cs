using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //access to the CharacterMovement script and animator
    protected CharacterMovement charMovement;
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
        //TODO: passt Aufruf?
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

    public string GetWeaponType()
    {
        return weaponType;
    }

    public float GetWeaponWeight()
    {
        return weaponWeight;
    }

    public float GetWeaponMinDmg()
    {
        //determine weaponMinDmg regarding the characters attack power
        weaponMinDmg = weaponMinDmg + charMovement.GetAttackPower();
        return weaponMinDmg;
    }

    public float GetWeaponMaxDmg()
    {
        //determine weaponMaxDmg regarding the characters attack power
        weaponMaxDmg = weaponMaxDmg + charMovement.GetAttackPower();
        return weaponMaxDmg;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypeEnum
{
    SHORTSWORD, LONGSWORD, LANCE, HAMMER, DAGGERS
}

public enum WeaponTypeHandedEnum
{
    ONEHAND, TWOHAND, BOTH
}

public enum WeaponAttackTypeEnum
{
    NORMAL, HEAVY
}

public abstract class Weapon : MonoBehaviour
{
    //access to character scripts and animator
    protected CharacterMovement charMovement;
    protected CharController charController;
    protected Animator animator; //animator for Game scene
    //weapon stat fields
    protected WeaponTypeEnum weaponType; //what weapon it is
    protected WeaponTypeHandedEnum weaponTypeHanded; //type of weapon (onehand, twohand)
    protected float weaponWeight = 0f; //weight of the weapon
    protected float weaponMinDmg = 0f; //minimum damage the weapon makes
    protected float weaponMaxDmg = 0f; //maximum damage the weapon makes
    protected float heavyAttackAddDamage = 50f; //additional damage for heavy attacks
    //weapon prefab field
    protected Weapon weaponPrefab = null;


    // Start is called before the first frame update
    private void Start()
    {
        charMovement = gameObject.GetComponentInParent<CharacterMovement>();
        charController = gameObject.GetComponentInParent<CharController>();
        animator = charMovement.GetComponentInParent<Animator>();  
    }

    //method called by menu to set the animation controller for the chosen weapon (ItemManager data)
    //TODO Aufruf in CharController
    public void SetAnimationController(WeaponTypeEnum weaponType)
    {
        //animator used for equip setting
        Animator playerAnimator = FindObjectOfType<CharController>().GetComponent<Animator>();

        switch (weaponType)
        {
            case WeaponTypeEnum.SHORTSWORD:
                playerAnimator.runtimeAnimatorController = Resources.Load("Character/AC/ACShortsword") as RuntimeAnimatorController;
                break;
            case WeaponTypeEnum.LANCE:
                playerAnimator.runtimeAnimatorController = Resources.Load("Character/AC/ACLance") as RuntimeAnimatorController;
                break;
            case WeaponTypeEnum.LONGSWORD:
                playerAnimator.runtimeAnimatorController = Resources.Load("Character/AC/ACLongsword") as RuntimeAnimatorController;
                break;
            case WeaponTypeEnum.HAMMER:
                playerAnimator.runtimeAnimatorController = Resources.Load("Character/AC/ACHammer") as RuntimeAnimatorController;
                break;
            case WeaponTypeEnum.DAGGERS:
                playerAnimator.runtimeAnimatorController = Resources.Load("Character/AC/ACDaggers") as RuntimeAnimatorController;
                break;
            default:
                Debug.Log("SetAnimationController fehlgeschlagen.");
                break;
        }
    }

        //--------------------------GETTER FOR DRAGON & CHAR-----------------------

    //Getter of the current animator state type to determine damage with
    public WeaponAttackTypeEnum GetCurrentAttackType()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("HeavyAttack"))
            return WeaponAttackTypeEnum.HEAVY;
        else return WeaponAttackTypeEnum.NORMAL;
    }

    public float GetDamage()
    {
        //determine weapon damage regarding the characters attack power and a random value in the attack damage range
        //(between min dmg and max dmg) as well as the attack type done (normal / heavy)
        float damage = Random.Range(weaponMinDmg, weaponMaxDmg) + charController.GetAttackPower();

        //if heavy attack: additional damage
        if(GetCurrentAttackType() == WeaponAttackTypeEnum.HEAVY)
        {
            damage += heavyAttackAddDamage;
        }

       return damage;
    }

    public WeaponTypeEnum GetWeaponType()
    {
        return weaponType;
    }

    public WeaponTypeHandedEnum GetWeaponTypeHanded()
    {
        return weaponTypeHanded;
    }

    public float GetWeaponWeight()
    {
        return weaponWeight;
    }

    public float GetWeaponMinDmg()
    {
        return weaponMinDmg;
    }

    public float GetWeaponMaxDmg()
    {
        return weaponMaxDmg;
    }

    public Weapon GetWeaponPrefab()
    {
        return weaponPrefab;
    }
}

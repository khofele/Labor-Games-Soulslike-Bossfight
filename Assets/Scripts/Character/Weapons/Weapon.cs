using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
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
    //weapon prefab
    protected GameObject weaponPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        charMovement = gameObject.GetComponentInParent<CharacterMovement>();
        charController = gameObject.GetComponentInParent<CharController>();
        animator = charMovement.GetComponentInParent<Animator>();

        
    }

    //method called by menu to set the char controller prefab of the chosen weapon
    //TODO Aufruf Menü (SetCharacterPrefab()) nach Reset()-Methode des Weapon-Skripts
    public void SetCharacterPrefab()
    {
        charController.SetWeaponPrefab(weaponPrefab);
    }

    //method called by menu to set the animation controller for the chosen weapon
    //TODO Aufruf Menü (SetAnimationController() nach Reset()-Methode des Weapon-Skripts)
    public void SetAnimationController()
    {
        switch (weaponType)
        {
            case "shortsword":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACSword") as RuntimeAnimatorController;
                break;
            case "lance":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACLance") as RuntimeAnimatorController;
                break;
            case "longsword":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACLongsword") as RuntimeAnimatorController;
                break;
            case "hammer":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACHammer") as RuntimeAnimatorController;
                break;
            case "daggers":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACDaggers") as RuntimeAnimatorController;
                break;
            default:
                Debug.Log("SetAnimator fehlgeschlagen.");
                break;
        }
    }

    //test method - CAN BE DELETED AFTER MENU IS IMPLEMENTED
    //TODO WENN MENÜ DA LÖSCHEN
    public void SetAnimationController(string weaponType)
    {
        switch (weaponType)
        {
            case "shortsword":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACSword") as RuntimeAnimatorController;
                break;
            case "lance":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACLance") as RuntimeAnimatorController;
                break;
            case "longsword":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACLongsword") as RuntimeAnimatorController;
                break;
            case "hammer":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACHammer") as RuntimeAnimatorController;
                break;
            case "daggers":
                animator.runtimeAnimatorController = Resources.Load("Character/AC/ACDaggers") as RuntimeAnimatorController;
                break;
            default:
                Debug.Log("SetAnimator fehlgeschlagen.");
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

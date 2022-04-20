using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the character controller class 
public class CharController : MonoBehaviour
{
    //General
    [SerializeField] private Transform hand = null; //right hand of the character (holds weapon)
    private CharacterMovement charMovement = null; //CharacterMovement script

    //Name
    private string charName = "";

    //Stats
    [SerializeField] private int vitality = 5;
    [SerializeField] private int endurance = 2;
    [SerializeField] private int strength = 4;
    [SerializeField] private int physStrength = 3;
    //Attributes
    private float health = 1000f; //max HP
    private float stamina = 0f; //max Stamina
    private float carryCapacity = 50f;
    private float resistance = 15f;
    private float defense = 50f;
    private float attackPower = 50f; //is added to the weaponMinDmg value of the current weapon
    private float staminaReg = 0.04f;
    //multiplicator for SetAttributes()
    [SerializeField] private float multiplicator = 100f;
    //action speed
    private float speed = 6f;
    //fight
    [SerializeField] private GameObject dragon = null; //the enemy - dragon
    [SerializeField] private int stunValue = 500; //value at which the character gets stunned from an attack
    private float currentHealth = 0f;
    private float currentStamina = 0f;
    private int currentPotions = 0; //number of currently left potions
    private bool regStamina = true; //if currently stamina shall be regenerated

    //equipment
    [SerializeField] private int potionCount = 5; //max potions
    [SerializeField] private float healValue = 400f; //value of health one potion heals
    [SerializeField] private GameObject weaponPrefab = null; //TODO: set weapon in menu //current weapon prefab
    private GameObject currentWeapon = null; //current weapon object (instantiated)
    private float weaponWeight = 0f; //weight of current weapon
    private float armorWeight = 0f;  //weight of current armor
    private float armorDef = 0f; //defense of current armor
    //armor attach positions
    [SerializeField] private Transform head = null;
    [SerializeField] private Transform torso = null;
    //armor prefabs and objects (instantiated)
    [SerializeField] private GameObject armorHelmetPrefab = null; //TODO: set armor in menu //current armor prefab
    [SerializeField] private GameObject armorTorsoPrefab = null; //TODO: set armor in menu //current armor prefab
    private GameObject currentArmorHelmet = null;
    private GameObject currentArmorTorso = null;



    // Start is called before the first frame update
    void Start()
    {
        charName = "Godwin the Brave";

        charMovement = GetComponent<CharacterMovement>();

        //set current weapon and place it in character's hand
        currentWeapon = Instantiate<GameObject>(weaponPrefab);
        currentWeapon.transform.parent = hand.transform;
        currentWeapon.transform.position = hand.position;
        //set current armor and place it on character model
        SetAndAttachArmor(); 
        //set values regarding equipment
        SetEquipmentValues();
        //set attributes with chosen stats and current values
        SetAttributes();
        //determine the speed actions are performed
        //SetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        //regeneration
        RegenerateStamina();
    }

    //method called in Update() to regenerate the current stamina with time (if not using a skill at the moment)
    private void RegenerateStamina()
    {
        if (regStamina && currentStamina + staminaReg <= stamina) //reg not more stamina than the max value
        {
            //no reg during whole attack combo
            if (!(charMovement.GetAnimator().GetBool("Attack01R")) && !(charMovement.GetAnimator().GetBool("Attack02R")) && !(charMovement.GetAnimator().GetBool("Attack03R")))
            {
                currentStamina += staminaReg;
            }

            //Debug.Log(currentStamina);
        }
    }

    //method to call when skills need stamina
    public void UseStamina(float usedStamina)
    {
        if (currentStamina - usedStamina >= 0f)
        {
            currentStamina = currentStamina - usedStamina;
        }
    }

    //method called by CharacterMovement script after using a potion
    public void Heal()
    {
        currentHealth += healValue;
        //health not higher than max health
        if (currentHealth > health)
        {
            currentHealth = health;
        }
        currentPotions--;
    }


    //--------------------------DAMAGE-----------------------

    //the received damage is calculated depending on the hitted collider(s) and the damage value
    //submitted by the boss attack.
   
    public void TakeDamage(float damage)
    {
        //subtract damage from current health
        currentHealth -= damage;

        //call animation
        charMovement.GotHit();

        //stun value reached --> player gets stunned
        if (damage >= stunValue)
        {
            charMovement.GotStunned();
        }

        //health is <= 0 --> player dies
        if (currentHealth <= 0f)
        {
            charMovement.Death();
        }

        Debug.Log(currentHealth);
    }


    //--------------------------SETTER METHODS-----------------------

    //method to set the equipment values depending on the chosen equipment
    //these values are used to determine the speed of the player's actions
    private void SetEquipmentValues()
    {
        //set armor values
        //armorWeight = currentArmor.GetComponent<ArmorManager>().GetArmorWeight();
        //armorDef = currentArmor.GetComponent<ArmorManager>().GetArmorDef();
        //set weaponWeight
        weaponWeight = currentWeapon.GetComponent<WeaponManager>().GetWeaponWeight();

        Debug.Log(armorWeight);
        Debug.Log(weaponWeight);
    }


    //Method to set the attributes depending on the chosen stats and equipment.
    //For the respective base value, the determined stat is multiplied by the multiplier and added to the base value.
    //TODO: Balancing Berechnung + Basewerte
    private void SetAttributes()
    {
        //stat affected
        health = health + vitality * multiplicator;
        stamina = stamina + endurance * multiplicator;
        staminaReg = staminaReg + endurance / multiplicator;
        attackPower = attackPower + strength;
        carryCapacity = carryCapacity + physStrength * multiplicator;
        //equipment affected
        resistance = resistance + armorDef * multiplicator;
        defense = defense + armorDef * multiplicator;

        //set start current health, stamina values and potion count
        currentHealth = health;
        currentStamina = stamina;
        currentPotions = potionCount;
    }


    //method to set the current armor pieces and attach them on the character model, called in Start()
    private void SetAndAttachArmor()
    {
        //instantiate the chosen prefab
        currentArmorHelmet = Instantiate<GameObject>(armorHelmetPrefab);
        currentArmorTorso = Instantiate<GameObject>(armorTorsoPrefab);

        //attach armor pieces als children to body pieces
        currentArmorHelmet.transform.parent = head.transform;
        currentArmorHelmet.transform.position = head.position;
        currentArmorTorso.transform.parent = torso.transform;
        currentArmorTorso.transform.position = torso.position;
    }

    //method to determine speed with which actions are performed (walk, run, attack, roll)
    private void SetSpeed()
    {
        //TODO: Berechnung anpassen! + Magic Number weg
        speed = (armorWeight + weaponWeight) / 10;
    }

    //setter for the bool regStamina - whether stamina shall be regenerated or not
    public void SetRegStamina(bool regStaminaValue)
    {
        regStamina = regStaminaValue;
    }


    //--------------------------GETTER METHODS-----------------------
    public float GetSpeed()
    {
        return speed;
    }

    public float GetAttackPower()
    {
        return attackPower;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetCurrentStamina()
    {
        return currentStamina;
    }

    public int GetCurrentPotions()
    {
        return currentPotions;
    }

    //Getter for the CharDamagable-scripts to get the values of the current attack of the dragon
    public GameObject GetDragon()
    {
        return dragon;
    }

    //for menu to display character name
    public string GetCharName()
    {
        return charName;
    }
}

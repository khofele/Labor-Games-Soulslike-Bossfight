using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the character controller class 
public class CharController : MonoBehaviour
{
    //General
    [SerializeField] private Transform handR = null; //right hand of the character (holds weapon)
    [SerializeField] private Transform handL = null; //left hand of the character (sometimes holds weapon)
    private CharacterMovement charMovement = null; //CharacterMovement script

    //Name
    private string charName = "";

    //Attributes
    private AttributeManager attrManager = null; //attribute manager of the menu used to get the current calculated attributes
    [SerializeField] private float staminaReg = 0.08f;
    private float health = 0f; //max HP
    private float stamina = 0f; //max Stamina
    private float carryCapacity = 0f;
    private float resistance = 0f;
    private float defense = 0f;
    private float attackPower = 0f; //is added to the weaponMinDmg value of the current weapon
    //action speed
    private float animationSpeed = 1.25f; //speed of animations and animator
    private float movementSpeed = 6f; //speed for movement like walking, running and rolling
    //multiplicator for speed
    [SerializeField] private float multiplicator = 100f;

    //fight
    [SerializeField] private AttackManager attackManager; //the attack manager of the enemy - the dragon
    private bool isAttacking = false; //whether character is currently attacking - needed by the enemy
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }

    [SerializeField] private int stunValue = 500; //value at which the character gets stunned from an attack
    private float currentHealth = 0f;
    private float currentStamina = 0f;
    private int currentPotions = 0; //number of currently left potions
    private bool regStamina = true; //if currently stamina shall be regenerated

    //equipment
    private ItemManager itemManager = null; //item manager of the menu used for equipment setting
    private int potionCount = 0; //max potions
    [SerializeField] private float healValue = 400f; //value of health one potion heals
    private Weapon weaponPrefab = null; //current weapon prefab
    private Weapon currentWeapon = null; //current weapon object (instantiated)
    private Weapon currentSecondWeapon = null; //current second weapon (instantiated if equipped)
    private float weaponWeight = 0f; //weight of current weapon
    private float armorWeight = 0f;  //weight of current armor
    private float armorDef = 0f; //defense of current armor
    //armor attach positions
    [SerializeField] private Transform head = null;
    [SerializeField] private Transform torso = null;
    //armor prefabs and objects (instantiated)
    private Armor armorHelmetPrefab = null; //current armor prefabs
    private Armor armorTorsoPrefab = null;
    private Armor currentArmorHelmet = null; //instantiated objects
    private Armor currentArmorTorso = null; 



    // Start is called before the first frame update
    private void Start()
    {
        charName = "Godwin the Brave";

        charMovement = GetComponent<CharacterMovement>();
        attrManager = FindObjectOfType<AttributeManager>();
        itemManager = FindObjectOfType<ItemManager>();

        //set current weapon and place it in character's hand, also set animation controller
        SetAndAttachWeapon();
        //set current armor and place it on character model
        SetAndAttachArmor();
        //set values regarding equipment
        SetEquipmentValues();
        //set attributes with chosen stats and current values
        SetAttributes();
        //determine the speed actions are performed
        SetSpeed();
    }

    // Update is called once per frame
    private void Update()
    {
        //regeneration
        RegenerateStamina();
    }

    //method called in Update() to regenerate the current stamina with time (if not using a skill at the moment)
    private void RegenerateStamina()
    {
        //Debug.Log(currentStamina);

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
    //submitted by the boss attack - called by CharDamagable.
   
    public void TakeDamage(float damage)
    {
        Debug.Log("TakeDamage: " + damage);

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

    //If the boss attacks with fire, poison or magic, the player gets damage over time on top of the normal
    //damage value submitted by the boss attack - called by CharDamagable.
    //dot - the damage that is dealt over time
    //dotDelay - the delay between damage dealing
    //valueEveryTime - the percentage of the dot that is dealt each time (at once)
    public IEnumerator DamageOverTime(float dot, float dotDelay, float valueEveryTime)
    {
        float dealtDamage = 0f; //already dealt damage
        float damage = valueEveryTime; //the damage value that shall be dealt at once

        while(dealtDamage < dot)
        {
            dealtDamage += damage; //add damage to dealt damage
            //deal only as much damage as dot, not more
            if (dealtDamage > dot)
            {
                damage -= dot - dealtDamage;
            }

            Debug.Log("DamageOverTime");

            //call coroutine which deals damage after time
            yield return StartCoroutine(TakeDot(damage, dotDelay));
        }
    }

    //coroutine called by DamageOverTime() to deal the dot
    private IEnumerator TakeDot(float damage, float dotDelay)
    {
        yield return new WaitForSeconds(dotDelay);

        //subtract damage from current health
        currentHealth -= damage;

        //health is <= 0 --> player dies
        if (currentHealth <= 0f)
        {
            charMovement.Death();
        }

        Debug.Log(currentHealth);
    }


    //--------------------------SETTER METHODS-----------------------

    //method to set the equipment values depending on the chosen equipment (info from ItemManager)
    //these values are used to determine the speed of the player's actions
    private void SetEquipmentValues()
    {
        //set armor values
        armorWeight = itemManager.CurrentArmorWeight;
        armorDef = itemManager.CurrentArmorDef;
        //set weaponWeight
        weaponWeight = itemManager.CurrentWeaponWeight; 
        //set current potions
        potionCount = itemManager.PotionCount;
    }

    //Method to set the attributes depending on the chosen stats and equipment.
    private void SetAttributes()
    {
        health = attrManager.Health;
        stamina = attrManager.Stamina;
        staminaReg = attrManager.StaminaReg;
        attackPower = attrManager.AttackPower;
        carryCapacity = attrManager.CarryingCapacity;
        resistance = attrManager.Resistance;
        defense = attrManager.Defense;

        //set start current health, stamina values and potion count
        currentHealth = health;
        currentStamina = stamina;
        currentPotions = potionCount;
    }

    //method to set the prefab of the chosen weapon - called in Weapon script
    public void SetWeaponPrefab(Weapon weaponPref)
    {
        weaponPrefab = weaponPref;
    }

    //method to set the current weapon and attach it on the hand - called in Start()
    private void SetAndAttachWeapon()
    {
        weaponPrefab = itemManager.CurrentWeaponPrefab;

        //equip main weapon
        currentWeapon = Instantiate<Weapon>(weaponPrefab);
        currentWeapon.transform.parent = handR.transform;
        currentWeapon.transform.position = handR.position;

        //if daggers chosen - equip second weapon
        if(currentWeapon.GetWeaponType() == "daggers") 
        {
            currentSecondWeapon = Instantiate<Weapon>(weaponPrefab);
            currentSecondWeapon.transform.parent = handL.transform;
            currentSecondWeapon.transform.position = handL.position;
        }

        //choose correct Animation Controller for weapon
        currentWeapon.SetAnimationController(itemManager.CurrentWeaponType);
    }

    //method to set the prefabs of the chosen armor - called in Armor script
    public void SetArmorPrefabs(Armor helmetPrefab, Armor torsoPrefab)
    {
        armorHelmetPrefab = helmetPrefab;
        armorTorsoPrefab = torsoPrefab;
    }

    //method to set the current armor pieces and attach them on the character model - called in Start()
    private void SetAndAttachArmor()
    { 
        armorHelmetPrefab = itemManager.CurrentHelmetPrefab;
        armorTorsoPrefab = itemManager.CurrentTorsoArmorPrefab;

        //instantiate the chosen prefab
        currentArmorHelmet = Instantiate<Armor>(armorHelmetPrefab);
        currentArmorTorso = Instantiate<Armor>(armorTorsoPrefab);

        //attach armor pieces als children to body pieces
        currentArmorHelmet.transform.parent = head.transform;
        currentArmorHelmet.transform.position = head.position;
        currentArmorTorso.transform.parent = torso.transform;
        currentArmorTorso.transform.position = torso.position;
    }

    //method to determine speed with which actions are performed in the animator
    private void SetSpeed()
    {
        //set speed depending on equipment weight (small weight - faster speed, big weight - lower speed)
        animationSpeed = animationSpeed + multiplicator * (armorWeight + weaponWeight);
        //set speed of animator (animations)
        GetComponent<Animator>().speed = animationSpeed;
        //set movement speed
        movementSpeed = movementSpeed * animationSpeed;

        //Debug.Log("movementSpeed: " + movementSpeed + ", animationSpeed: " + animationSpeed);
        //Debug.Log(GetComponent<Animator>().speed);
    }

    //setter for the bool regStamina - whether stamina shall be regenerated or not
    public void SetRegStamina(bool regStaminaValue)
    {
        regStamina = regStaminaValue;
    }


    //--------------------------GETTER METHODS-----------------------
    public float GetMovementSpeed()
    {
        return movementSpeed;
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

    //control current potion number
    public int GetCurrentPotions()
    {
        return currentPotions;
    }

    //get current weapon name as string - to get current prefab(s)
    public string GetCurrentWeapon()
    {
        return currentWeapon.ToString();
    }

    //getter for dragon - returns current weapon object
    public Weapon GetCurrentWeaponObject()
    {
        return currentWeapon;
    }

    //Getter for the CharDamagable-scripts to get the values of the current attack of the dragon
    public AttackManager GetAttackManager()
    {
        return attackManager;
    }

    //for menu to display character name
    public string GetCharName()
    {
        return charName;
    }

    //for dragon - returns true if successfull combo from player --> higher stagger damage to dragon
    public bool ComboSuccess()
    {
        //if Attack03 reached at method call - combo success
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack03R"))
        {
            return true;
        }
        else return false; //Attack03 not reached - combo not finished 
    }
}

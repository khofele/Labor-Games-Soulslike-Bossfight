using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Name
    private string name = "";

    //general
    [SerializeField] private Transform cam = null; //Main camera controlled by Cinemachine camera
    private CharacterController controller = null; 
    private Rigidbody rbody = null;
    private Animator animator = null;

    //Stats
    [SerializeField] private int vitality = 5;
    [SerializeField] private int endurance = 5;
    [SerializeField] private int strength = 5;
    [SerializeField] private int physStrength = 5;
    //Attributes
    private float health = 1000f; //max HP
    private float stamina = 100f; //max Stamina
    private float carryCapacity = 50f;
    private float resistance = 15f;
    private float defense = 50f;
    private float attackPower = 50f;
    private float staminaReg = 5f;
    //multiplicator for SetAttributes()
    [SerializeField] private float multiplicator = 100f;
    //action speed
    private float speed = 6f;
    //fight
    private float currentHealth = 0f; 
    private float currentStamina = 0f;
    private int currentPotions = 0; //number of currently left potions

    //equipment
    [SerializeField] private int potionCount = 5; //TODO: Anzahl anpassen //max potions
    [SerializeField] private float healValue = 500f; //TODO: Wert anpassen //value of health one potion heals
    private float armorValue = 0f;
    private string weaponType = ""; //TODO: add all weapon types //sword, lance, ... 
    private float weaponValue = 0f;

    //sounds
    [SerializeField] private AudioClip[] footstepSounds;    // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip[] weaponSounds;      //an array of weapon slash sounds that will be randomly selected from.
    [SerializeField] private AudioClip rollSound;           // the sound played when character dodges (rolls).
    private AudioSource audioSource; //current audio source
    private float elapsedTime = 0; //time since last step sound
    private float soundDelay = 0.5f; //delay for sound to play

    //attack combo values
    [SerializeField] private float cooldownTime = 0.8f; //attack cooldown
    private float nextAttackStartTime = 0f; //time the next attack can start
    private static int noOfClicks = 0; //number of current clicks in combo
    private float lastClickedTime = 0; //last clicked time in combo
    private float maxComboDelay = 1; //max time to click to stay in combo


    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        name = "Godwin the Brave";

        //set values regarding equipment
        SetEquipmentValues();
        //set attributes with chosen stats
        SetAttributes();
        //set current health and stamina values and potion count
        currentHealth = health;
        currentStamina = stamina;
        currentPotions = potionCount;
        //set attack animations for current weapon
        //SetAttackAnimations();
        //determine the speed actions are performed
        //SetSpeed();
    }

    // Update is called once per frame
    private void Update()
    {
        //--------------------------MOVEMENT-----------------------
        //direction calculation
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //check if button is pressed
        if (direction.magnitude >= 0.01f)
        {
            //run
            if (Input.GetKey(KeyCode.LeftShift) && !animator.GetBool("Run"))
            {
                animator.SetBool("Run", true);
            }
            //walk
            else if (!animator.GetBool("Walk"))
            {
                animator.SetBool("Walk", true);
            }
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }

        //roll
        if (Input.GetKey(KeyCode.Space) && !animator.GetBool("Roll"))
        {
            animator.SetBool("Roll", true);
        }


        //--------------------------FIGHT-----------------------
        //attack (combo)
        //!is aborted if player is hit/stunned/dies
        if (Input.GetKey(KeyCode.Mouse0))
        {
            AttackCombo(); //start combo
        }
        //reset animation after time
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01R"))
        {
            animator.SetBool("Attack01R", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02R"))
        {
            animator.SetBool("Attack02R", false);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack03R"))
        {
            animator.SetBool("Attack03R", false);
            noOfClicks = 0;
        }
        if(Time.time - lastClickedTime > maxComboDelay) //clicked not fast enough to continue combo
        {
            noOfClicks = 0;
        }
        if(Time.time > nextAttackStartTime) //enough time went by to start new combo
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                AttackCombo();
            }
        }


        //heavy attack
        if (Input.GetKey(KeyCode.Mouse1) && !animator.GetBool("attacking"))
        {
            animator.SetBool("HeavyAttack", true);
        }


        //use potion (if enough potions left, pressing E and not currently using a potion)
        if (currentPotions >= 1 && Input.GetKey(KeyCode.E) && !animator.GetBool("UsePotion"))
        {
            animator.SetBool("UsePotion", true);
        }


    }


    //method called for attack combo (player clicking left mouse)
    //lastClickedTime = when player clicked last time
    //noOfClicks = counted to continue combo (if player clicks fast enough)
    public void AttackCombo()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        //start Attack01
        if(noOfClicks == 1)
        {
            animator.SetBool("Attack01R", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        //start Attack02 if clicked fast enough
        if(noOfClicks >= 2 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01R"))
        {
            animator.SetBool("Attack01R", false);
            animator.SetBool("Attack02R", true);
        }
        //start Attack03 if clicked fast enough
        if (noOfClicks >= 3 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02R"))
        {
            animator.SetBool("Attack02R", false);
            animator.SetBool("Attack03R", true);
        }
    }



    //--------------------------STUN-----------------------
    //method that is called when the character got stunned
    public void GotStunned()
    {
        if (!animator.GetBool("GotStunned")) //if not already stunned atm
        {
            animator.SetBool("GotStunned", true);
            Invoke("EndStun", 3);
        }
    }

    private void EndStun()
    {
        animator.SetBool("GotStunned", false);
        animator.SetBool("alreadyStunned", false);
    }


    //--------------------------DAMAGE-----------------------

    //method that is called when the character receives damage from the boss
    public void GotHit(float damage)
    {
        //TODO: ersetzen durch finalen Code (Ticket genaue Hit Detection + erhaltener Dmg Berechnung)
        currentHealth -= CalculateDamage(damage);

        //health is <= 0 --> player dies
        if(currentHealth <= 0f)
        {
            Death();
        }
    }

    //the received damage is calculated depending on the hitted collider(s) and the damage value
    //submitted by the boss attack.
    private float CalculateDamage(float damage)
    {
        //TODO: ersetzen durch finalen Code (Ticket genaue Hit Detection + erhaltener Dmg Berechnung)
        return damage;
    }

    //method called by GotHit() if player got more damage than or same damage as he has currentHealth
    private void Death()
    {
        if (!animator.GetBool("diedBefore"))
        {
            animator.SetBool("Death", true);
        }
    }

    //method used by UsePotionState to heal the player after using a potion
    public void UsePotion()
    {
        if(currentPotions >= 1) {
            currentHealth += healValue;
            //health not higher than max health
            if(currentHealth > health)
            {
                currentHealth = health;
            }
            currentPotions--;
        }
    }


    //--------------------------SETTER METHODS-----------------------

    //method to set the equipment values depending on the chosen equipment
    //these values are used to determine the speed of the player's actions
    private void SetEquipmentValues()
    {
        //TODO
        //armorValue
        //weaponType
        weaponType = "sword"; //TODO weaponType setzen
        //weaponValue
    }


    //Method to set the attributes depending on the chosen stats and equipment.
    //For the respective base value, the determined stat is multiplied by the multiplier and added to the base value.
    //TODO: Balancing Berechnung
    private void SetAttributes()
    {
        //stat affected
        health += vitality * multiplicator;
        stamina += endurance * multiplicator;
        staminaReg += endurance * multiplicator;
        attackPower += strength * multiplicator;
        carryCapacity += physStrength * multiplicator;
        //equipment affected
        resistance += armorValue * multiplicator;
        defense += armorValue * multiplicator;
    }

    //method to determine speed with which actions are performed (walk, run, attack, roll)
    private void SetSpeed()
    {
        //TODO: Berechnung anpassen!
        speed = (armorValue + weaponValue) / 2;
    }

    //method to set animation methods suitable for the current weapon
    private void SetAttackAnimations()
    {

        //TODO: set animation motions for current weapon
        switch (weaponType)
        {
            case "sword":
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


    //--------------------------GETTER METHODS-----------------------

    public Transform GetCam()
    {
        return cam;
    }

    public CharacterController GetController()
    {
        return controller;
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public float GetSpeed()
    {
        return speed;
    }
}

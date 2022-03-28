using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
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
    private float health = 1000f;
    private float stamina = 100f;
    private float carryCapacity = 50f;
    private float resistance = 15f;
    private float defense = 50f;
    private float attackPower = 50f;
    private float staminaReg = 5f;
    //action speed
    private float speed = 6f; 

    //equipment
    [SerializeField] private int leftPotions = 5; //TODO: anpassen
    private float armorValue = 0f;
    private float weaponValue = 0f;

    //basic movement
    private float targetAngle = 0f; //camera target angle - where the camera shall be pointing at
    private float angle = 0f; //using targetAngle to get a smoother transition to new angle
    private float smoothTurnTime = 0.1f; //time so the character turns around smoothly
    private float smoothTurnVelocity = 0f; //velocity so the character turns around smoothly

    //sounds
    [SerializeField] private AudioClip[] footstepSounds;    // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip rollSound;           // the sound played when character dodges (rolls).
    private AudioSource audioSource; //current audio source
    private float elapsedTime = 0; //time since last step sound
    private float soundDelay = 0.5f; //delay for sound to play


    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        //set values regarding equipment
        SetEquipmentValues();
        //set attributes with chosen stats
        SetAttributes();
        //determine the speed actions are performed
        SetSpeed();
    }

    // Update is called once per frame
    private void Update()
    {
        // ----------- General Character and Camera Movement ----------- 

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //check if button pressed
        if(direction.magnitude >= 0.1f)
        {
            //camera and player rotation
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //angle to point character at
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnTime); //smoother transition to target angle
            transform.rotation = Quaternion.Euler(0f, angle, 0f); //set character rotation

            //move character in chosen direction
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime); 
        }

        // ----------- Special Movement ----------- 

        Run();

        Roll();

        Attack();

        UsePotion();

    }

    //method to set the equipment values depending on the chosen equipment
    //these values are used to determine the speed of the player's actions
    private void SetEquipmentValues()
    {
        //TODO
        //armorValue
        //weaponValue
    }


    //method to set the attributes depending on the chosen stats and equipment
    private void SetAttributes()
    {
        //TODO: Berechnung anpassen!
        health += vitality * 1.5f;
        stamina += endurance * 1.5f;
        carryCapacity += physStrength * 1.5f;
        resistance += armorValue * 1.5f;
        defense += armorValue * 1.5f;
        attackPower += strength * 1.5f;
        staminaReg += endurance * 1.5f;
    }

    //method to determine speed with which actions are performed (walk, run, attack, roll)
    private void SetSpeed()
    {
        //TODO: Berechnung anpassen!
        speed = speed - (armorValue + weaponValue) / 2;
    }


    //--------------------------SKILLS-----------------------

    private void Run()
    {
        //run in chosen direction
    }

    private void Roll()
    {
        //deactivate skills etc
        //roll animation in chosen direction
    }

    private void Attack()
    {
        //determine weapon type
        //deactivate other skills etc
        //attack combo to the front (adjusted animation and attack speed)
        //heavy attack
    }

    //method to let the player use a potion
    private void UsePotion()
    {
        //check if he/she has a potion left
        if (leftPotions >= 1)
        {
            //deactivate skills etc
            //drink animation
        }
    }

    //player got stunned
    private void Stun()
    {
        //deactivate skills etc
    }

    //method to let the player take damage
    private void TakeDamage()
    {
        //decrease health
        //maybe die
    }

    //player died - game end
    private void Die()
    {
        //player dead - game end
        //UI defeat
    }
}

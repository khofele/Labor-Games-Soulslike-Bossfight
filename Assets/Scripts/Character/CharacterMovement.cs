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

    }


    //--------------------------SETTER METHODS-----------------------

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
        speed = (armorValue + weaponValue) / 2;
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

    public float GetSpeed()
    {
        return speed;
    }
}

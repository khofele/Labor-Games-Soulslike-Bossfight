using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioChar : MonoBehaviour
{
    [SerializeField] private AudioClip[] weaponSounds = null;   //an array of weapon slash sounds that will be randomly selected from - from Weapon.GetWeaponSounds()
    [SerializeField] private AudioClip[] footstepSounds; // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip rollSound; // the sound played when character dodges (rolls).
    [SerializeField] private AudioClip healSound; //the sound played when character uses potion
    [SerializeField] private AudioClip hitSound; //the sound played when character is hit
    [SerializeField] private AudioClip deathSound; //the sound played when character dies
    private AudioSource audioSource = null; //current audio source

    private float elapsedTime = 0; //time since last step sound
    private float soundDelayTime = 0.5f; //delay for sound to play

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRoll()
    {
        audioSource.PlayOneShot(rollSound);
    }

    public void PlayHeal()
    {
        audioSource.PlayOneShot(healSound);
    }

    public void PlayHit()
    {
        audioSource.PlayOneShot(hitSound);
    }

    public void PlayDeath()
    {
        audioSource.PlayOneShot(deathSound);
    }

    //called as animation event
    public void PlayWeapon()
    {
        PlayRandomSound(weaponSounds);
    }

    //called as animation event
    public void PlayFootstep()
    {
        PlayRandomSound(footstepSounds);
    }


    //--------------------USED METHODS------------------

    //method called when a random sound out of a sound array is needed (e.g. when walking)
    private void PlayRandomSound(AudioClip[] array)
    {
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, array.Length);
        audioSource.clip = array[n];
        audioSource.PlayOneShot(audioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        array[n] = array[0];
        array[0] = audioSource.clip;
    }
}

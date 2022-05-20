using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour
{
    [SerializeField] private AudioClip attack1 = null;
    [SerializeField] private AudioClip attack2 = null;
    [SerializeField] private AudioClip attack3 = null;
    [SerializeField] private AudioClip bigTumble = null;
    [SerializeField] private AudioClip death = null;
    [SerializeField] private AudioClip epicScream = null;
    [SerializeField] private AudioClip fireNoise = null;
    [SerializeField] private AudioClip fireAttack = null;
    [SerializeField] private AudioClip fireBreath1 = null;
    [SerializeField] private AudioClip fireBreath2 = null;
    [SerializeField] private AudioClip flying1 = null;
    [SerializeField] private AudioClip flying2 = null;
    [SerializeField] private AudioClip flying3 = null;
    [SerializeField] private AudioClip flyingAttack1 = null;
    [SerializeField] private AudioClip flyingAttack2 = null;
    [SerializeField] private AudioClip flyingDeathBodyHit = null;
    [SerializeField] private AudioClip flyingDie = null;
    [SerializeField] private AudioClip footStep1 = null;
    [SerializeField] private AudioClip footStep2 = null;
    [SerializeField] private AudioClip gotHit1 = null;
    [SerializeField] private AudioClip gotHit2 = null;
    [SerializeField] private AudioClip idleExhale = null;
    [SerializeField] private AudioClip idleBreak = null;
    [SerializeField] private AudioClip walking1 = null;
    [SerializeField] private AudioClip walking2 = null;
    [SerializeField] private AudioClip walking3 = null;
    [SerializeField] private AudioClip wingDown1 = null;
    [SerializeField] private AudioClip wingDown2 = null;
    [SerializeField] private AudioClip wingDown3 = null;
    [SerializeField] private AudioClip wingUp1 = null;
    [SerializeField] private AudioClip wingUp2 = null;
    [SerializeField] private AudioClip wingUp3 = null;
    private AudioSource audioSource = null;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttack1()
    {
        audioSource.PlayOneShot(attack1, 0.7f);
    }

    public void PlayAttack2()
    {
        audioSource.PlayOneShot(attack2, 0.7f);
    }

    public void PlayAttack3()
    {
        audioSource.PlayOneShot(attack3, 0.7f);
    }

    public void PlayBigTumble()
    {
        audioSource.PlayOneShot(bigTumble, 0.7f);
    }

    public void PlayDeath()
    {
        audioSource.PlayOneShot(death, 0.7f);
    }

    public void PlayEpicScream()
    {
        audioSource.PlayOneShot(epicScream, 0.7f);
    }

    public void PlayFireNoise()
    {
        audioSource.PlayOneShot(fireNoise, 0.7f);
    }

    public void PlayFireAttack()
    {
        audioSource.PlayOneShot(fireAttack, 0.7f);
    }

    public void PlayFireBreath1()
    {
        audioSource.PlayOneShot(fireBreath1, 0.7f);
    }

    public void PlayFireBreath2()
    {
        audioSource.PlayOneShot(fireBreath2, 0.7f);
    }

    public void PlayFlying1()
    {
        audioSource.PlayOneShot(flying1, 0.7f);
    }

    public void PlayFlying2()
    {
        audioSource.PlayOneShot(flying2, 0.7f);
    }

    public void PlayFlying3()
    {
        audioSource.PlayOneShot(flying3, 0.7f);
    }

    public void PlayFlyingAttack1()
    {
        audioSource.PlayOneShot(flyingAttack1, 0.7f);
    }

    public void PlayFlyingAttack2()
    {
        audioSource.PlayOneShot(flyingAttack2, 0.7f);
    }

    public void PlayFlyingDeathBodyHit()
    {
        audioSource.PlayOneShot(flyingDeathBodyHit, 0.7f);
    }

    public void PlayFlyingDie()
    {
        audioSource.PlayOneShot(flyingDie, 0.7f);
    }

    public void PlayFootStep1()
    {
        audioSource.PlayOneShot(footStep1, 0.7f);
    }

    public void PlayFootStep2()
    {
        audioSource.PlayOneShot(footStep2, 0.7f);
    }

    public void PlayGotHit1()
    {
        audioSource.PlayOneShot(gotHit1, 0.7f);
    }

    public void PlayGotHit2()
    {
        audioSource.PlayOneShot(gotHit2, 0.7f);
    }

    public void PlayIdleExhale()
    {
        audioSource.PlayOneShot(idleExhale, 0.7f);
    }

    public void PlayIdleBreak()
    {
        audioSource.PlayOneShot(idleBreak, 0.7f);
    }

    public void PlayWalking1()
    {
        audioSource.PlayOneShot(walking1, 0.7f);
    }

    public void PlayWalking2()
    {
        audioSource.PlayOneShot(walking2, 0.7f);
    }

    public void PlayWalking3()
    {
        audioSource.PlayOneShot(walking3, 0.7f);
    }

    public void PlayWingDown1()
    {
        audioSource.PlayOneShot(wingDown1, 0.7f);
    }

    public void PlayWingDown2()
    {
        audioSource.PlayOneShot(wingDown2, 0.7f);
    }

    public void PlayWingDown3()
    {
        audioSource.PlayOneShot(wingDown3, 0.7f);
    }

    public void PlayWingUp1()
    {
        audioSource.PlayOneShot(wingUp1, 0.7f);
    }

    public void PlayWingUp2()
    {
        audioSource.PlayOneShot(wingUp2, 0.7f);
    }

    public void PlayWingUp3()
    {
        audioSource.PlayOneShot(wingUp3, 0.7f);
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}

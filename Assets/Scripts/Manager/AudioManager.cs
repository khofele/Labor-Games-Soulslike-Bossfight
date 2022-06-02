using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip winMessageSound = null;
    [SerializeField] private AudioClip deathMessageSound = null;
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioSource audioSourceBackgroundMusic = null;
    [SerializeField] private GameManager gameManager = null;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWinMessageSound()
    {
        audioSource.PlayOneShot(winMessageSound, 0.7f);
    }

    public void PlayDeathMessageSound()
    {
        audioSource.PlayOneShot(deathMessageSound, 0.7f);
    }

    public void StopBackgroundMusic()
    {
        audioSourceBackgroundMusic.Stop();
    }
}

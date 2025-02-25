using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BossFightAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip bossfight;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
        audioSource.PlayOneShot(bossfight);        
        }
    }
}

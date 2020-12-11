using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Play sound script.
/// Contanins an array of clips, one of which plays on instantiation.
/// Allows for auto destruction of the gameobject.
/// </summary>
public class PlaySound : MonoBehaviour
{
    /// <summary>
    /// List of audio clips
    /// </summary>
    public List<AudioClip> clips;

    /// <summary>
    /// Contains the audio Source component
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Time after instantiation when gameobject is destroyed (seconds)
    /// </summary>
    public float destroyTime = 0f;

    /// <summary>
    /// Current value of the countdown timer
    /// </summary>
    private float timer = 0f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        timer = destroyTime;
        audioSource = GetComponent<AudioSource>();
        if (clips.Count > 0)
        {
            AudioClip clip = clips[Random.Range(0, clips.Count)];
            audioSource.clip = clip;
            audioSource.Play();
        }

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        timer -= Time.deltaTime;
    }
}

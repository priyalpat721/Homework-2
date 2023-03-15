using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioForObject : MonoBehaviour
{
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (_audioSource.clip)
        {
            _audioSource.Play();
        }
    }
}

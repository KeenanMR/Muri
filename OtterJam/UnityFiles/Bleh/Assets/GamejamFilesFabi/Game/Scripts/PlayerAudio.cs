using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerAudio : MonoBehaviour
{
    public AudioSource source;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        source.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        bool moving;

        if (characterController.velocity.x != 0 || characterController.velocity.z != 0)
            moving = true;
        else
            moving = false;

        if (moving && !source.isPlaying)
        {
            source.Play();
        }
        else if(!moving && source.isPlaying)
        {
            source.Pause();
        }
    }

}

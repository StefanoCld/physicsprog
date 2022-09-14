using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingArea : MonoBehaviour
{
    private AudioSource audiosource;

    [Header("Sounds")]
    [SerializeField]
    private AudioClip gripSounds;

    [SerializeField]
    private Rigidbody targetHand;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            audiosource.Play();
            targetHand = other.gameObject.GetComponent<Rigidbody>();
            targetHand.isKinematic = true;
        }
    }
}

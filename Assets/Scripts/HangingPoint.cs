using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingPoint : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            audiosource.Play();
            targetHand = collision.gameObject.GetComponent<Rigidbody>();
            targetHand.isKinematic = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingArea : MonoBehaviour
{
    [SerializeField]
    private Rigidbody targetHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            targetHand = other.gameObject.GetComponent<Rigidbody>();
            targetHand.isKinematic = true;
        }
    }
}

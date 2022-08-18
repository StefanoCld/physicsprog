using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingPoint : MonoBehaviour
{
    [SerializeField]
    private Rigidbody targetHand;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            targetHand = collision.gameObject.GetComponent<Rigidbody>();
            targetHand.isKinematic = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHandController : MonoBehaviour
{
    [Header("Joints")]
    [SerializeField]
    private HingeJoint ArmJoint;
    [SerializeField]
    private HingeJoint ForearmJoint;

    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody Body;
    [SerializeField]
    private Rigidbody Arm;
    [SerializeField]
    private Rigidbody Forearm;
    [SerializeField]
    private Rigidbody Hand;

    [Header("HandCollider")]
    [SerializeField]
    private SphereCollider handCollider;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            JointSpring var = new JointSpring();
            var.spring = 1000f;
            var.targetPosition = -90f;

            ArmJoint.spring = var;
            ForearmJoint.spring = var;
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            JointSpring var = new JointSpring();
            var.spring = 1000f;
            var.targetPosition = 90f;

            ArmJoint.spring = var;
            ForearmJoint.spring = var;

        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            JointSpring var = new JointSpring();
            var.spring = 1000f;
            var.targetPosition = 0f;

            ArmJoint.spring = var;
            ForearmJoint.spring = var;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ArmJoint.useSpring = !ArmJoint.useSpring;
            ForearmJoint.useSpring = !ForearmJoint.useSpring;
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ReleaseHand());
        }
    }

    IEnumerator ReleaseHand()
    {
        Hand.isKinematic = false;
        handCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        handCollider.enabled = true;
    }
}

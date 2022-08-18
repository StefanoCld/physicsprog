using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandController : MonoBehaviour
{
    private bool LwasPlank = false;
    private bool RwasPlank = false;

    [SerializeField]
    private float releaseTime = 1f;

    [Header("Joints")]
    [SerializeField]
    private HingeJoint RArmJoint;
    [SerializeField]
    private HingeJoint RForearmJoint;
    [SerializeField]
    private HingeJoint LArmJoint;
    [SerializeField]
    private HingeJoint LForearmJoint;

    [Header("LRigidbody")]
    [SerializeField]
    private Rigidbody LHand;
    [SerializeField]
    private Rigidbody RHand;

    [Header("HandCollider")]
    [SerializeField]
    private SphereCollider LhandCollider;
    [SerializeField]
    private SphereCollider RhandCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            JointSpring Lvar = new JointSpring();
            Lvar.spring = 1000f; 
            
            if (LwasPlank)
            {
                Lvar.targetPosition = 90;
                LwasPlank = false;
            }
            else
                Lvar.targetPosition = -LArmJoint.spring.targetPosition;

            LArmJoint.spring = Lvar;
            LForearmJoint.spring = Lvar;
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            JointSpring Rvar = new JointSpring();
            Rvar.spring = 1000f;

            if (RwasPlank)
            {
                Rvar.targetPosition = 90;
                RwasPlank = false;
            }
            else
                Rvar.targetPosition = -RArmJoint.spring.targetPosition;

            RArmJoint.spring = Rvar;
            RForearmJoint.spring = Rvar;
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            RwasPlank = true;
            LwasPlank = true;

            JointSpring var = new JointSpring();

            var.spring = 1000f;
            var.targetPosition = 0f;

            RArmJoint.spring = var;
            RForearmJoint.spring = var; 
            LArmJoint.spring = var;
            LForearmJoint.spring = var;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RArmJoint.useSpring = !RArmJoint.useSpring;
            RForearmJoint.useSpring = !RForearmJoint.useSpring;
            LArmJoint.useSpring = !LArmJoint.useSpring;
            LForearmJoint.useSpring = !LForearmJoint.useSpring;
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LReleaseHand());
        }

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(RReleaseHand());
        }
    }

    IEnumerator LReleaseHand()
    {
        LHand.isKinematic = false;
        LhandCollider.enabled = false;
        yield return new WaitForSeconds(releaseTime);
        LhandCollider.enabled = true;
    }
    IEnumerator RReleaseHand()
    {
        RHand.isKinematic = false;
        RhandCollider.enabled = false;
        yield return new WaitForSeconds(releaseTime);
        RhandCollider.enabled = true;
    }
}


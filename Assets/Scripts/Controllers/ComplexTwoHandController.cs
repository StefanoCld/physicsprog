using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexTwoHandController : MonoBehaviour
{
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
        //LeftHand Only
        if (Input.GetKeyDown(KeyCode.Q))
        {
            JointSpring Lvar = new JointSpring();
            Lvar.spring = 1000f;
            Lvar.targetPosition = 90;

            LArmJoint.spring = Lvar;
            LForearmJoint.spring = Lvar;
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            JointSpring Lvar = new JointSpring();
            Lvar.spring = 1000f;
            Lvar.targetPosition = 0;

            LArmJoint.spring = Lvar;
            LForearmJoint.spring = Lvar;
        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            JointSpring Lvar = new JointSpring();
            Lvar.spring = 1000f;
            Lvar.targetPosition = -90;

            LArmJoint.spring = Lvar;
            LForearmJoint.spring = Lvar;
        }

        //RightHand Only
        if (Input.GetKeyDown(KeyCode.E))
        {
            JointSpring Rvar = new JointSpring();
            Rvar.spring = 1000f;
            Rvar.targetPosition = 90;

            RArmJoint.spring = Rvar;
            RForearmJoint.spring = Rvar;
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            JointSpring Rvar = new JointSpring();
            Rvar.spring = 1000f;
            Rvar.targetPosition = 0;

            RArmJoint.spring = Rvar;
            RForearmJoint.spring = Rvar;
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            JointSpring Rvar = new JointSpring();
            Rvar.spring = 1000f;
            Rvar.targetPosition = -90;

            RArmJoint.spring = Rvar;
            RForearmJoint.spring = Rvar;
        }

        //Both Hands

        //Arms Relaxed/Tense
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
        yield return new WaitForSeconds(1f);
        LhandCollider.enabled = true;
    }
    IEnumerator RReleaseHand()
    {
        RHand.isKinematic = false;
        RhandCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        RhandCollider.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandController : MonoBehaviour
{
    private bool LwasPlank = false;
    private bool RwasPlank = false;

    [Header("Audio sources (hands)")]
    [SerializeField]
    private AudioSource leftHandAudioSource;
    [SerializeField]
    private AudioSource rightHandAudioSource;

    [SerializeField]
    [Range(100f, 10000f)]
    private float jointSpringForce = 1250f;

    [SerializeField]
    [Range(0.05f, 2f)]
    private float releaseTime = 0.85f;

    [SerializeField]
    [Range(0f, 90f)]
    private float springTargetPosition = 90f;

    [Header("Joints")]
    [SerializeField]
    private HingeJoint RArmJoint;
    [SerializeField]
    private HingeJoint RForearmJoint;
    [SerializeField]
    private HingeJoint LArmJoint;
    [SerializeField]
    private HingeJoint LForearmJoint;

    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody LHand;
    [SerializeField]
    private Rigidbody RHand;

    [Header("HandColliders")]
    [SerializeField]
    private SphereCollider LhandCollider;
    [SerializeField]
    private SphereCollider RhandCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            JointSpring Lvar = new JointSpring();
            Lvar.spring = jointSpringForce; 
            
            if (LwasPlank)
            {
                Lvar.targetPosition = springTargetPosition;
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
            Rvar.spring = jointSpringForce;

            if (RwasPlank)
            {
                Rvar.targetPosition = springTargetPosition;
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

            var.spring = jointSpringForce;
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
        if (LHand.isKinematic)
        {
            leftHandAudioSource.Play();
        }

        LHand.isKinematic = false;
        LhandCollider.enabled = false;
        yield return new WaitForSeconds(releaseTime);
        LhandCollider.enabled = true;
    }
    IEnumerator RReleaseHand()
    {
        if (RHand.isKinematic) 
        {
            rightHandAudioSource.Play();
        }

        RHand.isKinematic = false;
        RhandCollider.enabled = false;
        yield return new WaitForSeconds(releaseTime);
        RhandCollider.enabled = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody Head;
    [SerializeField]
    private Rigidbody Body;
    [SerializeField]
    private Rigidbody LeftArm;
    [SerializeField]
    private Rigidbody RightArm;
    [SerializeField]
    private Rigidbody LeftLeg;
    [SerializeField]
    private Rigidbody RightLeg;

    [SerializeField]
    private Transform RightLegFoot;
    [SerializeField]
    private Transform LeftLegFoot;

    [SerializeField]
    private float HeadForce;
    [SerializeField]
    private float BodyForce;
    [SerializeField]
    private float LeftArmForce;
    [SerializeField]
    private float RightArmForce;
    [SerializeField]
    private float LeftLegForce;
    [SerializeField]
    private float RightLegForce;


    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RightArm.AddRelativeTorque(-Body.transform.right * RightArmForce, ForceMode.VelocityChange);
            LeftArm.AddRelativeTorque(Body.transform.right * LeftArmForce, ForceMode.VelocityChange);


            //LeftLeg.AddRelativeForce(Body.transform.forward * LeftLegForce, ForceMode.VelocityChange);
            LeftLeg.AddForceAtPosition(Vector3.forward * LeftLegForce, LeftLegFoot.position, ForceMode.VelocityChange);


            Body.AddRelativeForce(Body.transform.up * BodyForce, ForceMode.VelocityChange);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RightArm.AddRelativeTorque(Body.transform.right * RightArmForce, ForceMode.VelocityChange);
            LeftArm.AddRelativeTorque(-Body.transform.right * LeftArmForce, ForceMode.VelocityChange);

            //RightLeg.AddRelativeForce(Body.transform.forward * RightLegForce, ForceMode.VelocityChange);
            RightLeg.AddForceAtPosition(Vector3.forward * RightLegForce, RightLegFoot.position, ForceMode.VelocityChange);

            Body.AddRelativeForce(Body.transform.up * BodyForce, ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        
    }
}

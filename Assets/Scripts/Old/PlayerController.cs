using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float speed;
    public float rotatingSpeed;

    public Rigidbody hips;

    public bool isGrounded = true;
    public bool hasJumped = false;

    public Rigidbody rightLeg;
    public Rigidbody leftLeg;

    void Start()
    {
        hips = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        /*
            hips.AddForce(hips.transform.forward * speed * Input.GetAxis("Vertical"));
            hips.AddForce(hips.transform.right * speed * Input.GetAxis("Horizontal"));

            if (Input.GetMouseButtonDown(0))
            {
                hips.AddForce(hips.transform.up * jumpForce, ForceMode.VelocityChange);
            }
        */

        if(Input.GetAxis("Vertical") > 0)
        {
            //rightLeg.AddForce((hips.transform.forward + hips.transform.up) * speed * Input.GetAxis("Vertical"));
            leftLeg.AddRelativeTorque((hips.transform.right) * rotatingSpeed * Input.GetAxis("Vertical"));
            rightLeg.AddRelativeTorque((-hips.transform.right) * rotatingSpeed * Input.GetAxis("Vertical"));
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            //leftLeg.AddForce((hips.transform.forward + hips.transform.up) * speed * Input.GetAxis("Horizontal"));
            rightLeg.AddRelativeTorque((hips.transform.right) * rotatingSpeed * Input.GetAxis("Horizontal"), ForceMode.VelocityChange);
            leftLeg.AddRelativeTorque((-hips.transform.right) * rotatingSpeed * Input.GetAxis("Horizontal"), ForceMode.VelocityChange);
        }
    }
}

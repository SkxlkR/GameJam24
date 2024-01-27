using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPlayer : MonoBehaviour
{
    public bool isGrabbing;
    public Rigidbody2D rb;

    [SerializeField] GameObject spriteHandOff;
    [SerializeField] GameObject spriteHandOn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            isGrabbing = true;
            spriteHandOff.SetActive(false);
            spriteHandOn.SetActive(true);
        }
        else
        {
            isGrabbing = false;
            spriteHandOff.SetActive(true);
            Destroy(GetComponent<FixedJoint2D>());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGrabbing) 
        {
            Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                FixedJoint2D joint = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                joint.connectedBody = rb;
            }
            else
            {
                FixedJoint2D joint = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class MoveArm : MonoBehaviour
{
    [SerializeField] float speed;
    public bool isGrabbing;
    public Rigidbody2D rb;
    public Rigidbody2D rbPlayer;
    public Camera cam;
    [SerializeField] GameObject Player;
    float x = 0;
    [SerializeField] float speedImpulse;

    bool kolizija = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbPlayer = Player.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
       Vector3 playerPossition = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
       Vector3 diff = playerPossition - transform.position;

        float rotationZ = Mathf.Atan2(diff.x, -diff.y) * Mathf.Rad2Deg;
  
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, speed * Time.fixedDeltaTime));

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isGrabbing = true;
            //spriteHandOff.SetActive(false);
            if (kolizija )
            {

                float playerPossition1 = cam.ScreenToWorldPoint(Input.mousePosition).x;
                float diff1 = playerPossition1 - transform.position.x;
                if (diff1 > 0)
                {
                    rbPlayer.AddForce(new Vector2(-Input.mousePosition.x * 0.03f, 0),ForceMode2D.Impulse);
                }
                else
                {
                    rbPlayer.AddForce(new Vector2(Input.mousePosition.x *0.03f, 0), ForceMode2D.Impulse);

                }
            }

        }
        else
        {
            isGrabbing = false;
            //spriteHandOff.SetActive(true);
            Destroy(GetComponent<FixedJoint2D>());
        }
        x = Input.GetAxisRaw("Mouse X");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        kolizija = true;

        if (isGrabbing)
        {

            Rigidbody2D rb1 = collision.transform.GetComponent<Rigidbody2D>();
            if (rb1 != null)
            {
                //FixedJoint2D joint = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                Debug.Log(cam.ScreenToWorldPoint(Input.mousePosition).x);
                //joint.connectedBody = rb1;
                


            }
            else
            {
                FixedJoint2D joint = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            }
        }

        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        kolizija = false;
    }
}

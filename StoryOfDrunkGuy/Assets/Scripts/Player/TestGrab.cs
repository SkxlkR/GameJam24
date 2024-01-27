using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrab : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    public LayerMask groundLayer;
    public GameObject hand; // Dodajte referencu na ruku igra?a

    private Rigidbody2D rb;
    private bool isGrounded;
    private HingeJoint2D handHinge;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        handHinge = hand.GetComponent<HingeJoint2D>();
        handHinge.useMotor = false; // Onemogu?i motor na po?etku
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        HandleGrabWall();
        FollowMouse();
    }

    

 

    void HandleGrabWall()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit2D hit = Physics2D.Raycast(hand.transform.position, hand.transform.right, 0.1f);

            if (hit.collider != null && hit.collider.CompareTag("Wall"))
            {
                // Aktiviraj HingeJoint2D motor kad je ruka u kontaktu s zidom
                handHinge.useMotor = true;
            }
            else
            {
                // Isklju?i HingeJoint2D motor ako igra? nije u kontaktu s zidom
                handHinge.useMotor = false;
            }
        }
        else
        {
            // Isklju?i HingeJoint2D motor ako igra? nije pritisnuo gumb za "grab"
            handHinge.useMotor = false;
        }
    }

    void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Rotiraj ruku prema mišu
        Vector3 direction = mousePosition - hand.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        hand.transform.rotation = Quaternion.Slerp(hand.transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KljucZaVrata : MonoBehaviour
{
    [SerializeField] GameObject key;
    bool canOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            canOpen = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Door") && canOpen == true) 
        { 
           Destroy(col.gameObject);
        }
    }
}

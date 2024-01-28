using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Kljuc : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interaction;
    public UnityEvent interactAction;
    public bool canOpen = false;
    [SerializeField] GameObject key;

    void Start()
    {
        
    }
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interaction) && canOpen == false)
            {
                canOpen = true;
                Debug.Log("ima pristup");
            }
        }
    }

    public void Destroy2 () 
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInRange = false;
    }

    private void PickUpKey()
    {
        
    }
}

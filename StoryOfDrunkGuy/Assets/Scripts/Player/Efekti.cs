using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efekti : MonoBehaviour
{
    [SerializeField] AudioSource metla;     
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Metla"))
        {
             metla.Play();
        }
    }
}

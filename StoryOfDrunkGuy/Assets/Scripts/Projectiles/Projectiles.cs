using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IspaliMetak : MonoBehaviour
{
    public GameObject metakPrefab;  
    [SerializeField] float brzinaMetka;
    bool isRight = true;

    // Update se poziva svaki frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))  
        {
            Ispali(isRight);
        }
    }

    void Ispali(bool isRight)
    {
        GameObject metak = Instantiate(metakPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rbMetka = metak.GetComponent<Rigidbody2D>();

        
        rbMetka.velocity = transform.right * brzinaMetka;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderZaStartanjePrice : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("ShortWait");
            canvas.SetActive(true);
        }
    }

    public void OnKeyClick()
    {

    }

    IEnumerator ShortWait ()
    {
        yield return new WaitForSeconds(1.75f);
    }
}

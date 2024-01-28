using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] lines;
    [SerializeField] float speed;

    private int index;
    void Start()
    {
        textComp.text = string.Empty;
        StartDiealogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            if(textComp.text == lines[index]) 
            {
                NeXtLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
    }

    void StartDiealogue() 
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    void NeXtLine()
    {
        if (index < lines.Length -1) 
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) 
        {
            textComp.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

}

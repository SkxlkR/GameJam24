using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMeny : MonoBehaviour
{
    [SerializeField] GameObject PauseMen;
    bool isActive = false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isActive)
        {
            PauseMen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isActive == true)
        {
            PauseMen.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ResumeGame ()
    {
        if (Time.timeScale <= 0f && isActive == true)
        {
            PauseMen.SetActive(false);
            Time.timeScale = 1f;

        }
        else
        {
            PauseMen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

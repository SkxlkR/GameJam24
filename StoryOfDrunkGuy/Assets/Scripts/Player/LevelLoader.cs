using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    [SerializeField] float transitionTime;

    void Update()
    {
        StartCoroutine(WaitBetweenSwitches(+1));
    }

    IEnumerator WaitBetweenSwitches (int levelIndex)
    {
        animator.SetTrigger("trig");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}

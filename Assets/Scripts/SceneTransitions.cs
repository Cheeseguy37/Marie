using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;

    // Update is called once per frame
    public void Continue()
    {
        StartCoroutine(AfterDisclaimer());
    }

    public void Play()
    {
        StartCoroutine(StartGame());
    }

    public void Credits()
    {
        StartCoroutine(LoadScene());
    }

    public void Quit()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator QuitGame()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }

    IEnumerator StartGame()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator AfterDisclaimer()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneName);
    }
}

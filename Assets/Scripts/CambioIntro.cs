using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CambiodeEscenas : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("MainMenu");
    }
}

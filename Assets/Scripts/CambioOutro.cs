using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class CambioOutro : MonoBehaviour
{
 void Start()
    {
        StartCoroutine(Outro());
    }

    IEnumerator Outro()
    {
        yield return new WaitForSeconds(65f);
        SceneManager.LoadScene("MainMenu");
    }
}

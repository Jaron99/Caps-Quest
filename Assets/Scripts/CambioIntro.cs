using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Controla el cambio de escenas en Unity después de una introducción.
/// </summary>
public class CambiodeEscenas : MonoBehaviour
{
    /// <summary>
    /// Método que se llama al iniciar el script.
    /// Inicia la corrutina que espera un tiempo antes de cambiar de escena.
    /// </summary>
    void Start()
    {
        StartCoroutine(Intro());
    }

    /// <summary>
    /// Corrutina que espera un tiempo determinado antes de cargar la escena del menú principal.
    /// </summary>
    /// <returns>Retorna un enumerador que permite la espera asincrónica.</returns>
    IEnumerator Intro()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("MainMenu");
    }
}


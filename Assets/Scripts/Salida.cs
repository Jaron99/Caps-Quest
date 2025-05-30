using UnityEngine;

public class Salida : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SalirJuego();
        }

        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            SalirJuego();
        }
    }

    void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo de la Aplicacion");
    }


}

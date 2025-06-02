using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum TipoEjercicio { VyF, Seleccion, Completar }
    public TipoEjercicio tipo;

    public GameObject panelvyf;
    public GameObject panelseleccion;
    public GameObject panelcompletar;

    private bool activado = false;
    private GameObject jugador;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!activado && other.CompareTag("Player"))
        {
            activado = true;

            jugador = other.gameObject;
            jugador.GetComponent<Movimiento>().enabled = false;
     
            switch (tipo)
            {
                case TipoEjercicio.VyF:
                    panelvyf.SetActive(true);
                    break;

                case TipoEjercicio.Seleccion:
                    panelseleccion.SetActive(true);
                    break;

                case TipoEjercicio.Completar:
                    panelcompletar.SetActive(true);
                    break;
            }
        }
    }

    public void CerrarPanel()
    {
        jugador.GetComponent<Movimiento>().enabled = true;
    }
}

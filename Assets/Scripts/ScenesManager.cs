using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    
    public enum escena {Forest,ArventisCity,ArventisCastle,Outro};
    public escena nombreescena;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nombreescena.ToString());
        }
    }
    public void EscenaBosque()
    {
        SceneManager.LoadScene("Forest");
    }

    public void EscenaCuidad()
    {
        SceneManager.LoadScene("ArventisCity");
    }
    
    public void EscenaCastillo()
    {
        SceneManager.LoadScene("ArventisCastle");
    }
}

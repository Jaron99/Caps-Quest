using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
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

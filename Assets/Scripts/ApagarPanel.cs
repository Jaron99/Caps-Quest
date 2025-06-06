using UnityEngine;

public class ApagarPanel : MonoBehaviour
{
    private float delay = 4f;

    void OnEnable()
    {
        Invoke("HidePanel", delay);
    }

    void HidePanel()
    {
        gameObject.SetActive(false);
    }
}

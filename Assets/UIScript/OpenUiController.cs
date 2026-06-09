using UnityEngine;

public class OpenUiController : MonoBehaviour
{
    public GameObject uiToOpen;
    public void OpenUI()
    {
        if (uiToOpen != null)
        {
            uiToOpen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No UI assigned to open. Please assign a UI GameObject in the inspector.");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

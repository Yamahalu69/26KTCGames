using UnityEngine;

public class CloseUiController : MonoBehaviour
{
    public GameObject uiToClose;
    public void CloseUI()
    {
        if (uiToClose != null)
        {
            uiToClose.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No UI assigned to close. Please assign a UI GameObject in the inspector.");
        }
    }
}

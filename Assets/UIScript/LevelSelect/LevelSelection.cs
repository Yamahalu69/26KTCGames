using UnityEngine;
using UnityEngine.UI;
public class LevelSelection : MonoBehaviour
{
    public LevelClass[] levels;
    public GameObject levelButtonPrefab;
    public Transform levelButtonContainer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach (LevelClass level in levels)
        {
            GameObject button = Instantiate(levelButtonPrefab, levelButtonContainer);
            button.GetComponentInChildren<Text>().text = level.levelName;

            if (level.isLocked)
            {
                button.GetComponent<Button>().interactable = false;
            }
            else
            {
                if(level.isCompleted)
                {
                    // Optionally, change the button's appearance to indicate completion
                    button.transform.Find("Check").GetComponent<Image>().enabled = true; // Example: change color to green
                }
                
                button.GetComponent<Button>().onClick.AddListener(() => {
                    SceneLoader loader = button.GetComponent<SceneLoader>();
                    if (loader != null)
                    {
                        loader.LoadScene(level.sceneName);
                    }
                });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

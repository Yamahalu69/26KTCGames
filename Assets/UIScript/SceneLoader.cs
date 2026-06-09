using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        if(IsSceneInBuildSettings(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' is not in the Build Settings. Please add it to load.\nシーンをビルドに入れてくれ.もしもう入れたら、チェックお願いします。");
        }
    }
    public void LoadScene(string name)
    {
        if(IsSceneInBuildSettings(name))
        {
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.LogError($"Scene '{name}' is not in the Build Settings. Please add it to load.\nシーンをビルドに入れてくれ.もしもう入れたら、チェックお願いします。");
        }
    
    }

    public static bool IsSceneInBuildSettings(string sceneName)
    {
        #if UNITY_EDITOR
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.path.Contains(sceneName))
            {
                // Returns true if it is in the list AND the checkbox is checked
                return scene.enabled; 
            }
        }
        #endif
        return false;
    }
}

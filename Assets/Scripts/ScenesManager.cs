
using UnityEngine;
using UnityEngine.SceneManagement; 
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScenesManager : MonoBehaviour
{
   public static ScenesManager SM {get; private set;}


    private string playerName;
    private int score;

    private void Awake()
    {
        if (SM != null)
        {
            Destroy(gameObject);
            return; 
        }
        SM = this;
        DontDestroyOnLoad(gameObject);
    }

public void LoadScene(int sceneID) => SceneManager.LoadScene(sceneID);

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}

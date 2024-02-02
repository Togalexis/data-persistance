
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager GM {get; private set;}

    public InputField InputName;

    private string playerName;
    private int highScore;

    public void SetName() => playerName = InputName.text;

    public string GetName()
    {
        return playerName;
    }

    public void SetHighScore(int score) => highScore = score;

    public int GetHighScore()
    {
        return highScore;
    }




    private void Awake()
    {
        if (GM != null)
        {
            Destroy(gameObject);
            return; 
        }
        GM = this;
        DontDestroyOnLoad(gameObject);
    }
}

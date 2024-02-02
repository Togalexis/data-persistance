
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick brickPrefab;
    public int lineCount = 6;
    public Rigidbody ball;

    public Text scoreText;
    public Text HighScoreText;
    public GameObject gameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"{GameManager.GM.GetName()} Score : {m_Points}";
        HighScoreText.text = $"Highscore : {GameManager.GM.GetName()} : {GameManager.GM.GetHighScore()}";
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < lineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(brickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                ball.transform.SetParent(null);
                ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ScenesManager.SM.LoadScene(1);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        scoreText.text = $"{GameManager.GM.GetName()} : Score : {m_Points}";

        if (m_Points > GameManager.GM.GetHighScore()) 
        {
            GameManager.GM.SetHighScore(m_Points);
            //display high score at top of screen with the name of who made that high score
            HighScoreText.text = $"Highscore : {GameManager.GM.GetName()} : {m_Points}";
        }
        else return;
    }
    public void GameOver()
    {
        m_GameOver = true;
        gameOverText.SetActive(true);
    }
    
}

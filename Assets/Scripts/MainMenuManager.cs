
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager instance;
    public static MainMenuManager Instance
    {
        get { return instance; }
    }
    private GameObject playBtn;
    private GameObject scoreTxt;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        scoreTxt = GameObject.FindGameObjectWithTag("ScoreTxt");
        playBtn = GameObject.FindGameObjectWithTag("PlayBtn");
        
        if (GameManager.Instance.GameOver)
        {
            Debug.Log("GameOver");
            playBtn.GetComponentInChildren<Text>().text = "PLAY AGAIN";
            scoreTxt.SetActive(true);
            scoreTxt.GetComponent<Text>().text += "\n"+ ScoreManager.Instance.Score;
        }
        else
        {
            scoreTxt.SetActive(false);
        }
    }
    public void Play()
    {
        ScoreManager.Instance.Score = 0;
        SceneManager.LoadScene(Values.MainSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

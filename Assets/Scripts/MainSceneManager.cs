using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public void Start()
    {
        if (Camera.main == null)
            Debug.Log("no camera");
        GameManager.Instance.OnSceneLoaded(Camera.main);
    }
}


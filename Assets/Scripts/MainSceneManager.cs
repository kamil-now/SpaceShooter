using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    private void Start()
    {
        if (Camera.main == null)
            Debug.Log("no camera");
        GameManager.Instance.OnSceneLoaded(Camera.main);
    }
}


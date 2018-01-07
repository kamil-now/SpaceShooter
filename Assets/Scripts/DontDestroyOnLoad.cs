using UnityEngine;
namespace Assets.Scripts
{
    public class DontDestroyOnLoad: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

using UnityEngine;
namespace Assets.Scripts
{
    public class DDOL: MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

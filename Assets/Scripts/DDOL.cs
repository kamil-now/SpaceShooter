using UnityEngine;
namespace Assets.Scripts
{
    public class DDOL: MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

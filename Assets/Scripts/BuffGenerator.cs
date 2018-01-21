using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffGenerator : MonoBehaviour
{
    #region Singleton
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion
    #region Variables
    [SerializeField]
    private List<GameObject> buffs;
    #endregion
    #region Functions
    public void InstantiateBuff(Vector3 spawnPosition)
    {
        if (Random.value <= 0.1f)
        {
            Instantiate(buffs[Random.Range(0,buffs.Count)], spawnPosition, Quaternion.identity);
        }
    }
    #endregion
}

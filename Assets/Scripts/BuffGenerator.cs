using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BuffGenerator : MonoBehaviour
{
    #region Singleton
    private static BuffGenerator instance;
    public static BuffGenerator Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    #region Variables
    [SerializeField]
    private List<GameObject> buffs;
    [SerializeField]
    private float chanceForBuff = 0.1f;
    #endregion
    #region Functions
    public void InstantiateBuff(Vector3 spawnPosition)
    {
        if (Random.value <= chanceForBuff)
        {
            Instantiate(buffs[Random.Range(0,buffs.Count)], spawnPosition, Quaternion.identity);
        }
    }
    #endregion
}

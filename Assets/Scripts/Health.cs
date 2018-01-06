using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private GameObject hpObjectPrefab;
    [SerializeField]
    private GameObject hpTextPrefab;

    [SerializeField]
    private bool hpTextOn;
    [SerializeField]
    private bool hpObjectsOn;
    [SerializeField]
    private int hp;
    private List<HpObject> hpObjects;
    private GameObject hpText;
    private float timeCounter;
    //temp
    private GameObject txt;
    //
    public int Hp
    {
        get
        {
            return hp;
        }
    }

    public void Awake()
    {
        hpObjects = new List<HpObject>();
    }
    public void Start()
    {
        hp = Constants.InitPlayerHp;
        //temp
        txt = GameObject.Find("HP");
        //
        if (hpTextOn)
            //InitHpText();

            if (hpObjectsOn)
                InitHpObjects();
    }
    public void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
        else
        {
            if (hpTextOn)
                UpdateHpText();

            if (hpObjectsOn)
                UpdateHpObjects();
        }
    }
    public void OnCollisionEnter()
    {
        hp--;
    }
    private void UpdateHpText()
    {
        //temp
        txt.GetComponent<Text>().text = hp.ToString();
        //
        //hpText.GetComponent<Text>().text = hp.ToString();
        //hpText.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }
    private void UpdateHpObjects()
    {
        timeCounter += Time.deltaTime * Constants.DefaultHpObjectSpeed;
        foreach (HpObject item in hpObjects)
        {
            item.Update(hp, timeCounter);
        }
    }
    private void InitHpText()
    {
        if (hpTextPrefab != null)
            hpText = Instantiate(hpTextPrefab);
        else
            hpText = Instantiate(DefaultPrefabs.Instance.DefaultHpText);
        //TODO
        hpText.transform.SetParent(GameObject.Find("Canvas").transform);

    }
    private void InitHpObjects()
    {
        for (int i = 1; i <= hp; ++i)
        {
            GameObject obj = Instantiate(hpObjectPrefab, this.gameObject.transform);

            obj.name = i.ToString();
            float theta = (float)((2 * Math.PI / hp) * i);
            var x = Mathf.Cos(theta) * 2;
            var z = Mathf.Sin(theta) * 2;
            float y = this.gameObject.transform.position.y;

            obj.transform.position = new Vector3(x, y, z);
            hpObjects.Add(new HpObject(obj));
        }
    }
    private void DestroyHpObjects()
    {
        //TODO object pool
        foreach (HpObject item in hpObjects)
        {
            Destroy(item.GameObject);
        }
        hpObjects.Clear();
    }

}

//public class EnemyHealth : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject hpTextPrefab;
//    private GameObject hpText;
//    // Use this for initialization
//    void Start()
//    {
//        hpText = Instantiate(hpTextPrefab);
//        hpText.transform.parent = GameObject.Find("Canvas").transform;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        hpText.transform.position = Camera.main.WorldToScreenPoint(transform.position);
//    }

//    private void OnBecameInvisible()
//    {
//        Destroy(hpText);
//        Destroy(gameObject);
//    }
//}

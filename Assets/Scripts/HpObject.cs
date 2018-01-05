using UnityEngine;

public class HpObject
{
    private float _radius;
    private GameObject _gameObject;

    public GameObject GameObject
    {
        get
        {
            return _gameObject;
        }
    }
    
    public HpObject(GameObject gameObject)
    {
        _gameObject = gameObject;
        _radius = _gameObject.GetComponent<SphereCollider>().radius;
    }
    public void Update(int hp, float timeCounter)
    {
        float theta = (float)((2 * Mathf.PI / hp) * int.Parse(_gameObject.name));
        var x = Mathf.Cos(theta + timeCounter) * _radius + _gameObject.transform.position.x;
        var z = Mathf.Sin(theta + timeCounter) * _radius + _gameObject.transform.position.z;
        float y = _gameObject.transform.position.y;


        _gameObject.transform.position = new Vector3(x, y, z);
    }
}


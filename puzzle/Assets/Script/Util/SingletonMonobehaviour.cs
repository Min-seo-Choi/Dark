using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonobehaviour<T> : MonoBehaviour where T : SingletonMonobehaviour<T>
{
    static public T Instance { get; private set; }

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = (T)this;
            OnAwake();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == (T)this)
            OnStart();
    }
}

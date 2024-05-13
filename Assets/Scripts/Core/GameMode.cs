using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        FindObjectWithCompanent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FindObjectWithCompanent<T>() where T : Component
    {
        foreach (var go in GameObject.FindObjectsOfType<T>())
        {
            //Debug.LogFormat(go.gameObject.name);
        }

        //yield return null;
    }
}

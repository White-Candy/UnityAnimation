using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public string animStateName;
    public List<AnimStruct> AnimClips;
    int clipIdx = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (clipIdx < AnimClips.Count)
            {
                StartCoroutine(AnimController.Instance.AnimClipPlay(this.gameObject, animStateName, AnimClips[clipIdx++],
                                new Tuple<string, bool>("play", true)));
            }
        }
    }
}

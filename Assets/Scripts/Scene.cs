using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : BaseScene
{
    private CoroutineControl control;

    void Start()
    {

    }

    void Update()
    {
        if (!string.IsNullOrEmpty(Input.inputString))
        {
            InputKeyPlayValAnim(Input.inputString);
        }
    }

    public void InputKeyPlayValAnim(string key)
    {

        int idx;
        if (int.TryParse(key, out idx))
        {
            if (idx < AnimClips.Count)
            {
                CoroutineExtension.GoCoroutine(this,
                        AnimController.Instance.AnimClipPlay(this, idx, TargetCameraName, new Tuple<string, bool>("play", true)));
            }
        }
        else
        {
            if (key == "p") AnimController.Instance.ControlAnimState(this);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[System.Serializable]
public class AnimStruct
{
    public string name;
    public float f_start;
    public float f_end;
}

public class AnimController : MonoBehaviour
{
    private static AnimController m_instance;
    private static bool m_PuaseOrPlay = false; // False can Pause, Ture can Play
    public static AnimController Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new AnimController();
            }
            return m_instance;
        }
    }

    public IEnumerator AnimClipPlay(BaseScene obj, int idx, string target, params Tuple<string, bool>[] param)
    {
        Animator animtor = obj?.GetComponent<Animator>(); //获得组件Animator
        foreach (var p in param)
        {
            animtor.SetBool(p.Item1, p.Item2);  // 修改 Animtor状态机的参数
        }

        yield return new WaitForSeconds(0.1f);

        if (idx >= obj.AnimClips.Count) yield break;
        string stateName = obj.animStateName;
        List<AnimStruct> Clips = obj.AnimClips;
        AnimStruct clip = Clips[idx];
        Camera[] arrCameras = obj?.GetComponentsInChildren<Camera>();
        Camera animCam = null;
        foreach(var c in arrCameras)
        {
           if (c.name == target)
            {
                animCam = c;
                break;
            }
        }

        if (clip != null && animtor != null && animCam != null)
        {
            //float frameRate = animtor.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate;

            //Debug.Log(animCam.name);
            animCam.depth = 2;
            float start = clip.f_start * (1 / 24.0f);
            float end = clip.f_end * (1 / 24.0f);
            float animTime = (end - start); // f_start 和 f_end 两个帧时间间隔

            animtor.PlayInFixedTime(stateName, 0, start); // 从 start时间开始播放动画
            animtor.speed = 1.0f;

            yield return new WaitForSeconds(animTime);

            // 播放完毕关闭动画
            animCam.depth = 0;
            animtor.speed = 0f;
            foreach (var p in param)
            {
                animtor.SetBool(p.Item1, !p.Item2);
            }
        }
        yield return null;
    }

    public void ControlAnimState(BaseScene obj)
    {
        Animator animtor = obj?.GetComponent<Animator>(); //获得组件Animator
        animtor.speed = m_PuaseOrPlay == true ? 1.0f : 0f;
        m_PuaseOrPlay = !m_PuaseOrPlay;
    }
}

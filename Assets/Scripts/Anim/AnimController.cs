using System;
using System.Collections;
using System.Collections.Generic;
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

    public IEnumerator AnimClipPlay(GameObject obj, string stateName, AnimStruct clip, params Tuple<string, bool>[] param)
    {
        Animator animtor = obj?.GetComponent<Animator>(); //获得组件Animator

        foreach (var p in param)
        {
            animtor.SetBool(p.Item1, p.Item2);  // 修改 Animtor状态机的参数
        }

        yield return new WaitForSeconds(0.01f);

        if (clip != null && animtor != null)
        {
            float frameRate = animtor.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate;
            float start = clip.f_start * (1 / frameRate);
            float end = clip.f_end * (1 / frameRate);
            float animTime = (end - start); // f_start 和 f_end 两个帧时间间隔

            animtor.PlayInFixedTime(stateName, 0, start); // 从 start时间开始播放动画
            animtor.speed = 1.0f;

            yield return new WaitForSeconds(animTime);

            // 播放完毕关闭动画
            animtor.speed = 0f;
            foreach (var p in param)
            {
                animtor.SetBool(p.Item1, !p.Item2);
            }
        }
        yield return null;
    }
}

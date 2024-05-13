using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineControl
{
    private Coroutine m_coroutine;
    private MonoBehaviour m_mono;
    private IEnumerator m_routine;

    public IEnumerator Routine
    {
        get { return m_routine; }
        set { m_routine = value; }
    }

    public CoroutineControl(MonoBehaviour mono, IEnumerator routine)
    {
        this.m_mono = mono;
        this.m_routine = routine;
    }

    public void Start()
    {
        this.m_coroutine = m_mono.StartCoroutine(m_routine);
    }

    public void Stop()
    {
        if (this.m_coroutine != null)
        {
            this.m_mono.StopCoroutine(this.m_coroutine);
        }
    }
}

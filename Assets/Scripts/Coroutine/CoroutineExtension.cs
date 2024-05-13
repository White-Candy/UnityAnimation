using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoroutineExtension
{
    private static CoroutineControl controller;

    //扩展mono开启协程方法
    public static void GoCoroutine(this MonoBehaviour mono, IEnumerator runner)
    {
        if (controller == null)
        {
            controller = new CoroutineControl(mono, runner);
        }
        else
        {
            controller.Stop();
            controller.Routine = runner;
        }

        controller.Start();
    }
}

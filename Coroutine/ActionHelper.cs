﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Helpers.Routine
{
    public class ActionHelper : MonoBehaviour
    {

        private static MonoBehaviour monoBehaviour = null;
        public static MonoBehaviour mono {
            get {
                if (!monoBehaviour)
                    monoBehaviour = (new UnityEngine.GameObject("ActionHelper_Routiner", typeof(ActionHelper))).GetComponent<ActionHelper>();

                return monoBehaviour;
            }
        }

        public static void DelayFrame(UnityAction action)
        {
            mono.StartCoroutine(NextFrameRoutine(action));
        }

        public static void Delay(float delay, UnityAction action)
        {
            mono.StartCoroutine(TimeRoutine(delay, action));
        }

        private static IEnumerator NextFrameRoutine(UnityAction action)
        {
            yield return null;

            if (action != null)
                action.Invoke();
        }

        private static IEnumerator TimeRoutine(float delay, UnityAction action)
        {
            yield return new WaitForSeconds(Time.timeScale * delay);

            if (action != null)
                action.Invoke();
        }
    }
}
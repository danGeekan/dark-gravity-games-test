using UnityEngine;
using System.Collections;

public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
{
    public Coroutine StartCustomCoroutine(IEnumerator routine) => StartCoroutine(routine);
    public void StopCustomCoroutine(Coroutine routine) => StopCoroutine(routine);
}
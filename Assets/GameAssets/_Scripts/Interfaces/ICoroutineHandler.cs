using System.Collections;
using UnityEngine;

public interface ICoroutineHandler
{
    Coroutine StartCoroutine(IEnumerator method);
    void StopCoroutine(Coroutine routine);
    void StopAllCoroutines();
}
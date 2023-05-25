using System.Collections;
using UnityEngine;

public interface ICourutineRunner
{
    Coroutine StartCoroutine(IEnumerator coroutine);
}

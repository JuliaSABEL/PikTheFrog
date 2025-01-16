using UnityEngine;
using System.Collections;
using System;


public class PlayerEffectController : MonoBehaviour, IPlayerEffect
{
    [SerializeField] private Animator effectAnimator;


    public void ApplyEffect(string effectName, float duration, Action onEffectEnd = null)
    {
        effectAnimator.SetBool(effectName, true);
        StartCoroutine(DisableEffect(effectName, duration, onEffectEnd));
    }


    private IEnumerator DisableEffect(string effectName, float duration, Action onEffectEnd)
    {
        yield return new WaitForSeconds(duration);
        effectAnimator.SetBool(effectName, false);

        onEffectEnd?.Invoke();
    }
}

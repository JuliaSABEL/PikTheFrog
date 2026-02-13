using UnityEngine;
using System.Collections;
using System;


public class AnimatorEffect : IEffect
{
    private Animator _effectAnimator;
    private readonly MonoBehaviour _coroutineRunner;


    public AnimatorEffect(Animator animator, MonoBehaviour runner)
    {
        _effectAnimator = animator;
        _coroutineRunner = runner;
    }

    public void ApplyEffect(string effectName, float duration, Action onEffectEnd = null)
    {
        _effectAnimator.SetBool(effectName, true);
        _coroutineRunner.StartCoroutine(DisableEffect(effectName, duration, onEffectEnd));
    }


    private IEnumerator DisableEffect(string effectName, float duration, Action onEffectEnd)
    {
        yield return new WaitForSeconds(duration);
        _effectAnimator.SetBool(effectName, false);

        onEffectEnd?.Invoke();
    }
}

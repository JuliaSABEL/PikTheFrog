using System;


public interface IEffect
{
    void ApplyEffect(string effectName, float duration, Action onEffectEnd = null);
}

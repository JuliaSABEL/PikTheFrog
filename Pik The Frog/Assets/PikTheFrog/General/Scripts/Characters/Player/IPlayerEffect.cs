using System;


public interface IPlayerEffect
{
    void ApplyEffect(string effectName, float duration, Action onEffectEnd = null);
}

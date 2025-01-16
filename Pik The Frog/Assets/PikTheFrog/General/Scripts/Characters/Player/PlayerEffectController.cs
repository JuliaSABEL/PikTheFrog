using UnityEngine;


public class PlayerEffectController : IPlayerEffect
{
    [SerializeField] private Animator effectAnimator;


    public void ApplyEffect()
    {
        effectAnimator.SetTrigger("effect");
    }
}

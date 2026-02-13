using UnityEngine;


[CreateAssetMenu(fileName = "NewEffectData", menuName = "SO/Effects/EffectData")]
public class EffectData : ScriptableObject
{
    [SerializeField] private string _transName;
    [SerializeField] private float _duration;
    
    public string transName => _transName;
    public float duration => _duration;
}

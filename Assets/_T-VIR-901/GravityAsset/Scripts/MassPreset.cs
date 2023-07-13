using UnityEngine;

[CreateAssetMenu]
public class MassPreset : ScriptableObject
{

    public enum presetTypeChoices
    {
        attractor,
        satellite
    }

    public string massName;
    public float massValue;
    public presetTypeChoices presetType;
    public float sphereTilling;
    public Color color;
}

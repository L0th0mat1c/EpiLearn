using UnityEngine;

public abstract class Info : ScriptableObject
{
    [SerializeField] public string Titre;
    [TextArea(10, 20)] public string Description;

    public Info(string _titre, string _description)
    {
        Titre = _titre;
        Description = _description;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Planet info", menuName = "EpileARn/Info/Planet", order = 1)]
public class PlanetInfo : Info
{
    [SerializeField] public int Rayon;
    [SerializeField] public float Inclinaison;
    [SerializeField] public PlanetType Type;

    public PlanetInfo(string _titre, string _description, int _rayon, PlanetType _type, float _inclinaison = 0) : base(_titre, _description)
    {
        Rayon = _rayon;
        Type = _type;
        Inclinaison = _inclinaison;
    }

    public string GetTypeInString()
    {
        string result = "";
        switch (Type)
        {
            case PlanetType.Tellurique:
                result = "Téllurique";
                break;
            case PlanetType.Gazeuse:
                result = "Gazeuse";
                break;
        }
        return result;
    }
}

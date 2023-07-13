using UnityEngine;

[CreateAssetMenu(fileName = "Star info", menuName = "EpileARn/Info/Star", order = 2)]
public class StarInfo : Info
{
    [SerializeField] public int Rayon;
    [SerializeField] public float Inclinaison;
    [SerializeField] public StarType Type;

    public StarInfo(string _titre, string _description, int _rayon, StarType _type, float _inclinaison = 0) : base(_titre, _description)
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
            case StarType.NaineBrune:
                result = "Naine brune";
                break;
            case StarType.NaineRouge:
                result = "Naine rouge";
                break;
            case StarType.NaineJaune:
                result = "Naine jaune";
                break;
            case StarType.GeanteRouge:
                result = "Géante rouge";
                break;
            case StarType.NaineBlanche:
                result = "Naine blanche";
                break;
            case StarType.NaineNoire:
                result = "Naine noire";
                break;
            case StarType.GeanteBleu:
                result = "Géante bleu";
                break;
            case StarType.SupergeanteRouge:
                result = "Super géante rouge";
                break;
        }
        return result;
    }
}

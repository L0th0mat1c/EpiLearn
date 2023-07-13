using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelPlanetInfo : MonoBehaviour
{
    public TextMeshProUGUI TitreTxt;
    public TextMeshProUGUI DescriptionTxt;
    public TextMeshProUGUI TailleTxt;
    public TextMeshProUGUI TypeTxt;

    public void SetInfo(Info info)
    {
        if(info == null)
        {
            ClearInfo();
            return;
        }

        switch (info)
        {
            case PlanetInfo planetInfo:
                fillPlanetInfo(planetInfo);
                break;
            case StarInfo starInfo:
                fillStarInfo(starInfo);
                break;
        }
    }

    public void ClearInfo()
    {
        gameObject.SetActive(false);
        TitreTxt.text = "";
        DescriptionTxt.text = "";
        TailleTxt.text = "0 km";
        TypeTxt.text = "";
    }

    private void fillInfo(Info info)
    {
        gameObject.SetActive(true);
        TitreTxt.text = info.Titre;
        DescriptionTxt.text = info.Description;
    }

    private void fillPlanetInfo(PlanetInfo planetInfo)
    {
        fillInfo(planetInfo);
        TailleTxt.text = planetInfo.Rayon.ToString() + " km";
        TypeTxt.text = planetInfo.Type.ToString();
    }

    private void fillStarInfo(StarInfo starInfo)
    {
        fillInfo(starInfo);
        TailleTxt.text = starInfo.Rayon.ToString() + " km";
        TypeTxt.text = starInfo.Type.ToString();
    }
}

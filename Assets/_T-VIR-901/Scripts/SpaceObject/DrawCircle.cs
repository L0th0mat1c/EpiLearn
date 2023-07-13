using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    private LineRenderer CircleRenderer;
    private int numberPoints = 100;
    private float radius = 1;

    private void Start()
    {
        if(gameObject.transform.parent.TryGetComponent(out CircleRenderer))
        {
            //On initialise le LineRenderer.
            CircleRenderer.positionCount = numberPoints;
            CircleRenderer.startWidth = 0.01f;
            CircleRenderer.endWidth = 0.01f;
            CircleRenderer.useWorldSpace = false;
            CircleRenderer.startColor = new Color(1, 1, 1);
            CircleRenderer.endColor = new Color(1, 1, 1);
            CircleRenderer.material.SetColor("_Color", new Color(1, 1, 1));
            CircleRenderer.material.SetColor("_EmissionColor", new Color(1, 1, 1));


            //On fait les calcul pour créer le cercle.
            radius = CalculDistance(gameObject.transform.parent.transform.position, gameObject.transform.position);
            CreateCircle();
        }
    }

    public void showCircle() {
        CircleRenderer.enabled = true;
    }
    public void hideCircle() {
        CircleRenderer.enabled = false;
    }

    //Calcul la position du cercle
    private void CreateCircle()
    {
        for(int i = 0; i< numberPoints; i++)
        {
            float circumferenceProgress = (float)i/(numberPoints - 1);
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xTemp = Mathf.Cos(currentRadian);
            float zTemp = Mathf.Sin(currentRadian);

            float x = xTemp * radius;
            float z = zTemp * radius;

            Vector3 currentPosition = new Vector3(x, 0, z);

            CircleRenderer.SetPosition(i, currentPosition);
        }
    }

    //Donne la distance entre 2 vector3
    private float CalculDistance(Vector3 goActuel, Vector3 goParent)
    {
        return Mathf.Sqrt(Mathf.Pow(goParent.x - goActuel.x, 2) + Mathf.Pow(goParent.z - goActuel.z,2));
    }
}


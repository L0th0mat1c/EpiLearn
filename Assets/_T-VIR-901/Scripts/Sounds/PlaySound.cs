using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    public AudioSource soundPlayer;
    public AudioSource soundEnterDetail;
    public AudioSource soundExitDetail;

    public void playThisSoundPlayer()
    {
        soundPlayer.Play();
    }

    public void stopThisSoundPlayer()
    {
        soundPlayer.Stop();
    }

    public void playThisSoundEnterDetail()
    {
        soundEnterDetail.Play();
    }

    public void playThisSoundExitDetail()
    {
        soundExitDetail.Play();
    }
}

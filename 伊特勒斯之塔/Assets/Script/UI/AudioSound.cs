using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSound : MonoBehaviour
{
    public AudioSource audiosource;

    public void play()
    {
        audiosource.Play();
    }


}

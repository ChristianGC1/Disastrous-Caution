using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip Blaster, DamageTwo, Missile;
    static AudioSource audioSrc;

    public AudioSource explosionS;
    public AudioClip explosionC;

    void Start()
    {
        Blaster = Resources.Load<AudioClip>("Blaster");
        DamageTwo = Resources.Load<AudioClip>("DamageTwo");
        Missile = Resources.Load<AudioClip>("Missile");

        audioSrc = GetComponent<AudioSource>();
    }

    //public void Explosion()
    //{
    //    Debug.Log("Explosion sound coming!");
    //    explosionS.PlayOneShot(explosionC);
    //    Debug.Log("Explosion sound 1 happened!");
    //    explosionS.GetComponent<AudioSource>().Play();
    //    Debug.Log("Explosion sound 2 happened!");
    //}

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Blaster":
                audioSrc.PlayOneShot(Blaster);
                break;
            case "DamageTwo":
                audioSrc.PlayOneShot(DamageTwo);
                break;
            case "Missile":
                audioSrc.PlayOneShot(Missile);
                break;
        }
    }
}

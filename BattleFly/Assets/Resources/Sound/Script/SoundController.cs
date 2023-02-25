using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum soundsGame
{
    soundGunShoot,
    soundLaserShoot,
    soundRocket,
    soundExplode,
    soundExplode1,
    soundWarning,
    soundButtonClick,
    soundItem
       
}
public class SoundController : MonoBehaviour
{
  
    public AudioClip soundGunShoot;
    public AudioClip soundLaserShoot;
    public AudioClip soundRocket;
    public AudioClip soundExplode;
    public AudioClip soundExplode1;
    public AudioClip soundWarning;
    public AudioClip soundButtonClick;
    public AudioClip soundItem;

    public static SoundController instance;

        // Use this for initialization
        void Start()
        {
            instance = this;
        }
        public static void PlaySound(soundsGame currentSound)
        {
            switch (currentSound)
            {
            case soundsGame.soundGunShoot:
                {
                   instance.GetComponent<AudioSource>().PlayOneShot(instance.soundGunShoot);
                }
                break;
            case soundsGame.soundLaserShoot:
                {
                   instance.GetComponent<AudioSource>().PlayOneShot(instance.soundLaserShoot);
                }
                break;
            case soundsGame.soundRocket:
                {
                   instance.GetComponent<AudioSource>().PlayOneShot(instance.soundRocket);
                }
                break;
            case soundsGame.soundExplode:
                {
                   instance.GetComponent<AudioSource>().PlayOneShot(instance.soundExplode);
                }
                 break;
            case soundsGame.soundExplode1:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundExplode1);
                }
                break;
            case soundsGame.soundWarning:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundWarning);
                }
                break;
            case soundsGame.soundButtonClick:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundButtonClick, 1.0f);
                }
                break;
            case soundsGame.soundItem:
                {
                    instance.GetComponent<AudioSource>().PlayOneShot(instance.soundItem);
                }
                break;

            default:  break;
            }
        }

}

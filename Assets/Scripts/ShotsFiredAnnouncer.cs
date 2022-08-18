using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChrisGuz
{
    public class ShotsFiredAnnouncer : MonoBehaviour
    {
        // This class will announce the event of "Fired A Shot" when a tank shoots
        // An event that can be announced
        // To announce the event

        //public delegate void ShotFiredAction();
        //public static ShotFiredAction OnShotFired;

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Mouse0))
            //{
            //    // If something is subscribed to our event
            //    // Announce Event
            //    if(OnShotFired != null)
            //    {
            //        OnShotFired();
            //    }
            //}
        }

        //public static void AnnounceShots()
        //{
        //    // If something is subscribed to our event
        //    // Announce Event
        //    if (OnShotFired != null)
        //    {
        //        OnShotFired();
        //    }
        //}
    }
}

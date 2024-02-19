using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Note: Make A TAG Not Layer Called "Buttons" And If You Dont Already Make A Tag Called "MainCamera"
        // Put The Tag Called Buttons On Your Left And RightHand Controller
        // Put The Tag Called MainCamera On Your Camera

        // Make A Cube That Is the Length Of Your Whole Map Or The Length Of The Area Where You Want People To Quit
        // Make A Layer That Wont Collide With The Player And Put That Layer On The Cube
        // Also Set The Collider To Is Trigger

        //(put this on the cube)

        if(other.gameObject.tag == "HandTag")
        {
            Application.Quit();
        }

        if(other.gameObject.tag == "MainCamera")
        {
            Application.Quit();
        }
    }
}
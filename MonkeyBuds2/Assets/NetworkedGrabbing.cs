using System.Collections;
using System.Collections.Generic;
using easyInputs;
using Photon.Pun;
using UnityEngine;

public class NetworkedGrabbing : MonoBehaviour
{
    [Header("THIS IS MADE BY FROGGY")]
    public GameObject Grabbable;
    public AudioSource GrabbedSound;
    public AudioSource LetGoSound;
    public Transform LeftHand;
    public Transform RightHand;
    public bool IsGrabbable;
    public PhotonView View;


    private void OnTriggerEnter(Collider other)
    {
       if (EasyInputs.GetGripButtonDown(EasyHand.RightHand))
        {
            View.RPC("GrabR", RpcTarget.All);
        }
        else if (EasyInputs.GetGripButtonDown(EasyHand.LeftHand))
        {
            View.RPC("GrabL", RpcTarget.All);
        }
    }


    [PunRPC]
    void GrabR()
    {
        GrabbedSound.Play();
        Grabbable.transform.position = RightHand.transform.position;
    }


    [PunRPC]
    void GrabL()
    {
        GrabbedSound.Play();
        Grabbable.transform.position = LeftHand.transform.position;
    }
}

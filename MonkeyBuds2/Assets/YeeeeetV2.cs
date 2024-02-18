using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GorillaLocomotion;
using Photon.Pun;

public class YeeeeetV2 : MonoBehaviour
{
    [Header("Script Made By BumBum Do Not Claim As Yours!!")]
    public string YeetTag;
    public GameObject BatObject;
    [SerializeField] private Rigidbody GorillaPlayer;
    public PhotonView MyView;
    public float YeetForce = 10f;

    private void Start()
    {
        ActivateHierarchy();
    }

    private void ActivateHierarchy()
    {
        GameObject gorillaPlayerObject = GameObject.FindGameObjectWithTag("GorillaPlayer");
        if (gorillaPlayerObject != null)
        {
            GorillaPlayer = gorillaPlayerObject.GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("GorillaPlayer not found. Make sure the tag is set correctly.");
        }
    }

    private void Update()
    {
        if (BatObject.activeInHierarchy == true)
        {
            Debug.Log("Bat is active :)");
        }
        else
        {
            Debug.Log("Bat is gone :(");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(YeetTag))
        {
            if (MyView.IsMine)
            {
                return;
            }
            else
            {
                Vector3 direction = other.transform.position - transform.position;

                direction.Normalize();

                GorillaPlayer.AddForce(direction * YeetForce, ForceMode.Impulse);
            }
        }
    }
}

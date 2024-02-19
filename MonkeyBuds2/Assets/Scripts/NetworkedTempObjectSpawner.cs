using UnityEngine;
using System.Collections;
using Photon.Pun;
using easyInputs;

public class NetworkedTempObjectSpawner : MonoBehaviourPunCallbacks
{
    public GameObject objectToSpawn;
    public GameObject spawnPoint;
    public float spawnDelay = 1.0f;
    public float objectLifetime = 5.0f;

    private PhotonView photonView;
    private bool canSpawn = true;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (photonView.IsMine && EasyInputs.GetTriggerButtonDown(EasyHand.RightHand) && canSpawn)
        {
            StartCoroutine(SpawnObjectWithDelay());
        }
    }

    IEnumerator SpawnObjectWithDelay()
    {
        canSpawn = false;
        GameObject spawnedObject = SpawnObject();

        yield return new WaitForSeconds(spawnDelay);

        canSpawn = true;

        if (spawnedObject != null)
        {
        
            StartCoroutine(DestroySpawnedObjectForAll(spawnedObject.GetComponent<PhotonView>()));
        }
    }

    GameObject SpawnObject()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("The Spawn Point has not been assigned!");
            return null;
        }

        Vector3 spawnPosition = spawnPoint.transform.position;
        Quaternion spawnRotation = spawnPoint.transform.rotation;

        GameObject spawned = PhotonNetwork.Instantiate(objectToSpawn.name, spawnPosition, spawnRotation);
        return spawned;
    }

    IEnumerator DestroySpawnedObjectForAll(PhotonView spawnedObject)
    {
        yield return new WaitForSeconds(objectLifetime);

        if (spawnedObject != null)
        {
            PhotonNetwork.Destroy(spawnedObject);
        }
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.VR;

public class LoadSceneOnTrigger : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] bool disconnect = true;
    [SerializeField] string playerTag = "Body";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if(disconnect)
            {
                PhotonVRManager.Manager.Disconnect();
            }
            SceneManager.LoadScene(sceneName);
        }
    }
}

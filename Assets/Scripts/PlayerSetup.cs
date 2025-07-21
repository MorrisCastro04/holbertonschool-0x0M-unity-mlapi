using UnityEngine;
using Unity.Netcode;

public class PlayerSetup : NetworkBehaviour
{
    public Camera playerCamera;

    private void Start()
    {
        if (!IsOwner)
        {
            playerCamera.enabled = false;
            playerCamera.gameObject.SetActive(false); // opcional
        }
        else
        {
            playerCamera.enabled = true;
        }
    }
}

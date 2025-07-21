using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button startServerButton;
    [SerializeField] private Button connectClientButton;
    [SerializeField] private Button startHostButton;
    
    [SerializeField] private Canvas buttonCanvas;

    [SerializeField] private GameObject MainCamera;

    private void Awake()
    {
        startServerButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            buttonCanvas.enabled = false;
            Debug.Log("Server Started");
        });

        connectClientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            buttonCanvas.enabled = false;
            MainCamera.SetActive(false);
            Debug.Log("Client Connected");
        });

        startHostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            buttonCanvas.enabled = false;
            MainCamera.SetActive(false);
            Debug.Log("Host Started");
        });
    }
}

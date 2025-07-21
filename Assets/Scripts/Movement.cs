using UnityEngine;
using Unity.Netcode;

public class Movement : NetworkBehaviour
{
    public float maxSpeed = 10f;
    public float maxRotation = 100f;

    public NetworkVariable<Vector3> position = new NetworkVariable<Vector3>();
    public NetworkVariable<Quaternion> rotation = new NetworkVariable<Quaternion>();

    private void Update()
    {
        if (IsLocalPlayer)
        {

            float move = maxSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            float turn = maxRotation * Input.GetAxis("Horizontal") * Time.deltaTime;

            transform.Translate(0, 0, move);
            transform.Rotate(0, turn, 0);

            UpdatePlayerPositionServerRpc(transform.position.x, transform.position.y, transform.position.z);
            UpdatePlayerRotationServerRpc(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }
        else
        {
            transform.position = position.Value;
            transform.rotation = rotation.Value;
        }
    }

    [ServerRpc]
    void UpdatePlayerPositionServerRpc(float x, float y, float z)
    {
        position.Value = new Vector3(x, y, z);
    }

    [ServerRpc]
    void UpdatePlayerRotationServerRpc(float x, float y, float z, float w)
    {
        rotation.Value = new Quaternion(x, y, z, w);
    }
}

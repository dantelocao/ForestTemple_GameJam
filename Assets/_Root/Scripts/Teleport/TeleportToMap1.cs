using UnityEngine;

public class TeleportToMap1 : Teleport
{
    private void OnTriggerEnter(Collider other)
    {
        LoadMap1();
    }
}

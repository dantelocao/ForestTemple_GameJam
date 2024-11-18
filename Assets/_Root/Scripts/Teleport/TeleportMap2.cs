using UnityEngine;

public class TeleportMap2 : Teleport
{
    public Transform teleportePoint;

    private void OnTriggerEnter(Collider other)
    {
        // Salva a posição do teleporte para onde o player deve voltar
        PlayerPrefs.SetFloat("TeleportX", teleportePoint.position.x);
        PlayerPrefs.SetFloat("TeleportY", teleportePoint.position.y);
        PlayerPrefs.SetFloat("TeleportZ", teleportePoint.position.z);

        // Opcional: Salva também a rotação do jogador
        PlayerPrefs.SetFloat("TeleportRotY", teleportePoint.eulerAngles.y);

        LoadMap2();
    }
}

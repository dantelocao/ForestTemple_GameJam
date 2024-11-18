using UnityEngine;

public class TeleportMap2 : Teleport
{
    public Transform teleportePoint;

    private void OnTriggerEnter(Collider other)
    {
        // Salva a posi��o do teleporte para onde o player deve voltar
        PlayerPrefs.SetFloat("TeleportX", teleportePoint.position.x);
        PlayerPrefs.SetFloat("TeleportY", teleportePoint.position.y);
        PlayerPrefs.SetFloat("TeleportZ", teleportePoint.position.z);

        // Opcional: Salva tamb�m a rota��o do jogador
        PlayerPrefs.SetFloat("TeleportRotY", teleportePoint.eulerAngles.y);

        LoadMap2();
    }
}

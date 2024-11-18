using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    void Start()
    {
        // Verifica se há uma posição salva
        if (PlayerPrefs.HasKey("TeleportX"))
        {
            // Reposiciona o jogador
            float x = PlayerPrefs.GetFloat("TeleportX");
            float y = PlayerPrefs.GetFloat("TeleportY");
            float z = PlayerPrefs.GetFloat("TeleportZ");

            transform.position = new Vector3(x, y, z);

            // Define a rotação, se salva
            if (PlayerPrefs.HasKey("TeleportRotY"))
            {
                float rotY = PlayerPrefs.GetFloat("TeleportRotY");
                transform.rotation = Quaternion.Euler(0, rotY, 0);
            }
        }
    }
}

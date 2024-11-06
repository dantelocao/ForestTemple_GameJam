using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void TrocarParaCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void teste()
    {
        Debug.Log("Teste");
    }
}

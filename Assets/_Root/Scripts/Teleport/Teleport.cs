using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public void LoadMap1()
    {
        SceneManager.LoadScene("map1");
    }

    public void LoadMap2()
    {
        SceneManager.LoadScene("map2");
    }

    public void LoadInterior()
    {
        SceneManager.LoadScene("interior1");
    }
}

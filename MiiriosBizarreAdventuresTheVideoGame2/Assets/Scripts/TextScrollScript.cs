using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScrollScript : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0.75f, 0);  

        if (transform.position.y > 5500)
        {
           SceneManager.LoadScene("MainMenu");
        }
    }
}

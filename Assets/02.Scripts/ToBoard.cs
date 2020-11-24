using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 touchPosition = Input.GetTouch(0).position;
        
    }

    public void LostAndFound()
    {
        SceneManager.LoadScene("LostAndFound");
    }

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("Scene0");
    }

    public void BackToLFList()
    {
        SceneManager.LoadScene("LostAndFoundList");
    }
}

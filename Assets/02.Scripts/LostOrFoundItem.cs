using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostOrFoundItem : MonoBehaviour
{
    public Toggle lost;
    public Toggle found;

    private LostAndFound item;

    // Start is called before the first frame update
    void Start()
    {
        item = new LostAndFound();
        item.lost = false;
        item.found = false;
        item.image = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadImage()
    {
        Debug.Log("Image Loaded");
        Debug.Log("Hover image on top of button???");
        //item.image =
    }

    public void LoadPhoto()
    {
        Debug.Log("Go to Camera and take a picture");
        Debug.Log("Show image somewhere???");
        //item.image =
    }

    public void Post()
    {
        Debug.Log("Save Data");
        item.objectName = GameObject.FindGameObjectWithTag("Title").GetComponent<InputField>().text;

        if (item.objectName == "")
        {
            Debug.Log("ERROR MESSAGE");
            return;
        }

        item.post = GameObject.FindGameObjectWithTag("Content").GetComponent<InputField>().text;

        if (lost.isOn)
        {
            item.lost = true;
            Debug.Log("Post in <Lost>");
        }
        else if (found.isOn)
        {
            item.found = true;
            Debug.Log("Post in <Found>");
        }
        SaveData();
    }

    private void SaveData()
    {
        //DontDestroyOnLoad, PlayerPrefs
    }
}

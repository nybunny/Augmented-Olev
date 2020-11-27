using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostOrFoundItem : MonoBehaviour
{
    public Toggle lost;
    public Toggle found;

    private LostAndFound item;
    private PlayerPrefs savefile;

    // Start is called before the first frame update
    void Start()
    {
        item = new LostAndFound();
        item.lost = false;
        item.found = false;
        item.image = null;
    }

    public void LoadImage()
    {
        Debug.Log("Image Loaded");
        Debug.Log("Hover image on top of button???");
        //item.image =
    }

    public void LoadLaptop()
    {
        item.image = Resources.Load<Texture2D>("laptop");
    }
    public void LoadWallet()
    {
        item.image = Resources.Load<Texture2D>("wallet");
    }

    public void LoadPhoto()
    {
        Debug.Log("Go to Camera and take a picture");
        Debug.Log("Show image somewhere???");
        //item.image =
    }

    public void Post()
    {
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
        PlayerPrefs.SetString(item.objectName, item.post);
        PlayerPrefs.Save();

        //Debug.Log(item.objectName);
        //Debug.Log(item.post);
        
        Debug.Log("save data");
    }
}

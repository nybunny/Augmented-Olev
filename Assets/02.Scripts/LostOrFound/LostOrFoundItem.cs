using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostOrFoundItem : MonoBehaviour
{
    public Toggle lost;
    public Toggle found;

    public GameObject postView;
    public InputField title, content;

    private LostAndFound item;


    private void OnEnable()
    {
        item = new LostAndFound();
        item.objectNum = GetHighestItemNumber() + 1;
        item.lostOrFound = -1;
        item.image = null;
        title.text = "";
        content.text = "";
    }

    private int GetHighestItemNumber()
    {
        if (PlayerPrefs.HasKey("highestnum"))
            return PlayerPrefs.GetInt("highestnum");
        else
        {
            PlayerPrefs.SetInt("highestnum", -1);
            return -1;
        }
    }

    public void LoadImage(Texture2D image)
    {
        item.image = Resources.Load<Sprite>(image.name);
        Debug.Log("Image Loaded");
        Debug.Log("Hover image on top of button???");
    }

    public void LoadPhoto()
    {
        Debug.Log("Go to Camera and take a picture");
        Debug.Log("Show image somewhere???");
        //item.image =
    }

    public void Post()
    {
        item.objectName = title.text;
        Debug.Log(item.objectName);

        if (item.objectName == "")
        {
            Debug.Log("ERROR MESSAGE");
            return;
        }

        item.post = content.text;
        //Debug.Log(item.lostOrFound);

        if (lost.isOn)
        {
            item.lostOrFound = 0;
            Debug.Log("Post in <Lost>");
        }
        else if (found.isOn)
        {
            item.lostOrFound = 1;
            Debug.Log("Post in <Found>");
        }
        Debug.Log(item.lostOrFound);
        if ((item.lostOrFound == 0) || (item.lostOrFound == 1))
            SaveData();
        else
            Debug.Log("ERROR with item's state(lost/found) number");
        
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("highestnum", item.objectNum);

        PlayerPrefs.SetString("item_" + item.objectNum.ToString(), item.objectName);
        PlayerPrefs.SetInt(item.objectName + item.objectNum.ToString() + "_state", item.lostOrFound);
        PlayerPrefs.SetString(item.objectName + item.objectNum.ToString() + "_post", item.post);
        if (item.image != null)
           PlayerPrefs.SetString(item.objectName + item.objectNum.ToString() + "_image", item.image.name);
        // save the image
        PlayerPrefs.Save();
        
        Debug.Log("save data");

        //Disable PostWrite & Go to PostView
        this.gameObject.SetActive(false);
        
        postView.GetComponent<LostOrFoundPostView>().WhatToShow(item.objectNum, item.objectName);
        postView.SetActive(true);
    }
    /*
     PlayerPrefs key -> value
    highestnum (int)

    **for each lost item**
    item_(objectNum) -> (item.objectName)
    (objectName)(objectNum)_state -> (item.lostOrFound) 0 lost / 1 found / 2 done
    (objectName)(objectNum)_post -> (item.post)
    (objectName)(objectNum)_image -> ???

     */
}

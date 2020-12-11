using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NativeGalleryNamespace;
using System;

public class LostOrFoundPostView : MonoBehaviour
{
    private LostAndFound itemToShow;

    public Text lostOrFoundIndicator;
    public Text title;
    public Text content;
    public Image image; //이거 어떻게 할지 고민 좀
    public Sprite defaultImage;

    public GameObject iLostIt;
    public GameObject iFoundIt;
    /*
    private void Awake()
    {
        itemToShow = new LostAndFound(); // just in case
        itemToShow.lostOrFound = -1;
        itemToShow.objectName = "ctp445";
        itemToShow.objectNum = -1;
        itemToShow.post = "this is a test";
        itemToShow.image = Resources.Load<Sprite>("basicImage");
        Debug.Log("basic image loaded to PostView");
    }
    PostView가 LostOrFoundItem.cs 등으로 Enable 되면 
    이 Awake() 함수가 WhatToShow() 보다 나중에 발동되어서 보여줘야 하는 데이터를 덮어썼던 것임
    */
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("post view start");
    }

    private void OnEnable()
    {
        if (itemToShow.lostOrFound == 0)
        {
            lostOrFoundIndicator.text = "Lost";
            iFoundIt.SetActive(true);
            iLostIt.SetActive(false);
        }   
        else if (itemToShow.lostOrFound == 1)
        {
            lostOrFoundIndicator.text = "Found";
            iFoundIt.SetActive(false);
            iLostIt.SetActive(true);
        }
        else if (itemToShow.lostOrFound == 2)
        {
            lostOrFoundIndicator.text = "Item returned to owner";
            iFoundIt.SetActive(false);
            iLostIt.SetActive(false);
        }
        title.text = itemToShow.objectName;
        content.text = itemToShow.post;
        image.sprite = itemToShow.image;
    }

    public void OnDisable()
    {
        itemToShow = new LostAndFound();
    }

    public void WhatToShow(int objectNum, string objectName)
    {
        Debug.Log("made it here1");
        itemToShow = new LostAndFound();
        itemToShow.objectNum = objectNum;
        itemToShow.objectName = objectName;
        itemToShow.lostOrFound = PlayerPrefs.GetInt(objectName + objectNum.ToString() + "_state");
        itemToShow.post = PlayerPrefs.GetString(objectName + objectNum.ToString() + "_post");
        Debug.Log("made it here2");

        if (PlayerPrefs.HasKey(objectName + objectNum.ToString() + "_image"))
        {
            itemToShow.imageToString = PlayerPrefs.GetString(objectName + objectNum.ToString() + "_image");
            //byte[] texAsByte = Encoding.ASCII.GetBytes(itemToShow.imageToString); // string to byte array
            byte[] texAsByte = Convert.FromBase64String(itemToShow.imageToString);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(texAsByte, false);
            itemToShow.image = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }
        else
            itemToShow.image = defaultImage;
        /*
        // Resources folder does not exist in Build!
        if (PlayerPrefs.HasKey(objectName + objectNum.ToString() + "_image"))
            itemToShow.image = Resources.Load<Sprite>(PlayerPrefs.GetString(objectName + objectNum.ToString() + "_image"));
        else
            itemToShow.image = defaultImage;
        */

        //itemToShow.image -> from gallery?
        Debug.Log("made it here3");
        Debug.Log(itemToShow.objectName);
    }
}

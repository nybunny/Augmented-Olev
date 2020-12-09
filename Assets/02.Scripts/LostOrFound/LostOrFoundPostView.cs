using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostOrFoundPostView : MonoBehaviour
{
    private LostAndFound itemToShow;

    public Text lostOrFoundIndicator;
    public Text title;
    public Text content;
    public Image image; //이거 어떻게 할지 고민 좀

    public GameObject iLostIt;
    public GameObject iFoundIt;

    // Start is called before the first frame update
    void Start()
    {
        itemToShow = new LostAndFound(); // just in case
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (itemToShow.lostOrFound == 0)
        {
            lostOrFoundIndicator.text = "Lost";
            iLostIt.SetActive(true);
            iLostIt.SetActive(false);
        }   
        else if (itemToShow.lostOrFound == 1)
        {
            lostOrFoundIndicator.text = "Found";
            iLostIt.SetActive(false);
            iLostIt.SetActive(true);
        }
        else if (itemToShow.lostOrFound == 2)
        {
            lostOrFoundIndicator.text = "Item returned to owner";
            iLostIt.SetActive(false);
            iLostIt.SetActive(false);
        }
        title.text = itemToShow.objectName;
        content.text = itemToShow.post;
    }

    public void WhatToShow(int objectNum, string objectName)
    {
        itemToShow = new LostAndFound();
        itemToShow.objectNum = objectNum;
        itemToShow.objectName = objectName;
        itemToShow.lostOrFound = PlayerPrefs.GetInt(objectName + objectNum.ToString() + "_state");
        itemToShow.post = PlayerPrefs.GetString(objectName + objectNum.ToString() + "_post");
        //itemToShow.image
    }
}

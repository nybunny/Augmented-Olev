using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LFList : MonoBehaviour
{
    private GameObject canvas;
    private GameObject postView;
    private GameObject postList;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        postView = canvas.GetComponentInChildren
        //postView = GameObject.FindGameObjectWithTag("PostView");
       // postList = GameObject.FindGameObjectWithTag("PostList");
        Debug.Log("LFList.cs start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenTitlePressed(Text postNum)
    {
        Debug.Log("title pressed");
        int no = int.Parse(postNum.text);
        string name = PlayerPrefs.GetString("item_" + no.ToString());
        Debug.Log("title pressed2");
        //Disable PostList & Go to PostView
        //postView.GetComponent<LostOrFoundPostView>().WhatToShow(no, name); //////////////
        Debug.Log("title pressed3");
        postView.SetActive(true);
        postList.SetActive(false);
        Debug.Log("title pressed4");
    }
}

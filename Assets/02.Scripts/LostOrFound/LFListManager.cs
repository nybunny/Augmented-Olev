using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LFListManager : MonoBehaviour
{
    public GameObject postPrefab;
    public GameObject postView;
    public Transform parent;

    private int i;
    private LostAndFound[] postList;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Get the stored Lost & Found data --> then post it on-screen");
        // make the titles buttons that link to their respective posts

        PlayerPrefs.SetString("item_0", "dictionary");
        PlayerPrefs.SetInt("dictionary0_state", 1);
        PlayerPrefs.SetString("dictionary0_post", "abcdefg");
        PlayerPrefs.SetInt("highestnum", 0);
        PlayerPrefs.Save();
    }
    
    private void OnEnable()
    {
        i = -1;
        if (PlayerPrefs.HasKey("highestnum"))
            i = PlayerPrefs.GetInt("highestnum");
        LostAndFound[] postList = new LostAndFound[i+1];
        Debug.Log(i);
        for (int j = 0; j < (i+1) ; j++)
        {
            Debug.Log("j");
            Debug.Log(j);
            postList[j] = new LostAndFound();
            postList[j].objectNum = j;
            postList[j].objectName = PlayerPrefs.GetString("item_" + j.ToString());

            GameObject nextLine = Instantiate(postPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
            nextLine.transform.SetParent(parent, false);
            Debug.Log("ddddd");
            postPrefab.transform.GetChild(0).GetComponent<Text>().text = j.ToString();
            postPrefab.transform.GetChild(2).GetComponent<Text>().text = postList[j].objectName;

        }
    }
    

    public void WhenTitlePressed(Text postNum)
    {
        int no = int.Parse(postNum.ToString());

        //Disable PostList & Go to PostView
        this.gameObject.SetActive(false);

        postView.GetComponent<LostOrFoundPostView>().WhatToShow(no, postList[no].objectName);
        postView.SetActive(true);
    }
}

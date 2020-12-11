using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToLists : MonoBehaviour
{
    private GameObject bustimetable;
    private GameObject canvas;
    private GameObject postList;
    private GameObject noticeList;

    public void Timetable()
    {
        bustimetable.SetActive(true);
    }

    public void ToLostAndFound()
    {
        postList.SetActive(true);
    }

    public void ToNotice()
    {
        noticeList.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        bustimetable = GameObject.FindGameObjectWithTag("Timetable");
        canvas = GameObject.Find("Canvas");
        postList = canvas.transform.Find("PostList").gameObject;
        noticeList = canvas.transform.Find("NoticeList").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

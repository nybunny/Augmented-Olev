using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeListToView : MonoBehaviour
{
    private GameObject canvas;
    private GameObject noticeList;
    private GameObject noticeView;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        noticeList = canvas.transform.Find("NoticeList").gameObject;
        noticeView = canvas.transform.Find("NoticeView").gameObject;
    }

    public void WhenNoticeTitlePressed(Text postNum)
    {
        int num = int.Parse(postNum.text);
        string name = PlayerPrefs.GetString("post_" + num.ToString());
        Debug.Log(name);
        noticeView.GetComponent<NoticeView>().WhichPostToShow(num, name);
        noticeView.SetActive(true);
        noticeList.SetActive(false);
    }
}

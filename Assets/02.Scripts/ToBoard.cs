using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBoard : MonoBehaviour
{
    public GameObject post;
    public GameObject postList;
    public GameObject postView;

    public GameObject noticeList;
    public GameObject noticeView;
    public GameObject noticeWrite;

    // Start is called before the first frame update
    void Start()
    {
        post.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 touchPosition = Input.GetTouch(0).position;
        
    }

    public void GoToLostAndFoundWrite()
    {
        post.gameObject.SetActive(true);
        postList.gameObject.SetActive(false);
    }

    public void BackToMainScreen()
    {
        SceneManager.LoadScene("Scene0");
        Debug.Log("그냥 나머지 스크린들을 전부 SetActive(false) 처리하면 됨");
    }

    public void BackToLFList()
    {
        post.gameObject.SetActive(false);
        postView.gameObject.SetActive(false);
        postList.gameObject.SetActive(true);
    }

    public void ToNoticeList()
    {
        noticeList.gameObject.SetActive(true);
        noticeView.gameObject.SetActive(false);
        noticeWrite.gameObject.SetActive(false);
    }

    public void ToNoticeView()
    {
        noticeList.SetActive(false);
        noticeView.SetActive(true);
        noticeWrite.SetActive(false);
    }

    public void ToNoticeWrite()
    {
        noticeList.SetActive(false);
        noticeView.SetActive(false); //insurance
        noticeWrite.SetActive(true);
    }
}

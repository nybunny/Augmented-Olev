using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeWrite : MonoBehaviour
{

    private Notice post;

    public InputField title, content;
    public GameObject noticeView;

    private void OnEnable()
    {
        post = new Notice();
        post.postNum = GetHighestPostNumber() + 1;
        post.title = "";
        post.content = "";
        post.commentsNum = 0;
        //post.comments = new Dictionary<int, string>();

        title.text = "";
        content.text = "";
    }

    private int GetHighestPostNumber()
    {
        if (PlayerPrefs.HasKey("highestPnum"))
            return PlayerPrefs.GetInt("highestPnum");
        else
        {
            PlayerPrefs.SetInt("highestPnum", -1);
            return -1;
        }
    }

    public void PostNotice()
    {
        post.title = title.text;
        post.content = content.text;

        if ((post.title == "") || (post.content == ""))
        {
            Debug.Log("ERROR: You need a title and some content");
            return;
        }
        SavePostData();
    }

    private void SavePostData()
    {
        PlayerPrefs.SetInt("highestPnum", post.postNum);
        PlayerPrefs.SetString("post_" + post.postNum.ToString(), post.title);
        PlayerPrefs.SetString(post.title + post.postNum.ToString() + "_content", post.content);
        PlayerPrefs.SetInt(post.title + post.postNum.ToString() + "_comment", 0);
        PlayerPrefs.Save();

        //Disable NoticeWrite & Go to NoticeView
        this.gameObject.SetActive(false);
        noticeView.GetComponent<NoticeView>().WhichPostToShow(post.postNum, post.title);
        noticeView.SetActive(true);
    }

    /*
     PlayerPrefs key -> value
    highestPnum

    post_(postNum) -> post.title
    (title)(postNum)_content -> post.content
    (title)(postNum)_comment -> post.commentsNum
    (title)(postNum)_comment(commentNum) -> (comment)
     
     */
}

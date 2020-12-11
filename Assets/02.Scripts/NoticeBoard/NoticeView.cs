using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeView : MonoBehaviour
{
    private Notice postToShow;
    private Queue<GameObject> toDestroy;

    public Text title;
    public Text content;
    public InputField commentInput;
    public GameObject commentButton;
    public GameObject commentPrefab;
    public Transform parent;

    private void OnEnable()
    {
        if (postToShow == null)
        {
            postToShow = new Notice();
            postToShow.title = "ctp445";
            postToShow.content = "augmented-olev";
         //   postToShow.comments = new Dictionary<int, string>();
         //   postToShow.comments.Add(0, "comment0");
         //   postToShow.comments.Add(1, "test comment1");
            postToShow.commentsNum = 0;
        }

        title.text = postToShow.title;
        content.text = postToShow.content;
        if ((postToShow != null) && (postToShow.commentsNum > 0))
        {
            
            postToShow.comments = new Dictionary<int, string>();
            for (int i = 1; i < (postToShow.commentsNum + 1); i++) // upload comments to dictionary
            {
                Debug.Log("1 or more comment");
                postToShow.comments.Add(i, PlayerPrefs.GetString(postToShow.title + postToShow.postNum.ToString() + "_comment" + i.ToString()));
            }

            toDestroy = new Queue<GameObject>();
            for (int j = 1; j < (postToShow.commentsNum + 1); j++)
            {
                Debug.Log("here");
                PostComment(j);
            }
        }
    }

    private void OnDisable()
    {
        if ((postToShow != null) && (postToShow.commentsNum > 0))
        {
            PlayerPrefs.SetInt(postToShow.title + postToShow.postNum.ToString() + "_comment", postToShow.commentsNum);
            Debug.Log("comments save");
            PlayerPrefs.Save();
            while (toDestroy.Count != 0)
                Destroy(toDestroy.Dequeue());
        }
        postToShow = new Notice();
    }

    public void WhichPostToShow(int postNum, string postTitle)
    {
        postToShow = new Notice();
        postToShow.postNum = postNum;
        postToShow.title = postTitle;
        postToShow.content = PlayerPrefs.GetString(postTitle + postNum.ToString() + "_content");
        if (PlayerPrefs.HasKey(postTitle + postNum.ToString() + "_comment"))
            postToShow.commentsNum = PlayerPrefs.GetInt(postTitle + postNum.ToString() + "_comment");
        else
            postToShow.commentsNum = 0;
    }


    private void PostComment(int commentNum)
    {
        GameObject nextComment = Instantiate(commentPrefab, new Vector3(0f, - 90*(commentNum - 1), 0f), Quaternion.identity);
        nextComment.transform.SetParent(parent, false);

        nextComment.transform.Find("Num").GetComponent<Text>().text = commentNum.ToString();
        nextComment.transform.Find("Comment").GetComponent<Text>().text = postToShow.comments[commentNum];
        toDestroy.Enqueue(nextComment);
        Debug.Log(commentNum.ToString() + postToShow.comments[commentNum]);
    }

    public void CommentButtonPressed()
    {
        if (commentInput.text == "")
            return;
        else
        {
            if (postToShow.commentsNum < 1)
            {
                postToShow.commentsNum = 1;
                postToShow.comments = new Dictionary<int, string>();
                postToShow.comments.Add(1, commentInput.text);
                PlayerPrefs.SetString(postToShow.title + postToShow.postNum.ToString() + "_comment1", commentInput.text);
                PlayerPrefs.Save();
                toDestroy = new Queue<GameObject>();
                PostComment(1);
            }
            else
            {
                postToShow.commentsNum += 1;
                postToShow.comments.Add(postToShow.commentsNum, commentInput.text);
                PlayerPrefs.SetString(postToShow.title + postToShow.postNum.ToString() + "_comment" + postToShow.commentsNum.ToString(), commentInput.text);
                PlayerPrefs.Save();
                PostComment(postToShow.commentsNum);
            }
            commentInput.text = "";
        }
    }
}

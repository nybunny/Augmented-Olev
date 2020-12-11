using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeList : MonoBehaviour
{
    public GameObject listPrefab;
    public Transform parent;

    public Queue<GameObject> toDestroy;


    private void OnEnable()
    {
        int i = -1;
        if (PlayerPrefs.HasKey("highestPnum"))
            i = PlayerPrefs.GetInt("highestPnum");

        toDestroy = new Queue<GameObject>();

        for (int j=0; j < (i+1); j++)
        {
            GameObject nextLine = Instantiate(listPrefab, new Vector3(0f, -100*j, 0f), Quaternion.identity);
            nextLine.transform.SetParent(parent, false);
            nextLine.transform.Find("Num").GetComponent<Text>().text = j.ToString();
            nextLine.transform.Find("Title").GetComponent<Text>().text = PlayerPrefs.GetString("post_" + j.ToString());
            toDestroy.Enqueue(nextLine);
        }
    }

    private void OnDisable()
    {
        while (toDestroy.Count > 0)
            Destroy(toDestroy.Dequeue());
        Debug.Log("past post list destroyed");
    }

    private void OnApplicationQuit()
    {
        while (toDestroy.Count > 0)
            Destroy(toDestroy.Dequeue());
        Debug.Log("app done");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostOrFoundItem : MonoBehaviour
{
    public Toggle lost;
    public Toggle found;

    public GameObject postView;

    private LostAndFound item;
    private int item_stateNum;

    private int highestNum;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll(); //나중에 지우시오
        
    }

    private void OnEnable()
    {
        item = new LostAndFound();
        item.objectNum = GetHighestItemNumber() + 1;
        item.lost = false;
        item.found = false;
        item.image = null;
        item_stateNum = -1;
    }

    private int GetHighestItemNumber()
    {
        if (PlayerPrefs.HasKey("highestnum"))
            return PlayerPrefs.GetInt("highestnum");
        else
        {
            PlayerPrefs.SetInt("highestnum", 0);
            return 0;
        }
    }

    public void LoadImage(Texture2D image)
    {
        item.image = Resources.Load<Texture2D>(image.name);
        Debug.Log("Image Loaded");
        Debug.Log("Hover image on top of button???");
    }

    public void LoadPhoto()
    {
        Debug.Log("Go to Camera and take a picture");
        Debug.Log("Show image somewhere???");
        //item.image =
    }

    public void Post()
    {
        item.objectName = GameObject.FindGameObjectWithTag("Title").GetComponent<InputField>().text;

        if (item.objectName == "")
        {
            Debug.Log("ERROR MESSAGE");
            return;
        }

        item.post = GameObject.FindGameObjectWithTag("Content").GetComponent<InputField>().text;

        if (lost.isOn)
        {
            item.lost = true;
            item_stateNum = 0;
            Debug.Log("Post in <Lost>");
        }
        else if (found.isOn)
        {
            item.found = true;
            item_stateNum = 1;
            Debug.Log("Post in <Found>");
        }

        if ((item_stateNum == 0) || (item_stateNum == 1))
            SaveData();
        else
            Debug.Log("ERROR with item_stateNum");
        
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("highestnum", item.objectNum);

        PlayerPrefs.SetString("item_" + item.objectNum.ToString(), item.objectName);
        PlayerPrefs.SetInt(item.objectName + item.objectNum.ToString() + "_state", item_stateNum);
        PlayerPrefs.SetString(item.objectName + item.objectNum.ToString() + "_post", item.post);
        // save the image
        PlayerPrefs.Save();
        
        Debug.Log("save data");

        //Disable PostWrite & Go to PostView
        this.gameObject.SetActive(false);
        postView.SetActive(true);

    }
    /*
     PlayerPrefs key -> value
    highestnum (int)

    **for each lost item**
    item_(objectNum) -> (objectName)
    (objectName)(objectNum)_state -> 0 lost / 1 found / 2 done
    (objectName)(objectNum)_post -> (post)
    (objectName)(objectNum)_image -> ???

     */
}

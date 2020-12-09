using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LostAndFound
{
    public int objectNum;
    public string objectName;

    public int lostOrFound; // 0 if lost, 1 if found

    public string post;
    public Texture2D image;
}

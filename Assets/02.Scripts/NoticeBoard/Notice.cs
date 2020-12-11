using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice
{
    public int postNum;
    public string title;
    public string content;

    public int commentsNum; // number of comments
    public Dictionary<int, string> comments; // int starts at 1
}

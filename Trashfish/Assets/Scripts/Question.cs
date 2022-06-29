using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question 
{
    public string question;
    public bool hasTrash;
    public string[] answers = new string[7];
    public float[] answersTrashAmount = new float[7];
}

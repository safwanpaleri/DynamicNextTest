using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject BlueUIPrefab;
    [SerializeField] private GameObject RedUIPrefab;
    [SerializeField] private Transform ScrollviewContent;

    //A Function to create UI in the events tab,
    //Takes name, message and color and will do accordingly
    public void CreateUI(string Name,string Message, string color)
    {
        GameObject newUIItem;
        if(color == "Blue")
            newUIItem = Instantiate(BlueUIPrefab, ScrollviewContent);
        else
            newUIItem = Instantiate(RedUIPrefab, ScrollviewContent);

        if(newUIItem != null)
        {
            var UIItemScript = newUIItem.GetComponent<EventUIItem>();
            if(UIItemScript != null)
            {
                UIItemScript.Title.text = Name;
                UIItemScript.Description.text = Message;
            }
        }
    }

}

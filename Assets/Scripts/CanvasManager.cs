using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject BlueUIPrefab;
    [SerializeField] private GameObject RedUIPrefab;
    [SerializeField] private Transform ScrollviewContent;
    [SerializeField] private ScrollRect scrollrect;
    private bool autoscroll = false;

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
        autoscroll = true;
    }

    private void Update()
    {
        if (scrollrect.verticalNormalizedPosition <= 0.01f)
        {
            autoscroll = false;
        }
        if(autoscroll)
        {
            scrollrect.verticalNormalizedPosition = Mathf.Lerp(scrollrect.verticalNormalizedPosition, 0f, 10f * Time.deltaTime);
        }

    }

    //private IEnumerator ScrollToBottom()
    //{

    //    yield return new WaitForSeconds(1f);
    //}

}

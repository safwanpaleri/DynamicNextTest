using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventUIItem : MonoBehaviour
{
    [SerializeField] public TMP_Text Title;
    [SerializeField] public TMP_Text Description;
    [SerializeField] public TMP_Text Time;
    private int minutes = 0;
    private int hours = 0;
    // Start is called before the first frame update
    void Start()
    {
        //starts the timing immediatly after placed in scene
        StartCoroutine(UpdateTime());
    }

    /// <summary>
    /// Updates time in the Time text field.
    /// </summary>
    /// <returns></returns>
    private IEnumerator UpdateTime()
    {
        if (hours > 0)
            Time.text = hours.ToString() + " hours ago";
        else
            Time.text = minutes.ToString() + " mins ago";
        
        yield return new WaitForSeconds(60f);
        minutes += 1;
        
        if(minutes > 59)
        {
            hours += 1;
            minutes = 0;
        }

        StartCoroutine(UpdateTime());
        
    }
}

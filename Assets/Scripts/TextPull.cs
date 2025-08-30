using UnityEngine;
using TMPro; // Don't forget this!

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private PrayerBlock prayer;
    [SerializeField] private TMP_Text targetTextMeshPro; // Assign this in the Inspector

    void Start()
    {
        targetTextMeshPro.SetText(prayer.blockName);
        // Example: Getting text from another TMP_Text component
        if (targetTextMeshPro != null)
        {
            //Debug.Log("Text from target: " + targetTextMeshPro.text);
            // You can then use this text for your own TMP_Text component
            GetComponent<TMP_Text>().text = targetTextMeshPro.text;
        }
    }
}

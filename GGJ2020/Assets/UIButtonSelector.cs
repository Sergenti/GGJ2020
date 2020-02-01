using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButtonSelector : MonoBehaviour, ISelectHandler// required interface when using the OnSelect method.
{
    [SerializeField] private GameObject selector;

    //Do this when the selectable UI object is selected.
    public void OnSelect(BaseEventData eventData)
    {
        DisplaySelector(true);

        // iterate through all objects that have the same parent as this one
        // super ugly code
        foreach (Transform buttonTransform in transform.parent)
        {
            if (buttonTransform.gameObject == this.gameObject) continue;

            buttonTransform.GetComponent<UIButtonSelector>().DisplaySelector(false);
        }
    }

    public void DisplaySelector(bool value)
    {
        selector.SetActive(value);
    }
}
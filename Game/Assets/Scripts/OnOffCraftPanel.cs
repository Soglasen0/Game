using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffCraftPanel : MonoBehaviour
{
    private Transform craftPanel;
    private bool isActivePanel;
    void Start()
    {
        craftPanel = transform.GetChild(1);
        isActivePanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(isActivePanel);
            isActivePanel = !isActivePanel;
            craftPanel.gameObject.SetActive(isActivePanel);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Z_SideChecks : MonoBehaviour
{
    [SerializeField] private GameObject horizontalTriggers, verticalTriggers;
    bool horizontal;
    void Start()
    {
        horizontal = false;
    }

    // Update is called once per frame
    void Update()
    {
        switchBoolean();
        Managetriggers();
    }

    void switchBoolean()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            horizontal = !horizontal;
        }
    }
    void Managetriggers()
    {
        if (horizontal)
        {
            horizontalTriggers.SetActive(true);
            verticalTriggers.SetActive(false);
        }
        else
        {
            horizontalTriggers.SetActive(false);
            verticalTriggers.SetActive(true);
        }
    }

  
}

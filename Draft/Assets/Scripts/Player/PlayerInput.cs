using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject myPrefab;

    private Button currentButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(currentButton != null)
            {
                currentButton.Up(false);
                currentButton = null;
            }

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider != null)
            {
                Button button = hit.transform.GetComponent<Button>();
                if (button != null)
                {
                    currentButton = button;
                    button.Down();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(currentButton != null)
            {
                currentButton.Up(true);
                currentButton = null;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPress : MonoBehaviour
{
    public GameObject myPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider != null)
            {
                Button button = hit.transform.GetComponent<Button>();
                if (button != null)
                {
                    button.Click();
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                }
                //StartCoroutine(ScaleMe(hit.transform));
            }
        }

        IEnumerable ScaleMe(Transform objTr)
        {
            objTr.localScale *= 1.2f;
            yield return new WaitForSeconds(0.5f);
            objTr.localScale /= 1.2f;
        }
    }
}

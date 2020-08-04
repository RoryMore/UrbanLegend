using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Vector3 swipeBarLoc; //Position storing for comparing when swiping
    private Vector3 initialPos;
    private float scale; // Ensures that swiping doesn't move the objects too much

    public float threshold = 0.2f;
    public float easing = 1.0f;
    bool up; // Checks if the UI has been pulled up


    // Start is called before the first frame update
    void Start()
    {
        swipeBarLoc = transform.position;
        initialPos = transform.position;
        scale = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        float difference = eventData.pressPosition.y - eventData.position.y;
        transform.position = swipeBarLoc - new Vector3(0, difference * scale, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        float percentage = (eventData.pressPosition.y - eventData.position.y) / Screen.height;

        if (Mathf.Abs(percentage) >= threshold)
        {
            Vector3 newLoc = swipeBarLoc;

            //May need to swap this
            if (percentage > 0 && up == true)
            {
                //newLoc += new Vector3(0, -Screen.height * scale * 0.5f, 0);
                newLoc = initialPos;
                up = false;
            }

            else if (percentage < 0 && up == false)
            {
                newLoc += new Vector3(0, Screen.width * scale, 0);
                up = true;
            }

            //StartCoroutine(SmoothMove(transform.position, newLoc, easing));
            transform.position = newLoc;
            swipeBarLoc = newLoc;
        }

        else
        {
            //StartCoroutine(SmoothMove(transform.position, swipeBarLoc, easing));
            transform.position = swipeBarLoc;
        }
        
    }

    IEnumerator SmoothMove (Vector3 startPos, Vector3 endPos, float seconds)
    {
        float t = 0.0f;
        while (t<= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 0, t));
            yield return null;
        }

    }


}

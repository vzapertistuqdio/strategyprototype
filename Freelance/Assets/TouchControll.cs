using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControll : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public GameObject[] soldiers;
    public LineRenderer line;

    private bool isChoosed;

    

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isChoosed = true;
        for (int i = 0; i < soldiers.Length; i++)
        {
            soldiers[i].GetComponent<SelectController>().OnSelected();
        }
        line.enabled = true;
        line.SetPosition(0,soldiers[0].transform.position);
      
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isChoosed)
        {
            for (int i = 0; i < soldiers.Length; i++)
            {
                soldiers[i].GetComponent<Controller>().Move(1.5f*i);
            }
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(myRay, out hitInfo);
            line.SetPosition(1, hitInfo.point);
        }
      
        isChoosed = false;
    }

    private void Start()
    {
        isChoosed = false;
        line.enabled = false;
    }

    
    private void Update()
    {
        line.SetPosition(0, soldiers[0].transform.position);
    }
}

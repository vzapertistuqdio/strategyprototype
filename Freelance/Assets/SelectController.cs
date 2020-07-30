using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    
    public void OnSelected()
    {
        StartCoroutine(SelectAnim());
    }

    private IEnumerator SelectAnim()
    {
        transform.localScale = new Vector3(1.2f,1.2f,1.2f);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = Vector3.one;
    }
}

using UnityEngine;
using System.Collections;
public class WaitForSecondsExample : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine("a");
    }
    IEnumerator Example()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(5);
        Debug.Log(Time.time);
    }
}

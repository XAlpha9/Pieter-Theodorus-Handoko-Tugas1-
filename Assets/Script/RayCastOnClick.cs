using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastOnClick : MonoBehaviour
{
    [SerializeField] private LayerMask Layers;
    [SerializeField] private Camera cameras;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D Hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (Hit != null)
            {
                IObject Tapped = Hit.GetComponent<IObject>();
                if (Tapped != null)
                {
                    Debug.Log("Hit!");
                    Tapped.OnTap();
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControls : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeScale == 0) return;
        CheckShot();
        Rotate();
    }

    void CheckShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        Instantiate(bullet, transform.position + -0.6f * transform.right, transform.rotation);
    }

    void Rotate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dif = (transform.position - mousePosition);

        float rotation = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}

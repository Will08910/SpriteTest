using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour_changer : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        ChangeColour();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColour();
    }

    void ChangeColour()
    {
        if (player.transform.position.y < -15)
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
        }
    }
}

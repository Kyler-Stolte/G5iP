using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectiveSystem : MonoBehaviour
{

    public GameObject[] objectstoShoot;
    public Text descriptionText;
    public Text tallyText;

    private int totalObjects = 4;
    private int objectsShot = 0;

    private int Index;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            descriptionText.text = objectstoShoot[Index].GetComponent<ObjectDescription>.description;
        }
    }
}

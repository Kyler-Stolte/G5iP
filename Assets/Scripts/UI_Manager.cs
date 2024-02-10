using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;//need to set the text for the ammo

    [SerializeField]
    private Text _special;//special ammo
    public void UpdateAmmo (int count)//updates the ammo counter takes in the int amount of the ammo
    {
        _ammoText.text = "Ammo:" + count;//updates the count of the ammo
    }

    public void UpdateSpecial(int counts)
    {
        _special.text = "Special Ammo:" + counts;
    }
}

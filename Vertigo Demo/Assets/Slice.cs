using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Slice : MonoBehaviour
{
    public int SliceNo;
    public int rewardCount;
    public string rewardType;
    public TMP_Text countText;


    void Start()
    {
        if (rewardCount / 1000 >= 1)
        {
            countText.SetText("x" + (rewardCount / 1000).ToString() + "K");
        }
        else
        {
            countText.SetText("x" + rewardCount.ToString());
        }

        if (rewardType == "Chest")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("UI_icon_chest_Bronze_nolight");
            transform.localScale = new Vector3(0.125f, 0.125f, 1f);

        }
        else if (rewardType == "Gold")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UI_icon_gold");
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
        else if (rewardType == "Cash")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UI_icon_cash");
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
        else if (rewardType == "Bomb")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ui_icon_render_cons_grenade_m26");
            transform.localScale= new Vector3(0.125f, 0.125f, 1f);
            countText.SetText("");
        }
    }

    public void UpdateReward()
    {
        if (rewardType == "ChestTemp") //Add bomb after silver or gold spin
        {
            rewardType = "Bomb";
        }
        if (rewardType == "Super Chest") //Add bomb after silver or gold spin
        {
            rewardType = "Chest";
        }

        if (gameObject.GetComponentInParent<Wheel>().zone % 5!=0) 
        {
            
            int randInt=Random.Range(1, 10); // 2/10 chance for 2x upgrade, 1/10 chance for 4x upgrade
            if (randInt==1 || randInt==2)
                rewardCount *= 2;
            else if (randInt==10)
                rewardCount *= 4;

        }
        else if (gameObject.GetComponentInParent<Wheel>().zone % 30!=0) //Silver Spin
        {

            if (rewardType == "Bomb")
            {
                rewardType = "ChestTemp";
            }
        }
        else //Gold Spin
        {

            if (rewardType == "Chest")
                rewardType = "Super Chest";
            if (rewardType == "Bomb")
            {
                rewardType = "ChestTemp";
            }
            rewardCount *= 10;
        }

        if (rewardCount / 1000 >= 1)
        {
            countText.SetText("x" + (rewardCount / 1000).ToString() + "K");
        }
        else
        {
            countText.SetText("x" + rewardCount.ToString());
        }

        if (rewardType == "Chest")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UI_icon_chest_Bronze_nolight");
            transform.localScale = new Vector3(0.125f, 0.125f, 1f);

        }
        else if (rewardType == "Gold")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UI_icon_gold");
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
        else if (rewardType == "Cash")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UI_icon_cash");
            transform.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
        else if (rewardType == "Bomb")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ui_icon_render_cons_grenade_m26");
            transform.localScale = new Vector3(0.125f, 0.125f, 1f);
            countText.SetText("");
        }

        else if (rewardType == "Super Chest")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UI_icon_chest_super_nolight");
            transform.localScale = new Vector3(0.125f, 0.125f, 1f);
        }
        else if (rewardType == "ChestTemp")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("UI_icon_chest_Bronze_nolight");
            transform.localScale = new Vector3(0.125f, 0.125f, 1f);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Wheel : MonoBehaviour
{
    public float RotatePower;
    public float StopPower;

    private Rigidbody2D rbody;
    int inRotate;

    public int zone;

    public int chests=0;
    public int gold=0;
    public int cash=0;
    public int super_chests=0;
    public GameObject leave_button;
    public GameObject lose_screen;
    public GameObject win_screen;
    public GameObject game;
    public GameObject currentLoot;

    public TMP_Text chestsText;
    public TMP_Text goldText;
    public TMP_Text cashText;
    public TMP_Text super_chestsText;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        StopPower = Random.Range(100f, 300f);
    }

    float t;
    private void Update()
    {

        if (rbody.angularVelocity > 0)
        {
            rbody.angularVelocity -= StopPower * Time.deltaTime;

            rbody.angularVelocity = Mathf.Clamp(rbody.angularVelocity, 0, 1440);
        }

        if (rbody.angularVelocity == 0 && inRotate == 1)
        {
            t += 1 * Time.deltaTime;
            if (t >= 0.5f)
            {
                GetReward();

                inRotate = 0;
                t = 0;
                StopPower = Random.Range(100f, 300f);
            }
        }
    }


    public void Rotate()
    {
        if (inRotate == 0)
        {
            rbody.AddTorque(RotatePower);
            inRotate = 1;
        }
    }

    public void Leave()
    {
        if(inRotate == 0)
        {
            win_screen.SetActive(true);
            currentLoot.transform.parent = win_screen.transform.GetChild(0).transform;
            currentLoot.transform.position = new Vector3(-7.5f, 1.2f, 0f);
            game.SetActive(false);
        }
    }



    public void GetReward()
    {
        float rot = transform.eulerAngles.z;
        zone += 1;
        if (zone % 30 == 0) 
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ui_spin_golden_base");
            leave_button.SetActive(true);
        }
        else if (zone % 5 == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ui_spin_silver_base");
            leave_button.SetActive(true);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("ui_spin_bronze_base");
            leave_button.SetActive(false);
        }
        if (rot +22 > 0 && rot +22 <= 45)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Slice>().SliceNo == 1)
                       Win(child.gameObject.GetComponent<Slice>().rewardCount, child.gameObject.GetComponent<Slice>().rewardType);
                child.gameObject.GetComponent<Slice>().UpdateReward();

            }
            
        }
        else if (rot +22> 45 && rot +22 <= 90)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Slice>().SliceNo == 2)
                    Win(child.gameObject.GetComponent<Slice>().rewardCount, child.gameObject.GetComponent<Slice>().rewardType);
                child.gameObject.GetComponent<Slice>().UpdateReward();
            }
        }
        else if (rot +22> 90 && rot +22<= 135)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Slice>().SliceNo == 3)
                    Win(child.gameObject.GetComponent<Slice>().rewardCount, child.gameObject.GetComponent<Slice>().rewardType);
                child.gameObject.GetComponent<Slice>().UpdateReward();
            }
        }
        else if (rot +22> 135 && rot +22<= 180)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Slice>().SliceNo == 4)
                    Win(child.gameObject.GetComponent<Slice>().rewardCount, child.gameObject.GetComponent<Slice>().rewardType);
                child.gameObject.GetComponent<Slice>().UpdateReward();
            }
        }
        else if (rot +22> 180 && rot +22<= 225)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Slice>().SliceNo == 5)
                    Win(child.gameObject.GetComponent<Slice>().rewardCount, child.gameObject.GetComponent<Slice>().rewardType);
                child.gameObject.GetComponent<Slice>().UpdateReward();
            }
        }
        else if (rot +22> 225 && rot +22<= 270)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Slice>().SliceNo == 6)
                    Win(child.gameObject.GetComponent<Slice>().rewardCount, child.gameObject.GetComponent<Slice>().rewardType);
                child.gameObject.GetComponent<Slice>().UpdateReward();
            }
        }
        else if (rot +22> 270 && rot +22<= 315)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Slice>().SliceNo == 7)
                    Win(child.gameObject.GetComponent<Slice>().rewardCount, child.gameObject.GetComponent<Slice>().rewardType);
                child.gameObject.GetComponent<Slice>().UpdateReward();
            }
        }
        else if (rot +22> 315 && rot +22<= 360)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Slice>().SliceNo == 8)
                    Win(child.gameObject.GetComponent<Slice>().rewardCount, child.gameObject.GetComponent<Slice>().rewardType);
                child.gameObject.GetComponent<Slice>().UpdateReward();
            }
        }
        else
        {
            foreach (Transform child in gameObject.transform)
            {
                if (child.gameObject.GetComponent<Slice>().SliceNo == 1)
                    Win(child.gameObject.GetComponent<Slice>().rewardCount, child.gameObject.GetComponent<Slice>().rewardType);
                child.gameObject.GetComponent<Slice>().UpdateReward();

            }
        }

    }


    public void Win(int count,string Type)
    {
        if (Type == "Chest")
        {
            chests += count;
            chestsText.SetText(chests.ToString());
        }
        else if (Type == "Gold")
        {
            gold += count;
            goldText.SetText(gold.ToString());
        }
        else if (Type == "Cash")
        {
            cash += count;
            cashText.SetText(cash.ToString());
        }
        else if (Type == "Bomb")
        {
            chests = 0;
            cash = 0;
            gold = 0;
            super_chests = 0;
            lose_screen.SetActive(true);
            game.SetActive(false);
        }

        else if (Type == "Super Chest")
        {
            super_chests += count;
            super_chestsText.SetText(super_chests.ToString());
        }
        else if (Type == "ChestTemp")
        {
            chests += count;
            chestsText.SetText(chests.ToString());
        }

    }


}
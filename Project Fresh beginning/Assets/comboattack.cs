using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    Animator ani;
    bool strigger;
    public int combo;
    public int combonumber;
    public bool attacking;
    public float combotiming;
    public float combtempo;

    void Start()
    {
        ani = GetComponent<Animator>();
        combo = 1;
        combotiming = 0.9f;
        combtempo = combotiming;
        combonumber = 3;
    }

    // Update is called once per frame
    void Update()
    {
        HandleComboAttack(); // Gọi hàm combo trong Update
    }

    public void HandleComboAttack() // Đổi tên hàm combo thành HandleComboAttack
    {
        combtempo -= Time.deltaTime;

        // Bắt đầu combo khi nhấn phím "J" và combtempo < 0
        if (Input.GetKeyDown(KeyCode.J) && combtempo < 0)
        {
            attacking = true;
            ani.SetTrigger("Attack" + combo);
            combtempo = combotiming;
        }
        // Tiếp tục combo khi thời gian còn lại trong khoảng cho phép
        else if (Input.GetKeyDown(KeyCode.J) && combtempo > 0 && combtempo < 0.3f)
        {
            attacking = true;
            combo++;

            // Reset combo nếu vượt quá số lượng combo cho phép
            if (combo > combonumber)
            {
                combo = 1;
            }

            ani.SetTrigger("Attack" + combo);
            combtempo = combotiming;
        }
        // Nếu không bấm phím trong thời gian cho phép, tắt trạng thái tấn công và reset combo
        else if (combtempo < 0 && !Input.GetKeyDown(KeyCode.J))
        {
            attacking = false;
            if (combtempo < 0)
                combo = 1;
        }
    }
}

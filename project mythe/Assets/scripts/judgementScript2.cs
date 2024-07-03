using UnityEngine;

public class JudgementScript2 : MonoBehaviour
{
    [SerializeField] private Transform object2;
    [SerializeField] private float judgement1;
    [SerializeField] private float judgement2;
    [SerializeField] private float judgement3;
    [SerializeField] private float judgement4;
    [SerializeField] private HealthManager Manager;
    [SerializeField] private GameManager Manager2;
    [SerializeField] private comboScript combo;
    [SerializeField] private bool canbepressed;
    

    private void Start()
    {
        canbepressed = false;
        


    }

    private void Update()
    {


        
        float xDistance = Mathf.Abs(transform.position.x - object2.position.x);

        
        if (xDistance <= judgement1)
        {
            if (Input.GetKeyDown(KeyCode.J) && canbepressed == true)
            {
                combo.IncreaseCombo();
                Manager2.SpawnNotes(0);
                Manager.Heal(10f);
                canbepressed = false;
            }

        }
        else if (xDistance <= judgement2)
        {
            if (Input.GetKeyDown(KeyCode.J) && canbepressed == true)
            {
                combo.IncreaseCombo();
                Manager2.SpawnNotes(1);
                Manager.Heal(5f);
                canbepressed = false;
            }

        }
        else if (xDistance <= judgement3)
        {
            canbepressed = true;
            if (Input.GetKeyDown(KeyCode.J) && canbepressed == true)
            {
                combo.IncreaseCombo();
                Manager2.SpawnNotes(2);
                Manager.TakeDamage(3f);


            }

        }
        else if (xDistance <= judgement4)
        {
            

            canbepressed = false;
            if (Input.GetKeyDown(KeyCode.J))
            {
                combo.ResetCombo();
                Debug.Log("missed");
                Manager.TakeDamage(35f);
                combo.missCount++;
            }
        }
    }
}

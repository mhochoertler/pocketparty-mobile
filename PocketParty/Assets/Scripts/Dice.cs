using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{


    private Sprite[] diceSides;
    private SpriteRenderer rend;

    
    private void Start()
    {

         diceSides = new Sprite[6];
         Debug.Log(diceSides.Length);
         rend = GetComponent<SpriteRenderer>();
         diceSides = Resources.LoadAll<Sprite>("Dice");
         Debug.Log(diceSides.Length);
        
    }


    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

   
    private IEnumerator RollTheDice()
    {
       

        Debug.Log(diceSides.Length);
        int randomDiceSide = 0;
        int finalSide = 0;

        
        for (int i = 0; i <= 20; i++)
        {
            
            randomDiceSide = Random.Range(0, 5);
            rend.sprite = diceSides[randomDiceSide];
            Debug.Log(randomDiceSide);

            yield return new WaitForSeconds(0.1f);
        }

       
        finalSide = randomDiceSide + 1;

        
        Debug.Log(finalSide);
    }
}


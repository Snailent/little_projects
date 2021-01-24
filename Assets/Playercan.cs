using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercan : MonoBehaviour
{
    
void Update()
    {
        //MoveCharacter
        transform.Translate(Input.GetAxis("Horizontal")* 15f * Time.deltaTime, 0f, 0f);

        //Flipcharacter
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0){
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0){
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDonkey : MonoBehaviour
{

    public static float donkeySpeed = 15f;

    int[] directionArray = {-1, 1}; //{-1, 1}; //creates an arrray with the values -1 and 1.
    //Note: You can also write this as int[] directionArray = new int[x] where x is the number of elements.
    //Just make sure to initilize them in start if you do so.
    int directionSelector;

    int[] timerArray = { 3, 4, 5, 5};
    int timerSelector;


    int direction;

    float functionTimer; //creates an integer variable that will be used as a timer to call a function. 
    
    // Start is called before the first frame update
    void Start()
    {
        #region Donkey Direction
        int directionSelector = Random.Range(0, 2); //chooses an integer between 0 and 1.
        //Note: when doing Random.Range, and when trying to do so with an integer, the range will EXCLUDE the last
        //number. So for instance in this case (0, 2) its picking between 0 and 1 since it's exlcuding the 2.
        //when doing this with a float, its inclusive, so it will instead pick between 0, 1, and 3.
        direction = directionArray[directionSelector]; //sets direction to be whatever the selected array value is.
        #endregion

        #region Timer Value Selection
        int timerSelector = Random.Range(0, 4); //selects a random number between 0 and 4
        float functionTimer = timerArray[timerSelector]; //sets float value equal to the selected array value. 
        #endregion

        //Debug.Log(direction);

        Invoke("DonkeyDirection", functionTimer); //calls direction function after 3 seconds. 
    }

    // Update is called once per frame
    void Update()
    {
        #region Debug Value Trackers;
        //Debug.Log(arraySelector);
        //Debug.Log(functionTimer);
        //Debug.Log(direction);
        #endregion

        //This automatically moves the Donkey in a given direction determined at start or when DonkeyDirection function is called,
        //and moves along its xAxis by a given speed. 
        transform.position = UtilScript.Vector3Modify(transform.position, ((direction * donkeySpeed) * Time.deltaTime), 0, 0);

        #region Boundaries
        if (transform.position.x <= -45) //if x value is less than or equal to -45
        {
            direction = -direction;     //inverses direction. 
            Debug.Log("I reached the border");
        }
        if (transform.position.x >= 45) //if x value is greater than or equal to 45
        {
            direction = -direction;     //inverses direction. 
            Debug.Log("I reached the border");
        }
        #endregion

    }

    void DonkeyDirection()
    {
        //Debug.Log(direction);
        Debug.Log("You called a function");

        //this function changes the direction of the Donkey after a set amount of time.

        #region Direction Change
        if (direction == 1) //if direction is currently 1 when fuction is called
        {
            direction = -1; //direction is set to -1. 
        } 
        else if (direction == -1) //if direction is currently -1 when function is called
        {
            direction = 1; //direction is set to 1. 
        }
        #endregion

        #region New Timer Value Selection
        int timerSelector = Random.Range(0, 4);             //selects a random number between 0 and 4
        float functionTimer = timerArray[timerSelector];    //sets float value equal to the selected array value. 
        #endregion

        Invoke("DonkeyDirection", functionTimer);
    }
}
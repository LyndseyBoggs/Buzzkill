using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingAttack : PlayerAttack {

    #region global variables
    [Tooltip("How far forward the attack will move.")]
    public float attackRange;
    bool forwardSting;//determines if the bee is moving forward
    //bool recoil;//determines if the bee is moving back
    //bool valuesSet;//false until values needed for movement are obtained
    Vector2 originalPosition;//original position the bee was at.
    Vector2 finalPosition;//the furthest the attack goes to

    #endregion


    // Use this for initialization
    protected override void Start () {
        base.Start();
        forwardSting = false;
        //recoil = false;
        //valuesSet = false;//values do not start set

	}
	
	// Update is called once per frame
	void Update () {
        //if the bee is attacking
        if (attackActive)
        {
            Attack();//call attack function for attack
        }
        //while not attacking
        else
        {
            originalPosition = tf.position;//sets the origin-point before bee attacks.
            forwardSting = true;//forward sting resets as first action
            //recoil = false;//recoil resets to false.
            //valuesSet = false;
        }

	}

    //the attack function
    void Attack()
    {
        finalPosition = (Vector2)(-tf.right * attackRange) + originalPosition;//set the direction for the attack to move
        
        /*
        //if the value for the final position is not set
        if (!valuesSet)
        {
            finalPosition = (Vector2)(-tf.right * attackRange) + originalPosition;//set the direction for the attack to move

            valuesSet = true;
        }
        */

        //if the forward sting is happening
        if (forwardSting)
        {
            if(projectileTF.position.x <= finalPosition.x)
            {
                forwardSting = false;
            }

        }
        //if the forward sting finished, it is recoiling
        else
        {

        }
    }


}

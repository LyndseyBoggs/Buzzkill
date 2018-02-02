using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingAttack : PlayerAttack {

    #region global variables
    [Tooltip("How far forward the attack will move.")]
    public float attackRange;
    bool forwardSting;//determines if the bee is moving forward
    Vector3 originalPosition;//original position the bee was at.
    Vector3 finalPosition;//the furthest the attack goes to

    #endregion


    // Use this for initialization
    protected override void Start () {
        base.Start();
        forwardSting = false;

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
        }

	}

    //the attack function
    void Attack()
    {
        finalPosition = (-tf.right * attackRange) + originalPosition;//set the direction for the attack to move


        //if the forward sting is happening
        if (forwardSting)
        {
            Vector3 direction = finalPosition - originalPosition;//set the direction to move
            direction.Normalize();//make it equal to 1 unit
            projectileTF.position += projectileSpeed * direction;//move projectile in that direction at determined speed
            
            //if projectile hits or passes the attack range
            if(projectileTF.position.x <= finalPosition.x)
            {
                forwardSting = false;//start recoil
            }

        }
        //if the forward sting finished, it is recoiling
        else
        {
            Vector3 direction = originalPosition - finalPosition;//set the direction to move
            direction.Normalize();//make it equal to 1 unit
            projectileTF.position += projectileSpeed * direction;//move projectile in that direction at determined speed
            //if the projectile returns to original (on screen) position.
            if (projectileTF.position.x >= originalPosition.x)
            {
                attackActive = false;//attack completes
            }
        }
    }


}

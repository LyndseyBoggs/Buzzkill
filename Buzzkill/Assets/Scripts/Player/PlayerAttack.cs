using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttack : MonoBehaviour {

    #region global variables
    protected Transform tf;//holds player transform
    [Tooltip("The GameObject that is moving when attack is performed.")]
    public GameObject projectile;//What is shot when button is pressed.
    [Tooltip("How quickly the entire attack happens.")]
    public float attackSpeed;
    [Tooltip("How quickly the projectile in the attack moves.")]
    public float projectileSpeed;
    protected Transform projectileTF;//the transform what what is used to attack
    protected internal bool attackActive;//true when attacking, false when not

    #endregion


    // Use this for initialization
    protected virtual void Start () {
        tf = this.GetComponent<Transform>();
        attackActive = false;//should not be attacking on startup.
	}
	
}

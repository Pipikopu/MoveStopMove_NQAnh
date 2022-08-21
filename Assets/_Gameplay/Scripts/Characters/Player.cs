using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IHit, ITarget
{
    // Player Variables
    [Header("Player Setting")]
    public Transform playerTransform;
    public Transform playerModel;
    public Rigidbody playerRb;

    // Joystick Variables
    [Header("Joystick")]
    public Canvas joystickCanvas;
    public JoytickController joystick;
    private float inputX;
    private float inputZ;

    // Move and Rotate
    [Header("Movement and Rotate")]
    private Vector3 movement;
    public float moveSpeed;
    public float rotateSpeed;
    private float angleToRotate;

    // Animator
    [Header("Animator")]
    public Animator playerAnimator;

    // Character Boundary
    [Header("Boundary")]
    public CharacterBoundary charBound;

    // Weapon
    [Header("Weapon")]
    public Weapon weapon;

    // Boolean Variables
    private bool canAttack;
    private bool isDead;
    private bool isWin;

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        inputX = 0;
        inputZ = 0;
        movement = Vector3.zero;

        canAttack = true;
        isDead = false;
        isWin = false;
    }

    private void Update()
    {
        if (!isDead && !isWin)
        {
            if (LevelManager.Ins.GetRemainNumOfBots() == 0)
            {
                Win();
            }
            else
            {
                Move();
            }
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    #region Move
    protected override void Move()
    {
        inputX = joystick.inputHorizontal();
        inputZ = joystick.inputVertical();

        if (inputX == 0 && inputZ == 0)
        {
            Stop();
            Attack();
        }
        else
        {
            SetRotation();
            SetMovement();
        }
    }

    private void Stop()
    {
        movement = Vector3.zero;
        playerAnimator.SetBool(Constant.ANIM_IS_IDLE, true);
    }

    private void SetRotation()
    {
        angleToRotate = Mathf.Rad2Deg * Mathf.Atan2(inputX, inputZ);
        playerModel.rotation = Quaternion.RotateTowards(playerModel.rotation, Quaternion.AngleAxis(angleToRotate, Vector3.up), rotateSpeed * Time.deltaTime);
    }

    private void SetMovement()
    {
        StopAttack();
        movement = new Vector3(inputX, 0, inputZ);
        playerAnimator.SetBool(Constant.ANIM_IS_IDLE, false);
        canAttack = true;
    }

    private void MoveCharacter(Vector3 direction)
    {
        playerRb.velocity = direction * moveSpeed * Time.deltaTime;
    }
    #endregion

    #region Attack
    protected override void Attack()
    {
        if (canAttack)
        {
            GameObject targetCharacter = charBound.GetTargetCharacter();
            if (targetCharacter != null)
            {
                canAttack = false;
                playerAnimator.SetBool(Constant.ANIM_IS_ATTACK, true);

                Vector3 directToTarget = targetCharacter.transform.position - playerTransform.position;
                RotateToTargetCharacter(directToTarget);

                weapon.Attack(playerModel, playerModel.gameObject);
                weapon.gameObject.SetActive(false);
                Invoke(nameof(StopAttack), 1f);
            }
        }
    }

    private void StopAttack()
    {
        playerAnimator.SetBool(Constant.ANIM_IS_ATTACK, false);
    }

    private void RotateToTargetCharacter(Vector3 directToTarget)
    {
        float xPos = directToTarget.x;
        float zPos = directToTarget.z;

        angleToRotate = Mathf.Rad2Deg * Mathf.Atan2(xPos, zPos);
        playerModel.rotation = Quaternion.AngleAxis(angleToRotate, Vector3.up);
    }
    #endregion

    #region Death
    public override void Death()
    {
        isDead = true;
        movement = Vector3.zero;
        playerAnimator.SetBool(Constant.ANIM_IS_DEAD, true);
        joystickCanvas.gameObject.SetActive(false);

        LevelManager.Ins.Lose();
        UIManager.Ins.GetUI(UIID.UICGameplay).Close();
        UIManager.Ins.OpenUI(UIID.UICFail);
    }

    public bool CanBeTargeted()
    {
        return !isDead;
    }

    public void DisableLockTarget() { }

    public void EnableLockTarget() { }
    #endregion

    #region Win
    public void Win()
    {
        isWin = true;
        movement = Vector3.zero;
        playerAnimator.SetBool(Constant.ANIM_IS_WIN, true);
        joystickCanvas.gameObject.SetActive(false);

        LevelManager.Ins.Win();
        UIManager.Ins.GetUI(UIID.UICGameplay).Close();
        UIManager.Ins.OpenUI(UIID.UICVictory);
    }
    #endregion
}

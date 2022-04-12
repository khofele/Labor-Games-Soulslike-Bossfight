using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    // all attacks
    private Attack attackFront = new Attack(10, 20);
    private Attack attackLeft = new Attack(10, 20);
    private Attack attackRight = new Attack(10, 20);
    private Attack attackFireHead = new Attack(10, 20);

    private Attack currentAttack = null;
    [SerializeField] private Animator animator = null;

    public Attack CurrentAttack { get => currentAttack; set => currentAttack = value; }
    public Attack AttackFront { get => attackFront; }
    public Attack AttackLeft { get => attackLeft; }
    public Attack AttackRight { get => attackRight; }
    public Attack AttackFireHead { get => attackFireHead; }
    public Animator Animator { get => animator; }
}

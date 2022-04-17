using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    // all attacks
    private Attack attackFront = new Attack(150, 200);
    private Attack attackLeft = new Attack(100, 150);
    private Attack attackRight = new Attack(100, 150);
    private Attack attackFireHead = new Attack(150, 250);
    private Attack attackWideFireHead = new Attack(200, 250);
    private Attack attackFly = new Attack(100, 150);

    private Attack currentAttack = null;

    public Attack CurrentAttack { get => currentAttack; set => currentAttack = value; }
    public Attack AttackFront { get => attackFront; }
    public Attack AttackLeft { get => attackLeft; }
    public Attack AttackRight { get => attackRight; }
    public Attack AttackFireHead { get => attackFireHead; }
    public Attack AttackWideFireHead { get => attackWideFireHead; }
    public Attack AttackFly { get => attackFly; }
}

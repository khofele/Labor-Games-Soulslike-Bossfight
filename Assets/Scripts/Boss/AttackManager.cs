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
    private Attack attackFlyFireHead = new Attack(200, 250);
    private Attack attackFly = new Attack(100, 150);
    private Attack attackFlyWideFireHead = new Attack(200, 300);
    private Attack attackFlyBreatheFire = new Attack(300, 450);

    private Attack currentAttack = null;

    public Attack CurrentAttack { get => currentAttack; set => currentAttack = value; }
    public Attack AttackFront { get => attackFront; }
    public Attack AttackLeft { get => attackLeft; }
    public Attack AttackRight { get => attackRight; }
    public Attack AttackFireHead { get => attackFireHead; }
    public Attack AttackFlyFireHead { get => attackFlyFireHead; }
    public Attack AttackFlyWideFireHead { get => attackFlyWideFireHead; }
    public Attack AttackFly { get => attackFly; }

    public Attack AttackFlyBreatheFire { get => attackFlyBreatheFire; }
}

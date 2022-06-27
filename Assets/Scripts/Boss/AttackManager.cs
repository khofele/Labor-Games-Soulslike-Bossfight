using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    // boss attacks
    private Attack attackFront = new Attack(150, 250);
    private Attack attackLeft = new Attack(100, 200);
    private Attack attackRight = new Attack(100, 200);
    private Attack attackFireHead = new Attack(200, 300);
    private Attack attackFlyBreatheFire = new Attack(300, 400);
    private Attack attackFlyBreatheFirePoison = new Attack(400, 500);
    private Attack attackFlyBreatheFireMagic = new Attack(500, 600);
    private Attack nullAttack = new Attack();

    private Attack currentAttack = null;

    public Attack CurrentAttack { get => currentAttack; set => currentAttack = value; }
    public Attack AttackFront { get => attackFront; }
    public Attack AttackLeft { get => attackLeft; }
    public Attack AttackRight { get => attackRight; }
    public Attack AttackFireHead { get => attackFireHead; }
    public Attack AttackFlyBreatheFire { get => attackFlyBreatheFire; }
    public Attack AttackFlyBreatheFirePoison { get => attackFlyBreatheFirePoison; }    
    public Attack AttackFlyBreatheFireMagic { get => attackFlyBreatheFireMagic; }

    public Attack NullAttack { get => nullAttack; }

    private void Start()
    {
        currentAttack = nullAttack;
    }
}

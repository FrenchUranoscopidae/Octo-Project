using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "Octo-Project-master/Scripts/Idle", order = 1)]
    class IdleState : EnemyStateMachine
    {
        public override bool EnterState()
        {
            base.EnterState();
            Debug.Log("Entered idle state");
            return true;
        }

        public override void UpdateState()
        {
            Debug.Log("Updating idle state");
        }

        public override bool ExitState()
        {
            base.ExitState();
            Debug.Log("Exiting idle state");
            return true;
        }
    }
}

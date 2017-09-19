namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {
        public Agent()
        {
            lastDirection = directions.down;
            IShouldBeMovingRight = true;
        }
        public Room CurrentRoom { get; set; }
        public bool ActionSuccess { get; set; }
        private Actions.actions lastAction { get; set; }
        private enum directions { up, down, left, right }
        private directions lastDirection { get; set; }
        private bool IShouldBeMovingRight { get; set; }

        public Actions.actions DecideAction(ActionResult result)
        {
            Actions.actions action;
            CurrentRoom = result.ActionRoom;
            ActionSuccess = result.ActionSuccess;
            action = Actions.actions.none;

            if (CurrentRoom.IsDirty)
            {
                action = Actions.actions.clean;
                Console.WriteLine("cleaning");
            }
            else
            {
                if (result.ActionSuccess && IShouldBeMovingRight)
                {
                    action = Actions.actions.moveright;
                    lastDirection = directions.right;
                    Console.WriteLine("Moving Right");
                }
                else if (result.ActionSuccess && !IShouldBeMovingRight)
                {
                    action = Actions.actions.moveleft;
                    lastAction = Actions.actions.moveleft;
                    lastDirection = directions.left;
                    Console.WriteLine("Moving Left");
                }
                else if (!result.ActionSuccess && lastAction != Actions.actions.moveup)
                {
                    action = Actions.actions.moveup;
                    lastAction = Actions.actions.moveup;
                    IShouldBeMovingRight = !IShouldBeMovingRight;
                    Console.WriteLine("Moving up");
                }
            }
            lastAction = action;
            return action;

        }
    }
}
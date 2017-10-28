namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {
        public Agent()
        {
        }

        public Actions.actions DecideAction(Room room)
        {
            Actions.actions action;
            var CurrentRoom = room;
            action = Actions.actions.none;

            if (CurrentRoom.IsDirty)
            {
                action = Actions.actions.clean;
                Console.WriteLine("cleaning");
            }
            return action;

        }
    }
}
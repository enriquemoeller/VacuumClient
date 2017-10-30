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

        public GameEngine.AgentActions DecideAction(Room room)
        {
            GameEngine.AgentActions action;
            var CurrentRoom = room;
            action = GameEngine.AgentActions.NONE;

            if (CurrentRoom.IsDirty)
            {
                action = GameEngine.AgentActions.CLEAN;
                Console.WriteLine("cleaning");
            }
            return action;

        }
    }
}
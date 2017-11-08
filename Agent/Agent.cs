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

        public AgentAction DecideAction(Room room)
        {
            AgentAction action;

            bool isDirty = room.IsDirty;

            List<int> moveSet = new List<int> { 0, 1, 2, 3 };
            
            Random rnd = new Random();

            if (room.YAxis == 0)
            {
                moveSet.RemoveAt(0);
            }
            
            if (room.XAxis == 0)
            {
                if (moveSet.Count > 3)
                {
                    moveSet.RemoveAt(2);
                }
                else
                {
                    moveSet.RemoveAt(1);
                }
            }

            int index = rnd.Next(0, moveSet.Count);

            int direction = moveSet[index];
            
            if (isDirty)
            {
                action = AgentAction.CLEAN;
            }
            else
            {
                action = (AgentAction)direction;
            }
            return action;
        }
    }
}
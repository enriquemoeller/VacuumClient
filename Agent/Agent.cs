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

            if (isDirty)
            {
                action = AgentAction.CLEAN;
            }

            else
            {
                List<int> moveSet = new List<int> { 0, 1, 2, 3 };
                
                Random rnd = new Random();

                if (room.YAxis == 0)
                {
                    moveSet.Remove(0);
                }
                
                if (room.XAxis == 0)
                {
                    moveSet.Remove(2);
                }

                int index = rnd.Next(0, moveSet.Count);

                int direction = moveSet[index];
            
                action = (AgentAction)direction;
            }
            return action;
        }
    }
}
namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {
        ActionResult actionResult = new ActionResult();
        public Agent(AreaMap map)
        {
            _map = map;
        }
        private AreaMap _map { get; set; }
        public Room CurrentRoom { get; set; }

        public Actions.actions DoAction(ActionResult result)
        {
            Actions.actions action;
            CurrentRoom = result.ActionRoom;
            //should send an action and receive the result
            Actions availibleActions = new Actions(_map);
            if(CurrentRoom.IsDirty)
            {
                action = Actions.actions.clean;
                Console.WriteLine("cleaning");
            }
            else
            {
                action = Actions.actions.moveright;
                Console.WriteLine("Moving Right");
            }

            return action;

        }
    }
}
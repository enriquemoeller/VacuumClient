namespace IntelligentVacuum.Client
{
    using System;
    using Agent;
    using Environments;

    public class Client
    {

        public void init(int xAxisLenght, int yAxisLenght)
        {
            var map = new Environments.AreaMap(xAxisLenght, yAxisLenght);
            var actionResult = new ActionResult();
            var agent = new Agent(map);
            var Actions = new Actions(map);
            Room agentCurrentRoom = new Room();
            agentCurrentRoom = map.rooms.Find(x => x.XAxis == 1 && x.YAxis == 1);
            actionResult.ActionRoom = agentCurrentRoom;
            actionResult.ActionSuccess = true;
            for(int i = 1; i<10; i++)
            {
                //should return a action the agent wants to take

                var agentAction = agent.DoAction(actionResult);
                actionResult = Actions.AvailableActions(agentAction, agentCurrentRoom);
                agentCurrentRoom = actionResult.ActionRoom;
                //should return result of the action taken
            }
        }
    }
}
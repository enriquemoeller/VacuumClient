namespace IntelligentVacuum.Client
{
    using System;
    using Agent;
    using Environments;

    public class Client
    {

        public void Init(int xSize, int ySize, int rounds)
        {
            var map = new Environments.AreaMap(xSize, ySize, .1f);
            var actionResult = new ActionResult(map.AgentRoom);
            var agent = new Agent();
            var engine = new GameEngine(map);
            Room agentCurrentRoom = map.Rooms[0,0];
            actionResult.LookResultRoom = agentCurrentRoom;
            actionResult.ActionSuccess = true;
            for(int i = 0; i < rounds; i++)
            {
                var agentAction = agent.DecideAction(agentCurrentRoom);
                actionResult = engine.DoAction(agentAction, agentCurrentRoom);
                actionResult.CurrentAction = agentAction;
                agentCurrentRoom = actionResult.CurrentRoom;
            }
        }
    }
}
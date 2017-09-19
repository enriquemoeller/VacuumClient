namespace IntelligentVacuum.Client
{
    using System;
    using Agent;
    using Environments;

    public class Client
    {

        public void init(int xAxisLenght, int yAxisLenght, int rounds)
        {
            var map = new Environments.AreaMap(xAxisLenght, yAxisLenght);
            var actionResult = new ActionResult();
            var agent = new Agent(map);
            var game = new Gamification();
            var Actions = new Actions(map);
            Room agentCurrentRoom = new Room();
            agentCurrentRoom = map.rooms.Find(x => x.XAxis == 1 && x.YAxis == 1);
            actionResult.ActionRoom = agentCurrentRoom;
            actionResult.ActionSuccess = true;
            for(int i = 1; i<rounds; i++)
            {
                //add gamifaction 
                //should return a action the agent wants to take
                var agentAction = agent.DecideAction(actionResult);
                actionResult = Actions.AvailableActions(agentAction, agentCurrentRoom);
                actionResult.CurrentAction = agentAction;
                agentCurrentRoom = actionResult.CurrentRoom;
                game.KeepScore(agentAction, actionResult, map);
            }
            Console.WriteLine("Your final score was: {0}", game.GetFinalScore(xAxisLenght, yAxisLenght, rounds));
        }
    }
}
namespace IntelligentVacuum.Client
{
    using System;
    using Environments;

    public class Gamification
    {
        public Gamification()
        {
            
        }
        public int TotalScore { get; set; }
        public int NumberOfTurns { get; set; }

        public int KeepScore(Actions.actions action, ActionResult actionResult, AreaMap map)
        {
            var CurrentActionCost = GetCurrentActionCost(action);
            if(!actionResult.ActionSuccess)
            {
                CurrentActionCost += 15;
            }
            TotalScore += CurrentActionCost;
            foreach(Room room in map.rooms)
            {
                if(room.IsDirty)
                {
                    TotalScore += 1;
                }
            }
            return CurrentActionCost;
        }

        public int GetCurrentActionCost(Actions.actions actions)
        {
            int actionCost = 0;
            switch (actions)
            {
                case Actions.actions.moveup:
                    actionCost = 5;
                    break;
                case Actions.actions.movedown:
                    actionCost = 5;
                    break;
                case Actions.actions.moveleft:
                    actionCost = 5;
                    break;
                case Actions.actions.moveright:
                    actionCost = 5;
                    break;
                case Actions.actions.clean:
                    actionCost = -10;
                    break;
                case Actions.actions.lookup:
                    actionCost = 3;
                    break;
                case Actions.actions.lookdown:
                    actionCost = 3;
                    break;
                case Actions.actions.lookright:
                    actionCost = 3;
                    break;
                case Actions.actions.lookleft:
                    actionCost = 3;
                    break;
                case Actions.actions.none:
                    actionCost = 0;
                    break;
                default:
                    actionCost = 15;
                    break;
            }
            return actionCost;
        }
        public int GetFinalScore(int x, int y, int rounds)
        {
            return TotalScore = (TotalScore/(x*y*3));
        }
    }
}
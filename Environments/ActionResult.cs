namespace IntelligentVacuum.Environments
{
    using System;
    using System.Collections.Generic;

    public class ActionResult
    {
        public bool ActionSuccess { get; set; }
        public Room ActionRoom { get; set; }
        public Room CurrentRoom { get; set; }
        public Actions.actions CurrentAction { get; set; }
    }
}
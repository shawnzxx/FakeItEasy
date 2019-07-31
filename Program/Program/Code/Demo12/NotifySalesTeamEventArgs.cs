using System;

namespace PluralSight.FakeItEasy.Code.Demo12
{
    public class NotifySalesTeamEventArgs : EventArgs
    {
        public string Name { get; set; }

        public NotifySalesTeamEventArgs(string name)
        {
            Name = name;
        }
    }
}
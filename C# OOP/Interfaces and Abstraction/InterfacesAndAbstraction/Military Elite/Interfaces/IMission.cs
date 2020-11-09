using Military_Elite.Enumeration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }

        MissionStateEnum MissionStateEnum { get; }

        void CompleteMission(string missionName);
    }
}

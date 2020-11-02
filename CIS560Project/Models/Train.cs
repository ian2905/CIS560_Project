using System;

namespace CIS560Project.Models
{
    public class Train
    {
        public int TrainID { get; }
        public string Name { get; }
        public string Company { get; }
        public string Driver { get; }
        public int BaseSpeed { get; }
        public int CarCapacity { get; }

        public Train(int trainID, string name, string company, string driver, int baseSpeed, int carCapacity)
        {
            TrainID = trainID;
            Name = name;
            Company = company;
            Driver = driver;
            BaseSpeed = baseSpeed;
            CarCapacity = carCapacity;
        }
    }
}

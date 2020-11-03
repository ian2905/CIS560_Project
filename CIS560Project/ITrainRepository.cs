using CIS560Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS560Project
{
    public interface ITrainRepository
    {
        Train CreateTrain(string name, string company, string driver, int baseSpeed, int carCapacity);


    }
}

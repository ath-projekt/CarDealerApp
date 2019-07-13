using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public interface IOpinionRepo
    {
        void AddOpinion(Opinion opinion);
        int GetNewOpinionId();
    }
}

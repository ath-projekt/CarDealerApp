using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Database;

namespace CarDealer.Models
{
    public class OpinionRepo : IOpinionRepo
    {
        private readonly DatabaseContext _databaseContext;

        public OpinionRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddOpinion(Opinion opinion)
        {
            _databaseContext.Opinions.Add(opinion);
            _databaseContext.SaveChanges();
        }

        public int GetNewOpinionId()
        {
            if (_databaseContext.Opinions.Any())
            {
                return _databaseContext.Opinions.Select(x => x.Id).Max() + 1;
            }
            else
            {
                return 1;
            }
            
        }
    }
}

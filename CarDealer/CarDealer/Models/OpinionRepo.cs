using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class OpinionRepo : IOpinionRepo
    {
        private readonly AppDBContext _appDBContext;

        public OpinionRepo(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public void AddOpinion(Opinion opinion)
        {
            _appDBContext.Opinions.Add(opinion);
            _appDBContext.SaveChanges();
        }
    }
}

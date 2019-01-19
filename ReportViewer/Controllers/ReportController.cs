using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepaidSystemContext.Entity;
using ReportViewer.Models;

namespace ReportViewer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly PrepaidSystemContext.PrepaidSystemContext prepaidSystemContext;

        public ReportController(PrepaidSystemContext.PrepaidSystemContext prepaidSystemContext)
        {
            this.prepaidSystemContext = prepaidSystemContext;
        }

        // GET: api/Report/getBalanceChangeInPeriod/{startDate}/{endDate}
        [HttpGet("getBalanceChangeInPeriod/{startDate}/{endDate}")]
        public decimal GetBalanceChangeInPeriod(DateTime startDate, DateTime endDate)
        {           
            return this.prepaidSystemContext.GetBalanceChangeInPeriod(startDate, endDate);
        }

        // GET: api/Report/getBalanceChange
        [HttpGet("getBalanceChange")]
        public decimal GetBalanceChange()
        {
            return this.prepaidSystemContext.GetBalanceChange();
        }

        // GET: api/Report/getUserTypes/{roleTypeId}
        [HttpGet("getUserTypes/{roleTypeId}")]
        public int GetUserTypes(int roleTypeId)
        {
            return this.prepaidSystemContext.GetUserTypes(roleTypeId);
        }

        // GET: api/Report/getNumberOfRidesInPeriod/lineId/startDate/endDate
        [HttpGet("getNumberOfRidesInPeriod/{lineId}/{startDate}/{endDate}")]
        public int GetNumberOfRidesInPeriod(int lineId, DateTime startDate, DateTime endDate)
        {
            return this.prepaidSystemContext.GetNumberOfRidesInPeriod(lineId, startDate, endDate);
        }

        // GET: api/Report/getUNumberOfRides/lineId
        [HttpGet("getNumberOfRides/{lineId}")]
        public int GetNumberOfRides(int lineId)
        {
            return this.prepaidSystemContext.GetNumberOfRides(lineId);
        }

        // GET: api/Report/getBusLines
        [HttpGet("getBusLines")]
        public IEnumerable<LineModel> GetBusLines()
        {
            return this.prepaidSystemContext.Line.Select(l => new LineModel()
            {
                Id = l.Id,
                Name = l.Name
            }).OrderBy(n => n.Name).ToList();
        }

        // GET: api/Report/getNumberOfPassengers/startDate/endDate
        [HttpGet("getNumberOfPassengersInPeriod/{startDate}/{endDate}")]
        public int GetNumberOfPassengersInPeriod(DateTime startDate, DateTime endDate)
        {
            return this.prepaidSystemContext.GetNumberOfPassengersInPeriod(startDate, endDate);
        }

        // GET: api/Report/getNumberOfPassengers
        [HttpGet("getNumberOfPassengers")]
        public int GetNumberOfPassenegers()
        {
            return this.prepaidSystemContext.GetNumberOfPassengers();
        }
    }
}

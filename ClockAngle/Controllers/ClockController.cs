#region "Import Namespaces"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace ClockAngle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClockController : ControllerBase
    {    

        [HttpGet]
        public IActionResult Get(double h, double m)
        {
            try
            {
               return Ok("The calcualted angle is " + calcAngle(h,m).ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
           
        }

        #region "calcAngle"
        /// <summary>
        /// This method takes the hour and Mins value as input and returns the calculted angles value
        /// </summary>
        /// <param name="h">hours</param>
        /// <param name="m">mins</param>
        /// <returns>angles</returns>
        private int calcAngle(double h, double m)
        {
            // validate the input
            if (h < 0 || m < 0 ||
                h > 12 || m > 60)
                Console.Write("Wrong input");

            if (h == 12)
                h = 0;

            if (m == 60)
            {
                m = 0;
                h += 1;
                if (h > 12)
                    h = h - 12;
            }

            // Calculate the angles moved by hour and minute hands with reference to 3:00
            int hour_angle = (int)(0.5 * (h * 60 + m));
            int minute_angle = (int)(6 * m);

            // Find the difference between two angles
            int angle = Math.Abs(hour_angle - minute_angle);

            // smaller angle of two possible angles
            angle = Math.Min(360 - angle, angle);

            return angle;
        }

        #endregion
    }
}

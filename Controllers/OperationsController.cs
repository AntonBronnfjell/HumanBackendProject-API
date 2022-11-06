using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace HumanBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : Controller
    {

        [HttpGet]
        public string Get() => "This is operations controller, you can do all the arithmetic operations you want.";

        /// <summary>
        /// This is a GET operations.
        /// </summary>
        /// <param name="number">An integer number.</param>
        /// <param name="operand">The operand you whish to get an result.</param>
        /// <param name="anothernumber">The another integer number to do the operation.</param>
        /// <returns>String with the operation and result.</returns>
        [ActionName("Operation")]
        [HttpGet("{number}/{anothernumber}/{andanothernumber}")]
        public string AddGet(int number, char operand, int anothernumber) => Operation(operand, number, anothernumber);

        /// <summary>
        /// This is a POST operations.
        /// </summary>
        /// <param name="number">An integer number.</param>
        /// <param name="operand">The operand you whish to get an result.</param>
        /// <param name="anothernumber">The another integer number to do the operation.</param>
        /// <returns>String with the operation and result.</returns>
        [HttpPost]
        public string AddPost(int number, char operand, int anothernumber) => Operation(operand, number, anothernumber);


        private string Operation(char operand, int number, int anothernumber)
        {
            switch (operand)
            {
                case '+':
                    return string.Format("{0} {1} {2} = " + (number + anothernumber), number, operand, anothernumber);
                case '-':
                    return string.Format("{0} {1} {2} = " + (number - anothernumber), number, operand, anothernumber);
                case '*':
                    return string.Format("{0} {1} {2} = " + (number * anothernumber), number, operand, anothernumber);
                case '/':
                    return string.Format("{0} {1} {2} = " + (number / anothernumber), number, operand, anothernumber);
                default:
                    return string.Empty;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        Business.VeiculoBusiness buss = new Business.VeiculoBusiness();
        Utils.VeiculoConversor conv = new Utils.VeiculoConversor();

        [HttpPost]
        public ActionResult<List<Models.Response.VeiculoResponse>> Consultar(bool pcd)
        {
            try
            {
                return  conv.ParaListaResponse(buss.Consultar(pcd));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(ex.Message,404)
                );
            }
        }
    }
}
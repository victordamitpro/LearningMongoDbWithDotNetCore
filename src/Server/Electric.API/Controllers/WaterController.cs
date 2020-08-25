using Electric.Application.Commands;
using Electric.Application.Queries;
using Electric.Application.Responses;
using Electric.Core.Exeptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Electric.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WaterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDeviceQuery _filterDeviceQuery;

        public WaterController(IMediator mediator, IDeviceQuery filterDeviceQuery)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _filterDeviceQuery = filterDeviceQuery ?? throw new ArgumentNullException(nameof(filterDeviceQuery)); ;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DeviceResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DeviceResponse>> GetDetail(string id)
        {
            var result = await _filterDeviceQuery.GetDetailWater(id);

            if (result == null)
                throw new NotFoundExeption("Could not found record.");

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDevice([FromBody] CreateWaterMetterCommand command)
        {
            var duplicateElectric = await _filterDeviceQuery.GetDuplicateWaterItem(command.SeriaNumber);

            if (duplicateElectric != null)
                throw new ConflictExeption("Can not insert same record.");

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Response<Unit>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateElectric(UpdateWaterMetterCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            var deleteElectricCommand = new DeleteWaterMetterCommand { Id = id };

            var result = await _mediator.Send(deleteElectricCommand);

            return Ok(result);
        }
    }
}

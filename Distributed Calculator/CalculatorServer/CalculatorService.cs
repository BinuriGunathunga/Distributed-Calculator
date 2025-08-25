using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using CalculatorServer;

namespace CalculatorServer.Services
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly VectorClock _vectorClock = new();
        private readonly string _nodeId = "Server1";

        public override async Task<CalculationResponse> Square(CalculationRequest request, ServerCallContext context)
        {
            _vectorClock.Merge(request.VectorClock.ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
            _vectorClock.Increment(_nodeId);

            await Task.Delay(Random.Shared.Next(2000, 5000));

            if (SimulateError(request.Number))
            {
                _vectorClock.Rollback(_nodeId);
                return new CalculationResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Simulated failure or negative input",
                    VectorClock = { _vectorClock.GetClock() }
                };
            }

            return new CalculationResponse
            {
                Result = request.Number * request.Number,
                IsSuccess = true,
                VectorClock = { _vectorClock.GetClock() }
            };
        }

        private bool SimulateError(int number)
        {
            return number < 0 || Random.Shared.Next(4) == 0;
        }

   
    }
}

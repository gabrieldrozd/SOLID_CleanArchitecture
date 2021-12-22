using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);

            if (leaveAllocation == null)
                throw new Exception();

            await _leaveAllocationRepository.Delete(leaveAllocation);

            return Unit.Value;
        }
    }
}

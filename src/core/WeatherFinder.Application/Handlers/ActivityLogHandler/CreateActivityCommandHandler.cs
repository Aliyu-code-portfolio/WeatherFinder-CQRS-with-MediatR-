using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Application.Commands.ActivityLogCommand;
using WeatherFinder.Domain.Models;
using WeatherFinder.Persistence.Repository.Abstractions;
using WeatherFinder.Shared.DTOs.Request;
using WeatherFinder.Shared.DTOs.Response;

namespace WeatherFinder.Application.Handlers.ActivityLogHandler
{
    internal sealed class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, ActivityLogResponse>
    {
        private readonly IActivityLogRepository activityLogRepository;
        private readonly IMapper mapper;

        public CreateActivityCommandHandler(IActivityLogRepository activityLogRepository, IMapper Mapper)
        {
            this.activityLogRepository = activityLogRepository;
            mapper = Mapper;
        }

        public async Task<ActivityLogResponse> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = mapper.Map<ActivityLog>(request.activityRequest);
            activityLogRepository.CreateActivityLog(activity);
            activityLogRepository.SaveChangesAsync();
            var activityResponse = mapper.Map<ActivityLogResponse>(activity);
            return activityResponse;
        }
    }
}

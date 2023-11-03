using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Application.Queries.ActivityLogQuery;
using WeatherFinder.Persistence.Repository.Abstractions;
using WeatherFinder.Shared.DTOs.Response;

namespace WeatherFinder.Application.Handlers.ActivityLogHandler
{
    internal sealed class GetActivityByIdHandler : IRequestHandler<GetActivityByIdQuery, ActivityLogResponse>
    {
        private IActivityLogRepository activityLogRepository;
        private IMapper mapper;

        public GetActivityByIdHandler(IActivityLogRepository activityLogRepository, IMapper mapper)
        {
            this.activityLogRepository = activityLogRepository;
            this.mapper = mapper;
        }

        public async Task<ActivityLogResponse> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
        {
            var activity = await activityLogRepository.GetActivityLogById(request.id, request.trackChanges);
            var activityDto = mapper.Map<ActivityLogResponse>(activity);
            return activityDto;
        }
    }
}

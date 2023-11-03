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
    internal sealed class GetAllUserActivityHandler : IRequestHandler<GetAllUserActivityQuery, IEnumerable<ActivityLogResponse>>
    {
        private IActivityLogRepository activityLogRepository;
        private IMapper mapper;

        public GetAllUserActivityHandler(IActivityLogRepository activityLogRepository, IMapper mapper)
        {
            this.activityLogRepository = activityLogRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ActivityLogResponse>> Handle(GetAllUserActivityQuery request, CancellationToken cancellationToken)
        {
            var activities = await activityLogRepository.GetAllUserActivityLog(request.userId, request.trackChanges);
            var activitiesDto = mapper.Map<IEnumerable<ActivityLogResponse>>(activities);
            return activitiesDto;
        }
    }
}

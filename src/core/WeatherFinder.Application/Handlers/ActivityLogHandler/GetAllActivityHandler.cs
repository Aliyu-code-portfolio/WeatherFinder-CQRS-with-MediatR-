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
    internal sealed class GetAllActivityHandler : IRequestHandler<GetAllActivityQuery, IEnumerable<ActivityLogResponse>>
    {
        private IActivityLogRepository activityLogRepository;
        private IMapper mapper;

        public GetAllActivityHandler(IActivityLogRepository activityLogRepository, IMapper mapper)
        {
            this.activityLogRepository = activityLogRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ActivityLogResponse>> Handle(GetAllActivityQuery request, CancellationToken cancellationToken)
        {
            var activities = await activityLogRepository.GetAllActivityLog(request.trackChanges);
            var activitiesDtos = mapper.Map<IEnumerable<ActivityLogResponse>>(activities);
            return activitiesDtos;
        }
    }
}

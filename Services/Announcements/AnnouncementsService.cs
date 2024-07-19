using AutoMapper;
using DormAPI.Commands.Announcements.AddAnouncement;
using DormAPI.Commands.Announcements.DeleteAnnouncement;
using DormAPI.Commands.Announcements.UpdateAnnouncement;
using DormAPI.Data.Repository.Announcements;
using DormAPI.Exceptions;
using DormAPI.Models.Dto;
using DormAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Services.Announcements
{
    public class AnnouncementsService : BaseService, IAnnouncementsService
    {
        private readonly IAnnouncementsRepository _repository;

        public AnnouncementsService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IAnnouncementsRepository repository) : base(mapper, httpContextAccessor)
        {
            _repository = repository;
        }

        public async Task<AnnouncementDto> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken ct)
        {
            var announcement = _mapper.Map<Announcement>(request);

            announcement.ManagerId = GetPersonIdFromToken();

            _repository.Create(announcement);
            await _repository.CommitAsync(ct);

            return _mapper.Map<AnnouncementDto>(announcement);
        }

        public async Task<AnnouncementDto> DeleteAnnouncementAsync(DeleteAnnouncementRequest request, CancellationToken ct)
        {
            var announcement = await _repository
                .GetByIdAsync(request.Id)
                ?? throw new NotFoundException();

            _repository.Delete(announcement);
            await _repository.CommitAsync(ct);

            return _mapper.Map<AnnouncementDto>(announcement);
        }

        public async Task<IEnumerable<AnnouncementDto>> GetAnnouncementsAsync(CancellationToken ct)
        {
            var announcements = await _repository
                .GetAll()
                .Include(a => a.Manager)
                .OrderByDescending(a => a.AddedTS)
                .ToListAsync();

            return _mapper.Map<List<AnnouncementDto>>(announcements);
        }

        public async Task<AnnouncementDto> UpdateAnnouncementAsync(UpdateAnnouncementRequest request, CancellationToken ct)
        {
            var id = request.Id;
            var announcement = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Announcement), id);

            announcement.Title = request.Title;
            announcement.Content = request.Content;

            _repository.Update(announcement);
            await _repository.CommitAsync(ct);

            return _mapper.Map<AnnouncementDto>(announcement);
        }
    }
}

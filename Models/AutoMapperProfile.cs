using AutoMapper;
using DormAPI.Commands.Announcements.AddAnouncement;
using DormAPI.Commands.Announcements.UpdateAnnouncement;
using DormAPI.Commands.Users.CreateUser;
using DormAPI.Models.Dto;
using DormAPI.Models.Entities;
using DormAPI.Models.Enums;

namespace DormAPI.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(d => d.NormalizedUserName, o => o.MapFrom(s => s.UserName.ToUpper()))
                .ForMember(d => d.NormalizedEmail, o => o.MapFrom(s => s.Email.ToUpper()));

            CreateMap<Person, DtoNameId>()
                .IncludeAllDerived();

            CreateMap<AnnouncementDto, Announcement>()
                .ForMember(d => d.ManagerId, o => o.MapFrom(s => s.Author.Id));

            CreateMap<Announcement, AnnouncementDto>()
                .ForMember(d => d.Author, o => o.MapFrom(s => s.Manager));

            CreateMap<AddAnnouncementRequest, Announcement>();
            CreateMap<UpdateAnnouncementRequest, Announcement>();

            CreateMap<Room, RoomSimpleDto>();
            CreateMap<Room, RoomDto>()
                .ForMember(d => d.Problems, o => o.MapFrom(s => s.Students.SelectMany(s => s.Problems).Where(p => p.ProblemState > ProblemStatus.Resolved)));

            CreateMap<Item, ItemDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => 
                    s.Problems.Count != 0 ? s.Problems.FirstOrDefault(p => p.ProblemState != ProblemStatus.Resolved).ProblemState : ProblemStatus.Resolved
                ));


            CreateMap<Item, DtoNameId>();

            CreateMap<Conservator, DtoNameId>();

            CreateMap<Problem, ProblemDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.ProblemState));
                //.ForMember(d => d.Item, o => o.MapFrom(s => s.Item));
                //.ForMember(d => d.Conservator, o => o.MapFrom(s => s.Conservator));

            CreateMap<DirectMessage, DirectMessageDto>()
                .ForMember(d => d.Receivers, o => o.MapFrom(s => s.DirectMessageStudents.Select(dms => dms.Student)))
                .ForMember(d => d.Author, o => o.MapFrom(s => s.Manager));

            CreateMap<Student, StudentDto>();

            CreateMap<Floor, FloorDto>();
        }
    }
}

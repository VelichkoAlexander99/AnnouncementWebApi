using AutoMapper;
using Domain.Models;
using WebApi.DTOs.Incoming;
using WebApi.DTOs.Outgoing;

namespace WebApi.MappingProfiles
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<Announcement, AnnouncementDto>()
             .ConstructUsing(x => new AnnouncementDto()
             {
                 Id = x.Id,
                 Number = x.Number,
                 UserId = x.UserId,
                 Text = x.Text,
                 ImageUri = x.ImageUri,
                 Rating = x.Rating,
                 Created = x.Created,
                 Expity = x.Expity,
             });

            CreateMap<AnnouncementDto, Announcement>()
            .ConstructUsing(x => new Announcement()
            {
                Id = x.Id,
                Number = x.Number,
                UserId = x.UserId,
                Text = x.Text,
                ImageUri = x.ImageUri,
                Rating = x.Rating,
                Created = x.Created,
                Expity = x.Expity,
            });

            CreateMap<AnnouncementForCreationDto, Announcement>()
            .ConstructUsing(x => new Announcement()
            {
                UserId = x.UserId,
                Text = x.Text,
                ImageUri = x.ImageUri,
                Rating = x.Rating,
                Created = DateTime.Now,
                Expity = x.Expity,
            });

            CreateMap<AnnouncementForUpdateDto, Announcement>()
            .ConstructUsing(x => new Announcement()
            {
                Text = x.Text,
                ImageUri = x.ImageUri,
                Rating = x.Rating,
                Created = x.Created,
                Expity = x.Expity,
            });
        }
    }
}

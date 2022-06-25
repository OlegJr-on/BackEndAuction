using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System.Linq;

namespace BLL
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            // mapping for Order and OrderModel
            CreateMap<Order, OrderModel>()
                .ForMember(rm => rm.OrderDetailsIds, r => r.MapFrom(x => x.OrderDetails.Select(rd => rd.Id)))
                .ReverseMap();


            // mapping for Lot and LotModel
            CreateMap<Lot, LotModel>()
                //.ForMember(l => l.Id, pr => pr.MapFrom(p => p.Id))
                //.ForMember(p => p.PhotoId, pr => pr.MapFrom(p => p. PhotoId))
                //.ForMember(p => p.Title, pr => pr.MapFrom(p => p.Title))
                //.ForMember(p => p.StartPrice, pr => pr.MapFrom(p => p.StartPrice))
                //.ForMember(p => p.MinRate, pr => pr.MapFrom(p => p.MinRate))
                //.ForMember(p => p.StartDate, pr => pr.MapFrom(p => p.StartDate))
                //.ForMember(p => p.EndDate, pr => pr.MapFrom(p => p.EndDate))
                //.ForMember(p => p.Status, pr => pr.MapFrom(p => p.Status))
                //.ForMember(p => p.CurrentPrice, pr => pr.MapFrom(p => p.CurrentPrice))
                .ForMember(od => od.OrderDetailsIds, opt => opt.MapFrom(p => p.OrderDetails.Select(od => od.Id)))
                .ReverseMap();

            //mapping for User and UserModel
            CreateMap<User, UserModel>()
                .ForMember(c => c.Id, cm => cm.MapFrom(x => x.Id))
                .ForMember(c => c.Name, cm => cm.MapFrom(x => x.Name))
                .ForMember(c => c.Surname, cm => cm.MapFrom(x => x.Surname))
                .ForMember(c => c.Location, cm => cm.MapFrom(x => x.Location))
                .ForMember(c => c.Email, cm => cm.MapFrom(x => x.Email))
                .ForMember(c => c.Password, cm => cm.MapFrom(x => x.Password))
                .ForMember(c => c.PhoneNumber, cm => cm.MapFrom(x => x.PhoneNumber))
                .ForMember(c => c.OrdersIds, cm => cm.MapFrom(x => x.Orders.Select(r => r.Id)))
                .ReverseMap();

            // mapping for OrderDetail and OrderDetailModel
            CreateMap<OrderDetail, OrderDetailModel>()
                .ReverseMap();


            //mapping for Photo and PhotoModel
            CreateMap<Photo, PhotoModel>()
                .ForMember(p => p.Id, pc => pc.MapFrom(i => i.Id))
                .ForMember(c => c.PhotoSrc, cat => cat.MapFrom(d => d.PhotoSrc))
                .ForMember(pr => pr.GroupOfPhoto, cat => cat.MapFrom(d => d.GroupOfPhoto))
                .ReverseMap();

        }

    }
}

using System;
using DAL.Data;
using BLL;
using BLL.Models;
using DAL.Repositories;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using BLL.Services;
using System.Collections.Generic;

namespace BackEndConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Role role = Role.Admin;
            Console.WriteLine(role.ToString());

            using (var db = new AuctionDbContext())
            {

                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new Automapper())));

                var unitofWork = new UnitOfWork(db);

                var userService = new UserService(unitofWork, mapper);
                var lotService = new LotService(unitofWork, mapper);
                var orderService = new OrderService(unitofWork, mapper);

                var user1 = new UserModel
                {
                    Name = "Vasil",
                    Surname = "Loma",
                    Location = "Ukraine,Kyiv",
                    Email = "mandra@gmail.com",
                    Password = "123",
                    AccessLevel = Role.Admin,
                    PhoneNumber = "095-937-3031"
                };
                var user2 = new UserModel
                {
                    Name = "Oleksandr",
                    Surname = "Usyk",
                    Location = "Ukraine,Kyiv",
                    Email = "mandra@gmail.com",
                    Password = "12344",
                    AccessLevel = Role.Admin,
                    PhoneNumber = "095-937-3031"
                };

                var user3 = new UserModel
                {
                    Name = "Dasha",
                    Surname = "Trembom",
                    Location = "Ukraine,Rivne",
                    Email = "da44a@gmail.com",
                    Password = "12344999",
                    AccessLevel = Role.RegUser,
                    PhoneNumber = "095-937-4040"
                };

                //var getUser = userService.GetByIdAsync(6).Result;

                //getUser.Name = "Daria";

                // userService.UpdateAsync(getUser);

                //////////////////
                //var lot = lotService.GetByIdAsync(10).Result;

                //lot.Title = "Honda civic 2012";

                //lotService.UpdateAsync(lot);

                //////////////////////////////
                //var order = orderService.GetByIdAsync(4).Result;

                //order.UserId = 6;

                //orderService.UpdateAsync(order);

                //////////////////////////////////
                //var photos = lotService.GetAllPhotosAsync().Result;

                //var photo1 = photos.FirstOrDefault();

                //photo1.PhotoSrc = "CarPhoto";

                //lotService.UpdatePhotoAsync(photo1);

                ///////////////////////////////////
                orderService.AddLotAsync(3,4);
            }

            //using (var db = new AuctionDbContext())
            //{

            //    //db.Database.EnsureDeleted();
            //    //db.Database.EnsureCreated();

            //    var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new Automapper())));

            //    var unitofWork = new UnitOfWork(db);

            //    var userService = new UserService(unitofWork, mapper);

            //    var user1 = new UserModel
            //    {
            //        Name = "Vasil",
            //        Surname = "Loma",
            //        Location = "Ukraine,Kyiv",
            //        Email = "mandra@gmail.com",
            //        Password = "123",
            //        AccessLevel = Role.Admin,
            //        PhoneNumber = "095-937-3031"
            //    };
            //    var user2 = new UserModel
            //    {
            //        Name = "Oleksandr",
            //        Surname = "Usyk",
            //        Location = "Ukraine,Kyiv",
            //        Email = "mandra@gmail.com",
            //        Password = "12344",
            //        AccessLevel = Role.Admin,
            //        PhoneNumber = "095-937-3031"
            //    };
                
            //    var user3 = new UserModel
            //    {
            //        Name = "Dasha",
            //        Surname = "Trembom",
            //        Location = "Ukraine,Rivne",
            //        Email = "da44a@gmail.com",
            //        Password = "12344999",
            //        AccessLevel = Role.RegUser,
            //        PhoneNumber = "095-937-4040"
            //    };

            //    var lot1 = new LotModel
            //    {
            //        CurrentPrice = 2200,
            //        Title = "2016 BMW 1er 116i Advantage",
            //        Status = LotStatus.Created,
            //        MinRate = 50,
            //        StartDate = new DateTime(2022, 7, 20, 20, 0, 0),
            //        EndDate = new DateTime(2022, 7, 22, 20, 0, 0),
            //        StartPrice = 2000,
            //        PhotoId = 1
            //    };
            //    var lot2 = new LotModel
            //    {
            //        CurrentPrice = 2200,
            //        Title = "2012 BMW 3er 330i Luxury",
            //        Status = LotStatus.Created,
            //        MinRate = 100,
            //        StartDate = new DateTime(2022, 10, 20, 20, 0, 0),
            //        EndDate = new DateTime(2022, 10, 25, 20, 0, 0),
            //        StartPrice = 1600,
            //        PhotoId = 2
            //    };
                
            //    var lot3 = new LotModel
            //    {
            //        CurrentPrice = 2200,
            //        Title = "2017 Audi A5 SportBack",
            //        Status = LotStatus.Created,
            //        MinRate = 100,
            //        StartDate = new DateTime(2022, 7, 1, 20, 0, 0),
            //        EndDate = new DateTime(2022, 7, 15, 20, 0, 0),
            //        StartPrice = 3000,
            //        PhotoId = 2
            //    };
                
            //    var lot4 = new LotModel
            //    {
            //        CurrentPrice = 2200,
            //        Title = "Opel Vivaro 2015",
            //        Status = LotStatus.Created,
            //        MinRate = 100,
            //        StartDate = new DateTime(2022, 11, 1, 20, 0, 0),
            //        EndDate = new DateTime(2022, 11, 5, 20, 0, 0),
            //        StartPrice = 2100,
            //        PhotoId = 2
            //    };
            //    var lot5 = new LotModel
            //    {
            //        CurrentPrice = 2200,
            //        Title = "Toyota Camry 2015",
            //        Status = LotStatus.Created,
            //        MinRate = 100,
            //        StartDate = new DateTime(2022, 11, 1, 20, 0, 0),
            //        EndDate = new DateTime(2022, 11, 5, 20, 0, 0),
            //        StartPrice = 2100,
            //        PhotoId = 2
            //    };

            //    var lotService = new LotService(unitofWork, mapper);

            //    var photo3 = new PhotoModel
            //    {
            //        PhotoSrc = "From2",
            //        GroupOfPhoto = 2
            //    };
            //    var photo4 = new PhotoModel
            //    {
            //        PhotoSrc = "From 2",
            //        GroupOfPhoto = 2
            //    };
            //    var photo5= new PhotoModel
            //    {
            //        PhotoSrc = "Photo2",
            //        GroupOfPhoto = 3
            //    };

            //    //lotService.AddPhotoAsync(photo3);
            //    //lotService.AddPhotoAsync(photo4);
            //    //lotService.AddPhotoAsync(photo5);

            //    userService.AddAsync(user3);
            //    //userService.AddAsync(user2);


            //    //lotService.AddAsync(lot1);
            //    //lotService.AddAsync(lot2);
            //    //lotService.AddAsync(lot3);
            //    //lotService.AddAsync(lot4);
            //    //lotService.AddAsync(lot5);

            //    //FilterSearchModel filter = new FilterSearchModel
            //    //{
            //    //    MinPrice = 1000,
            //    //    MaxPrice = 2500,
            //    //    BeginningPeriod = new DateTime(2022,6,20),
            //    //    EndPeriod = new DateTime(2022,8,15)
            //    //};

               

            //    var ServiceOrder = new OrderService(unitofWork,mapper);

               

            //    var orderOleh2 = new OrderModel
            //    {
            //        Id = 5,
            //        OperationDate = DateTime.Now,
            //        UserId = 2,
            //        OrderDetailsIds = new List<int>()
            //        {   1,
            //            2
            //        }
            //    };

            //    ServiceOrder.AddAsync(orderOleh2);

            //    var od1 = new OrderDetail
            //    {
            //        Id = 1,
            //        LotId = 9,
            //        OrderId = 5,
            //        Status = LotDetailStatus.Bid_placed
            //    };
            //    var od2 = new OrderDetail
            //    {
            //        Id = 2,
            //        LotId = 10,
            //        OrderId = 5,
            //        Status = LotDetailStatus.Bid_placed
            //    };

            //    var orderDetRepo = new OrderDetailRepository(db);
            //    orderDetRepo.AddAsync(od1);
            //    orderDetRepo.AddAsync(od2);

            //    //var listOrder = ServiceOrder.GetOrderDetailsAsync(1).Result;

            //    //var order = ServiceOrder.GetByIdAsync(1).Result;


            //    //ServiceOrder.AddLotAsync(10,10);
            //    //ServiceOrder.RemoveLotAsync(10,10);


            //    //var opel = lotService.GetByIdAsync(4).Result;

            //    //opel.CurrentPrice = 3666;

            //    //lotService.UpdateAsync(opel);

            //    //var lot5 = new LotModel
            //    //{
            //    //    CurrentPrice = 1111,
            //    //    Title = "Opel Vivaro 2015",
            //    //    Status = LotStatus.Created,
            //    //    MinRate = 100,
            //    //    StartDate = new DateTime(2022, 11, 1, 20, 0, 0),
            //    //    EndDate = new DateTime(2022, 11, 5, 20, 0, 0),
            //    //    StartPrice = 2100,
            //    //    PhotoId = 2
            //    //};
            //    //lotService.AddAsync(lot5);

            //    //var updateLot = lotService.GetByIdAsync(1).Result;

            //    //updateLot.CurrentPrice = 3111;

            //    //lotService.UpdateAsync(updateLot);


            //    //var userFirst = userService.GetByIdAsync(1).Result;
            //    //userFirst.Name = "Mihailo";
            //    //userService.UpdateAsync(userFirst); 

            //    //var Listdate = ServiceOrder.GetOrdersByPeriodAsync(new DateTime(2022,6,19,15,21,45),
            //    //    new DateTime(2022, 6, 19, 15, 25, 00)).Result;

            //    //var orderRepo = new OrderRepository(db);
            //    //var oreder = orderRepo.GetByIdAsync(2).Result;
            //    //order.UserId = 1;

            //    //ServiceOrder.UpdateAsync(order);

            //    //var userRepo = new UserRepository(db);
            //    //var us = userRepo.GetByIdAsync(1).Result;
            //    //us.Location = "lviv";
            //    //userRepo.Update(us);

            //    //var user = userService.GetByIdAsync(1).Result;

            //    //user.Location = "Kharkiv";

            //    //userService.UpdateAsync(user);  

            //    //var users = userService.GetAllAsync().Result;

            //    //var userFromLot = userService.GetUsersByLotIdAsync(1).Result;

            //    //var listphoto = lotService.GetAllPhotosAsync().Result;

            //    //Console.WriteLine($"Name: {user.Name}");

            //}

            //using (AuctionDbContext db = new AuctionDbContext())
            //{
            //    //Add to db
            //    // пересоздаем базу данных
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();
            //var user1 = new User
            //{
            //    Name = "Oleh",
            //    Surname = "Mandra",
            //    Location = "Ukraine,Kyiv",
            //    Email = "mandra@gmail.com",
            //    Password = "123",
            //    AccessLevel = Role.Admin,
            //    PhoneNumber = "095-937-3031"
            //};

            //db.Users.Add(user1);

            //var photo1 = new Photo
            //{
            //    Id = 1,
            //    PhotoSrc = "Photo1"
            //};
            //var photo2 = new Photo
            //{
            //    Id = 2,
            //    PhotoSrc = "Photo2"
            //};
            //var photo3 = new Photo
            //{
            //    Id = 3,
            //    PhotoSrc = "Photo3"
            //};
            //db.Photos.AddRange(photo1, photo2, photo3);


            //var lot1 = new Lot
            //{

            //    Title = "2016 BMW 1er 116i Advantage",
            //    Status = LotStatus.Created,
            //    MinRate = 50,
            //    StartDate = new DateTime(2022, 6, 20, 20, 0, 0),
            //    EndDate = new DateTime(2022, 6, 22, 20, 0, 0),
            //    StartPrice = 1600,
            //    PhotoId = 1
            //};

            //db.Lots.Add(lot1);

            //ERROR
            //var orderOleh = new Order
            //{
            //    OperationDate = DateTime.Now,
            //    UserId = 1,
            //};
            //db.OrdersIds.Add(orderOleh);

            //var od = new OrderDetail
            //{
            //    LotId = 0,
            //    OrderId = 0,
            //    Status = LotDetailStatus.Bid_placed,
            //    Lot = db.Lots.FirstOrDefaultAsync().Result
            //};
            //db.OrderDetailsIds.Add(od);



            //    db.SaveChanges();
            //}

            //Console.WriteLine("Result:");

            //using (AuctionDbContext db = new AuctionDbContext())
            //{
            //    var user = db.Users.FirstOrDefaultAsync().Result;
            //    string dataOfUser = $"Id = {user.Id}\nName:{user.Name}\nSurname: {user.Surname}\nEmail = {user.Email}" +
            //        $"\nPassword: {user.Password}\nRole: {user.AccessLevel}" +
            //        $"\n\nUserLots:\n";
            //    Console.WriteLine(dataOfUser);

            //    var od = db.OrderDetailsIds.FirstOrDefaultAsync().Result;

            //    var lot = od.Lot;

            //    Console.WriteLine($"lot1: {lot.Title}");


            //}

            
        }









            //--------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------
            // About Date Time functionality
            //DateTime Start = DateTime.Now;//new DateTime(2022, 6, 15, 20, 0,0);

            //Console.Write("Input End date lot:\n Year(2022-2025):");
            //int year = int.Parse(Console.ReadLine());

            //Console.Write("Month(1-12):");
            //sbyte month = sbyte.Parse(Console.ReadLine());

            //Console.Write("Date(1-31):");
            //sbyte date = sbyte.Parse(Console.ReadLine());

            //Console.Write("Time(Hour / Min):");
            //sbyte hour = sbyte.Parse(Console.ReadLine());
            //sbyte min = sbyte.Parse(Console.ReadLine());

            //var End = new DateTime(year,month,date,hour,min,0);
            //var now = DateTime.Now;

            //if (Start < End) {
            //    Console.WriteLine($"Start:\n \tDate: {Start.ToShortDateString()}\n \tTime: {Start.ToShortTimeString()} ");
            //    Console.WriteLine($"\nEnd:\n \tDate: {End.ToShortDateString()}\n \tTime: {End.ToShortTimeString()} ");


            //    string message = now >= End ? "Time over" : "Bidding is underway";

            //    Console.WriteLine($"Satus lot: {message}");
            //}
            //else
            //{
            //    Console.WriteLine("Non corrrect date value!");
            //}
        
    }
}

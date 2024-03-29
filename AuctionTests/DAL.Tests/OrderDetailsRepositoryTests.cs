﻿using DAL.Data;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionTests.DAL.Tests
{
    [TestFixture]
    internal class OrderDetailRepositoryTests
    {
        [TestCase(1)]
        [TestCase(5)]
        public async Task OrderDetailRepository_GetByIdAsync_ReturnsSingleValue(int id)
        {
            using var context = new AuctionDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailRepository = new OrderDetailRepository(context);
            var orderDetail = await orderDetailRepository.GetByIdAsync(id);

            var expected = ExpectedOrdersDetails.FirstOrDefault(x => x.Id == id);

            Assert.That(orderDetail, Is.EqualTo(expected).Using(new OrderDetailEqualityComparer()), message: "GetByIdAsync method works incorrect");
        }

        [Test]
        public async Task OrderDetailRepository_GetAllAsync_ReturnsAllValues()
        {
            using var context = new AuctionDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailRepository = new OrderDetailRepository(context);
            var receiptDetails = await orderDetailRepository.GetAllAsync();

            Assert.That(receiptDetails, Is.EqualTo(ExpectedOrdersDetails).Using(new OrderDetailEqualityComparer()), message: "GetAllAsync method works incorrect");
        }

        [Test]
        public async Task OrderDetailRepository_AddAsync_AddsValueToDatabase()
        {
            using var context = new AuctionDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailRepository = new OrderDetailRepository(context);
            var orderDetail = new OrderDetail { Id = 6, OrderId = 2, LotId = 1 };

            await orderDetailRepository.AddAsync(orderDetail);
            await context.SaveChangesAsync();

            Assert.That(context.OrderDetails.Count(), Is.EqualTo(6), message: "AddAsync method works incorrect");
        }

        [Test]
        public async Task OrderDetailRepository_DeleteByIdAsync_DeletesEntity()
        {
            using var context = new AuctionDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailRepository = new OrderDetailRepository(context);

            await orderDetailRepository.DeleteByIdAsync(1);
            await context.SaveChangesAsync();

            Assert.That(context.OrderDetails.Count(), Is.EqualTo(4), message: "DeleteByIdAsync works incorrect");
        }

        [Test]
        public async Task OrderDetailRepository_Update_UpdatesEntity()
        {
            using var context = new AuctionDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailRepository = new OrderDetailRepository(context);
            var orderDetail = new OrderDetail
            {
                Id = 1,
                LotId = 1,
                OrderId = 1,
                Status = LotDetailStatus.Bid_placed
            };

            orderDetailRepository.Update(orderDetail);
            await context.SaveChangesAsync();

            Assert.That(orderDetail, Is.EqualTo(new OrderDetail
            {
                Id = 1,
                LotId = 1,
                OrderId = 1,
                Status = LotDetailStatus.Bid_placed
            }).Using(new OrderDetailEqualityComparer()), message: "Update method works incorrect");
        }

        [Test]
        public async Task OrderDetailRepository_GetAllWithDetailsAsync_ReturnsWithIncludedEntities()
        {
            using var context = new AuctionDbContext(UnitTestHelper.GetUnitTestDbOptions());

            var orderDetailRepository = new OrderDetailRepository(context);

            var orderDetails = await orderDetailRepository.GetAllWithDetailsAsync();
            var orderDetail = orderDetails.FirstOrDefault(x => x.Id == 1);

            Assert.That(orderDetails, Is.EqualTo(ExpectedOrdersDetails).Using(new OrderDetailEqualityComparer()), message: "GetAllWithDetailsAsync method works incorrect");
            Assert.That(orderDetail.Lot, Is.Not.Null, message: "GetByIdWithDetailsAsync method doesnt't return included entities");
            Assert.That(orderDetail.Order, Is.Not.Null, message: "GetByIdWithDetailsAsync method doesnt't return included entities");
            Assert.That(orderDetail.Lot.Photo, Is.Not.Null, message: "GetByIdWithDetailsAsync method doesnt't return included entities");
        }

        private static IEnumerable<OrderDetail> ExpectedOrdersDetails =>
            new[]
            {
                new OrderDetail
                {
                     Id = 1,
                    LotId = 1,
                    OrderId = 1,
                    Status = LotDetailStatus.Bid_placed
                },
                new OrderDetail
                {
                    Id = 2,
                    LotId = 2,
                    OrderId = 1,
                    Status = LotDetailStatus.Bid_placed
                },
                new OrderDetail
                {
                    Id = 3,
                    LotId = 2,
                    OrderId = 2,
                    Status = LotDetailStatus.Bid_placed
                },
                new OrderDetail {
                    Id = 4,
                    LotId = 1,
                    OrderId = 3,
                    Status = LotDetailStatus.Bid_placed
                },
                new OrderDetail {
                    Id = 5,
                    LotId = 2,
                    OrderId = 3,
                    Status = LotDetailStatus.Bid_placed
                }
            };
    }
}

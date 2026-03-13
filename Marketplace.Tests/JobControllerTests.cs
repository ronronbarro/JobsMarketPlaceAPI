using JobsMarketPlaceAPI.Controllers;
using JobsMarketPlaceAPI.Entities;
using JobsMarketPlaceAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Tests
{
    public class JobControllerTests
    {
        private readonly Mock<IJobRepository> _jobRepositoryMock;
        private readonly JobController _controller;

        public JobControllerTests()
        {
            _jobRepositoryMock = new Mock<IJobRepository>();
            _controller = new JobController(_jobRepositoryMock.Object);
        }

        [Fact]
        public async Task Create_ShouldReturnCreated_WhenJobIsValid()
        {
            var job = new Job
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(5),
                Budget = 1000,
                Description = "Build mobile app"
            };

            _jobRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<Job>()))
                .ReturnsAsync(job);

            var result = await _controller.Create(job);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedJob = Assert.IsType<Job>(createdResult.Value);

            Assert.Equal(job.Id, returnedJob.Id);
        }
    }

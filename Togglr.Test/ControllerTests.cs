using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Togglr.Controllers;
using Togglr.Models;
using Moq;
using Togglr.Services;

namespace Togglr.Test.Controllers
{
    [TestFixture]
    public class ProjectControllerTests
    {
        private readonly ProjectController projectController = new();
        private List<Project> MockObjects = new()
        {
            new Project
            {
                Id = 1,
                Name = "Flashheart"
            },
            new Project
            {
                Id = 2,
                Name = "Queenie"
            }
        };
        [SetUp]
        public void Setup()
        {}
        [Test]
        public void ProjectController_GetAll_ReturnsCorrectNumberOfProjects()
        {
            var projectController = new ProjectController();
            var results = projectController.GetAll().Value;
            Assert.IsInstanceOf<List<Project>>(results);
        }
        [Test]
        public void ProjectController_Get_ReturnsCorrectProjectById()
        {
            var testId = "162841565";
            Project result = projectController.Get(testId).Value;
            Assert.IsTrue(result.Id == int.Parse(testId));
        }
        [Test]
        public void ProjectController_Get_ReturnsCorrectProjectByName()
        {
            var testName = "Product Research";
            Project result = projectController.Get(testName).Value;
            Assert.IsTrue(result.Name == testName);
        }
        [Test]
        public void ProjectController_Get_Returns404IfProjectNotFound()
        {
            var testName = "The Scarlet Pimpernel";
            var result = projectController.Get(testName).Result;
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
    [TestFixture]
    public class TagControllerTests
    {
        [Test]
        public void TagController_GetAll_ReturnsCorrectNumberOfTags()
        {
            var tagController = new TagController();
            List<Tag> results = tagController.GetAll().Value;
            Assert.IsTrue(results.Count == 320);
        }
        [Test]
        public void TagController_Get_ReturnsCorrectTagById()
        {
            var tagController = new TagController();
            var testId = "9996074";
            Tag result = tagController.Get(testId).Value;
            Assert.IsTrue(result.Id == int.Parse(testId));
        }
        [Test]
        public void TagController_Get_ReturnsCorrectTagByName()
        {
            var tagController = new TagController();
            var testName = "Generic Scraping";
            Tag result = tagController.Get(testName).Value;
            Assert.IsTrue(result.Name == testName);
        }
        [Test]
        public void TagController_Get_Returns404IfTagNotFound()
        {
            var tagController = new TagController();
            var testName = "The Scarlet Pimpernel";
            var result = tagController.Get(testName).Result;
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
    [TestFixture]
    public class TaskControllerTests
    {
        [Test]
        public void TaskController_GetAll_ReturnsCorrectNumberOfTasks()
        {
            var taskController = new TaskController();
            List<Task> results = taskController.GetAll().Value;
            Assert.IsTrue(results.Count == 3174);
        }
        [Test]
        public void TaskController_Get_ReturnsCorrectTaskById()
        {
            var taskController = new TaskController();
            var testId = "18039332";
            Task result = taskController.Get(testId).Value;
            Assert.IsTrue(result.Id == int.Parse(testId));
        }
        [Test]
        public void TaskController_Get_ReturnsCorrectTaskByName()
        {
            var taskController = new TaskController();
            var testName = "Create Service Summary";
            Task result = taskController.Get(testName).Value;
            Assert.IsTrue(result.Name == testName);
        }
        [Test]
        public void TaskController_Get_Returns404IfTaskNotFound()
        {
            var taskController = new TaskController();
            var testName = "The Scarlet Pimpernel";
            var result = taskController.Get(testName).Result;
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
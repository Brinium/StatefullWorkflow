﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatefullWorkflow.DataAccess.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StatefullWorkflow.DataAccess.Test;

namespace StatefullWorkflow.DataAccess.Tests
{
    [TestClass()]
    public class JsonRepositoryTests
    {
        [TestMethod()]
        public void Get_Test()
        {
            var entities = new Dictionary<int, TestEntity>
            {
                { 1, new TestEntity{ Id =1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false }},
                { 2, new TestEntity{ Id =2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true }},
                { 3, new TestEntity{ Id =3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false }},
                { 4, new TestEntity{ Id =4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true }}
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.GetDataSet<TestEntity>()).Returns(entities);

            var repo = new JsonRepository<TestEntity>(uowMock.Object);

            var testGet = repo.Get(3);
            Assert.IsNotNull(testGet);
            Assert.IsTrue(testGet.Id == 3);

            var testGet_IsNull = repo.Get(26);
            Assert.IsNull(testGet_IsNull);
        }

        [TestMethod()]
        public void All_Test()
        {
            var entities = new Dictionary<int, TestEntity>
            {
                { 1, new TestEntity{ Id =1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false }},
                { 2, new TestEntity{ Id =2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true }},
                { 3, new TestEntity{ Id =3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false }},
                { 4, new TestEntity{ Id =4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true }}
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.GetDataSet<TestEntity>()).Returns(entities);

            var repo = new JsonRepository<TestEntity>(uowMock.Object);

            var testAll = repo.All().ToList();
            Assert.IsNotNull(testAll);
            Assert.IsTrue(testAll.Count == 4);
            Assert.IsTrue(testAll[0].Id == 1);
            Assert.IsTrue(testAll[1].Id == 2);
            Assert.IsTrue(testAll[2].Id == 3);
            Assert.IsTrue(testAll[3].Id == 4);
        }

        [TestMethod()]
        public void Where_Test()
        {
            var entities = new Dictionary<int, TestEntity>
            {
                { 1, new TestEntity{ Id =1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false }},
                { 2, new TestEntity{ Id =2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true }},
                { 3, new TestEntity{ Id =3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false }},
                { 4, new TestEntity{ Id =4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true }}
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.GetDataSet<TestEntity>()).Returns(entities);

            var repo = new JsonRepository<TestEntity>(uowMock.Object);

            var testWhere = repo.Where(x => x.FieldB == 303 || x.FieldC == "Field_C_4").ToList();
            Assert.IsNotNull(testWhere);
            Assert.IsTrue(testWhere.Count == 2);
            Assert.IsTrue(testWhere[0].Id == 3);
            Assert.IsTrue(testWhere[1].Id == 4);
        }

        [TestMethod()]
        public void FirstOrDefault_Test()
        {
            var entities = new Dictionary<int, TestEntity>
            {
                { 1, new TestEntity{ Id =1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false }},
                { 2, new TestEntity{ Id =2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true }},
                { 3, new TestEntity{ Id =3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false }},
                { 4, new TestEntity{ Id =4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true }}
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.GetDataSet<TestEntity>()).Returns(entities);

            var repo = new JsonRepository<TestEntity>(uowMock.Object);

            var testFirstOrDefault_NotNull = repo.FirstOrDefault(x => x.FieldB == 303 || x.FieldC == "Field_C_4");
            Assert.IsNotNull(testFirstOrDefault_NotNull);
            Assert.IsTrue(testFirstOrDefault_NotNull.Id == 3);

            var testFirstOrDefault_IsNull = repo.FirstOrDefault(x => x.FieldB == 555);
            Assert.IsNull(testFirstOrDefault_IsNull);
        }

        [TestMethod()]
        public void Insert_Test()
        {
            var entities = new Dictionary<int, TestEntity>
            {
                { 1, new TestEntity{ Id = 1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false }},
                { 2, new TestEntity{ Id = 2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true }},
                { 3, new TestEntity{ Id = 3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false }},
                { 4, new TestEntity{ Id = 4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true }},
                { 6, new TestEntity{ Id = 6, FieldA = "Field_A_6", FieldB = 606, FieldC = "Field_C_6", FieldD = false }}
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.GetDataSet<TestEntity>()).Returns(entities);

            var repo = new JsonRepository<TestEntity>(uowMock.Object);

            var testEntityOne = new TestEntity { FieldA = "Insert_1", FieldB = 111, FieldC = "Insert_1", FieldD = true };
            repo.Insert(testEntityOne);

            var result = repo.Get(5);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 5);
            Assert.IsTrue(result.FieldA == "Insert_1");
            Assert.IsTrue(repo.All().Count() == 6);

            var testEntityTwo = new TestEntity { FieldA = "Insert_2", FieldB = 222, FieldC = "Insert_2", FieldD = false };
            repo.Insert(testEntityTwo);

            result = repo.Get(7);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 7);
            Assert.IsTrue(result.FieldA == "Insert_2");
            Assert.IsTrue(repo.All().Count() == 7);
        }

        [TestMethod()]
        public void Update_Test()
        {
            var entities = new Dictionary<int, TestEntity>
            {
                { 1, new TestEntity{ Id = 1, FieldA = "Field_A_1", FieldB = 101, FieldC = "Field_C_1", FieldD = false }},
                { 2, new TestEntity{ Id = 2, FieldA = "Field_A_2", FieldB = 202, FieldC = "Field_C_2", FieldD = true }},
                { 3, new TestEntity{ Id = 3, FieldA = "Field_A_3", FieldB = 303, FieldC = "Field_C_3", FieldD = false }},
                { 4, new TestEntity{ Id = 4, FieldA = "Field_A_4", FieldB = 404, FieldC = "Field_C_4", FieldD = true }},
                { 6, new TestEntity{ Id = 6, FieldA = "Field_A_6", FieldB = 606, FieldC = "Field_C_6", FieldD = false }}
            };

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(uow => uow.GetDataSet<TestEntity>()).Returns(entities);

            var repo = new JsonRepository<TestEntity>(uowMock.Object);

            var testEntityOne = entities[3];
            testEntityOne.FieldA = "Changed_1";

            var idOne = repo.Update(testEntityOne);

            Assert.IsTrue(idOne == 3);
            var result = repo.Get(3);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 3);
            Assert.IsTrue(result.FieldA == "Changed_1");
            Assert.IsTrue(repo.All().Count() == 5);

            var testEntityTwo = new TestEntity { FieldA = "Insert_2", FieldB = 222, FieldC = "Insert_2", FieldD = false };
            var idTwo = repo.Update(testEntityTwo);

            Assert.IsTrue(idTwo == 5);
            result = repo.Get(5);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id == 5);
            Assert.IsTrue(result.FieldA == "Insert_2");
            Assert.IsTrue(repo.All().Count() == 6);
        }
    }
}
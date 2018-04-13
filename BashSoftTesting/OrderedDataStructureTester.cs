using BashSoft.Contracts;
using BashSoft.DataStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BashSoftTesting
{
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        //[Test]
        //public void TestAddUnsrotedDataIsHeldSorted()
        //{
        //    names.Add("Rosen");
        //    names.Add("Atanas");
        //    names.Add("Boiko");

        //    var expectedList = new List<string>();
        //    expectedList.Add("Atanas");
        //    expectedList.Add("Boiko");
        //    expectedList.Add("Rosen");

        //    for (int i = 0; i < names.Size; i++)
        //    {
        //        Assert.AreEqual(names[i], expectedList[i])

        //    }
        //}

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 18; i++)
            {
                names.Add("a");
            }

            Assert.AreEqual(names.Size, 18);
            Assert.AreNotEqual(names.Capacity, 16);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
          
            var newNames = new List<string>();

            newNames.Add("a");
            newNames.Add("b");

            names.AddAll(newNames);

            Assert.AreEqual(names.Size, 2);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            var nullCollection = new List<string>
            {
                null,
                null
            };

            Assert.Throws<ArgumentNullException>(() => names.AddAll(nullCollection));
        }


        [Test]
        public void TestRemoveValidDecreasesSize()
        {
            names.Add("a");
            names.Remove("a");

            Assert.AreEqual(names.Size, 0);
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => names.Remove(null));
        }

        [Test]
        public void TestJoinWtihNull()
        {
            Assert.Throws<ArgumentNullException>(() => names.JoinWith(null));

        }

        [Test]
        public void TestJoinWorksFine()
        {
            names.Add("Gosho");
            names.Add("Pesho");
            names.Add("Ananas");

            var joinedNames = names.JoinWith(", ");
            Assert.AreEqual("Ananas, Gosho, Pesho", joinedNames);
        }
    }
}

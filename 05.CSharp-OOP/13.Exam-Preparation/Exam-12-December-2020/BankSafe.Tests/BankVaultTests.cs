using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Mitko", "1");
        }

        [Test]
        public void When_CreateBankVault_ShouldHaveADictionaryWith12Cells()
        {
            var dictionary = bankVault
                .GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "vaultCells")
                .GetValue(bankVault);

            Dictionary<string, Item> insideDictionary = (Dictionary<string, Item>)dictionary;

            Assert.That(insideDictionary is Dictionary<string, Item>);
            Assert.AreEqual(12, insideDictionary.Count);
        }

        [Test]
        public void When_GetDictionaryWithCells_ShouldBeReadOnly()
        {
            var dictionary = bankVault.VaultCells;

            Assert.That(dictionary is IReadOnlyDictionary<string, Item>);
            Assert.AreEqual(12, dictionary.Count);
        }

        [Test]
        public void When_AddItemOnNotExistingCell_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(
                () => bankVault.AddItem("D1", null),
                "Cell doesn't exists!");
        }

        [Test]
        public void When_AddItemOnNotEmptyCell_ShouldThrowException()
        {
            bankVault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(
                () => bankVault.AddItem("A1", null),
                "Cell is already taken!");
        }

        [Test]
        public void When_AddSameItemInDifferentCell_ShouldThrowException()
        {
            bankVault.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(
                () => bankVault.AddItem("A2", item),
                "Item is already in cell!");
        }

        [Test]
        public void When_AddItemToCell_ShouldBeAdded()
        {
            bankVault.AddItem("A1", item);

            var dictionary = bankVault
                .GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "vaultCells")
                .GetValue(bankVault);

            Dictionary<string, Item> insideDictionary = (Dictionary<string, Item>)dictionary;

            Assert.IsNotNull(insideDictionary["A1"]);
        }

        [Test]
        public void When_AddItem_ShouldReceiveMessage()
        {
            string msg = bankVault.AddItem("A1", item);


            Assert.AreEqual("Item:1 saved successfully!", msg);
        }

        [Test]
        public void When_RemoveItemOnNotExistingCell_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(
                () => bankVault.RemoveItem("D1", null),
                "Cell doesn't exists!");
        }

        [Test]
        public void When_RemoveItemAndCellIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(
                () => bankVault.RemoveItem("A1", item),
                "Item in that cell doesn't exists!");
        }

        [Test]
        public void When_RemoveItemFromCell_ShouldBeRemoved()
        {
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);

            var dictionary = bankVault
                .GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "vaultCells")
                .GetValue(bankVault);

            Dictionary<string, Item> insideDictionary = (Dictionary<string, Item>)dictionary;

            Assert.IsNull(insideDictionary["A1"]);
        }

        [Test]
        public void When_RemovedItem_ShouldReturnMessage()
        {
            bankVault.AddItem("A1", item);
            string msg = bankVault.RemoveItem("A1", item);

            Assert.AreEqual("Remove item:1 successfully!", msg);
        }
    }
}

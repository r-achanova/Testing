using NUnit.Framework;
using System;

namespace BankingSystem.Tests
{
    [TestFixture]
    public class BankAccountTests
    {

        [Test]
        public void DepositShouldIncreaseBalance()
        {
            {
                //Arrange
                int id = 123;
                decimal amount = 500;
                BankAccount bankAccount = new BankAccount(id,amount);
                decimal depositAmount = 100;

                //Act
                bankAccount.Deposit(depositAmount);

                //Assert
                Assert.AreEqual(depositAmount+amount, bankAccount.Balance,"Balance increase with positive number");
            }
        }

        [TestCase(123,500)]
        [TestCase(123,500.7896)]
        [TestCase(123,0)]
        public void ConstructorShouldSetBalanceCorrectly(int id, decimal amount)
        {
            {
                //Arrange&Act
                BankAccount bankAccount = new BankAccount(id, amount);
              
                //Assert
                Assert.AreEqual(amount, bankAccount.Balance);
            }
        }

        [Test]
        public void AccountInicializeWhithPositiveValue()
        {
            {
                //Arrange 

                //Act
                BankAccount bankAccount = new BankAccount(123, 2000m);

                //Assert
                Assert.AreEqual(2000m, bankAccount.Balance);
            }
        }

        
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationException()
        {
            {
                //Arrange
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;

                //Act
                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                                  bankAccount.Deposit(depositAmount));
            }
        }
        [Test]
        public void BalanceShouldThrowArgumentExceptionWhenAmountIsNegative()
        {
            {
                //Arrange
                int id = 123;
                decimal amount = -100.123m;
             
                //Act
               //Assert
                Assert.Throws<ArgumentException>(() =>
                                  new BankAccount(id, amount));
            }
        }

        [Test]
        public void BalanceShouldThrowCurrentMessageWhenAmountIsNegative()
        {
            {
                //Arrange
                int id = 123;
                decimal amount = -100.123m;
                string message = "Balance must be positive or zero";
                //Act

                var ex=Assert.Throws<ArgumentException>(() =>
                                  new BankAccount(id, amount));
                //Assert
                Assert.AreEqual(message, ex.Message);
            }
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionsWithMessage()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;

            //Act
            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
                                    bankAccount.Deposit(depositAmount));

            Assert.AreEqual(ex.Message, "Negative amount");
        }

        
    }
}
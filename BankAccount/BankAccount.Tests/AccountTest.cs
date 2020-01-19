
namespace Bank.Tests
{
    using Moq;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using System.Linq;

    public class AccountTest
    {
        private AccountInfo accountInfo;
        private Mock<IAccountService> accountService;


        [SetUp]
        public void Setup()
        {
            accountService = new Mock<IAccountService>();
        }


        //Exercise 1: Unit Test for RefreshAmount
        [Test]
        [TestCase(30, 45900)]
        public void RefreshAmountTestExerc1Test(int accountId, double expectedAmount)
        {
            accountInfo = new AccountInfo(accountId, accountService.Object);
            accountService
                .Setup(a => a.GetAccountAmount(accountId))
                .Returns(expectedAmount);

            accountInfo.RefreshAmount();

            Assert.AreEqual(expectedAmount, accountInfo.Amount);
        }


        //Exercise 2: Async Unit Test for RefreshAmount
        [Test]
        [TestCase(1, 15.20)]
        [TestCase(-1, 0)]
        [TestCase(0, 0)]
        public async Task RefreshAmountOkTest(int accountId, double expectedAmount)
        {
            accountInfo = new AccountInfo(accountId, accountService.Object);

            accountService
                .Setup(a => a.GetAccountAmountAsync(accountId))
                .Returns(Task.FromResult(expectedAmount));

            await accountInfo.RefreshAmountAsync();

            Assert.AreEqual(expectedAmount, accountInfo.Amount);
        }


        //Exercise 2: Async Test with multiple times
        [Test]
        public async Task RefreshAmountMultipleTimesTest()
        {
            int[] amountIds = { -1, 0, 1, 2, 3, 4, 20, 1000};
            double[] amounts = { 0, 0, 2, 4, 6, 67, 400, 30000};
            Task[] tasks = new Task[amountIds.Length];

            AccountInfo[] accountInfos = new AccountInfo[amountIds.Length];

            for (int i = 0; i < amountIds.Length; i++)
            {
                accountInfos[i] = new AccountInfo(amountIds[i], accountService.Object);
                accountService
                    .Setup(a => a.GetAccountAmountAsync(amountIds[i]))
                    .Returns(Task.FromResult(amounts[i]));
            }

            var refreshActions = accountInfos
                .Select(a => a.RefreshAmountAsync());

            Task.WaitAll(refreshActions.ToArray());

            for (int i = 0; i < amountIds.Length; i++)
            {
                Assert.AreEqual(amounts[i], accountInfos[i].Amount);
            }
        }
    }
}
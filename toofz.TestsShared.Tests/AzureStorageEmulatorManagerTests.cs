using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.TestsShared.Tests
{
    class AzureStorageEmulatorManagerTests
    {
        [TestClass]
        [TestCategory("Integration")]
        [TestCategory("Azure Storage Emulator")]
        public class IsStartedMethod
        {
            public IsStartedMethod()
            {
                AzureStorageEmulatorManager.Stop();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                AzureStorageEmulatorManager.Stop();
            }

            [TestMethod]
            public void AzureStorageEmulatorIsNotStarted_ReturnsFalse()
            {
                // Arrange -> Act
                var isStarted = AzureStorageEmulatorManager.IsStarted();

                // Assert
                Assert.IsFalse(isStarted);
            }

            [TestMethod]
            public void AzureStorageEmulatorIsStarted_ReturnsTrue()
            {
                // Arrange
                AzureStorageEmulatorManager.Start();

                // Act
                var isStarted = AzureStorageEmulatorManager.IsStarted();

                // Assert
                Assert.IsTrue(isStarted);
            }
        }

        [TestClass]
        [TestCategory("Integration")]
        [TestCategory("Azure Storage Emulator")]
        public class StartMethod
        {
            public StartMethod()
            {
                AzureStorageEmulatorManager.Stop();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                AzureStorageEmulatorManager.Stop();
            }

            [TestMethod]
            public void AzureStorageEmulatorIsNotStarted_StartsAzureStorageEmulator()
            {
                // Arrange -> Act
                AzureStorageEmulatorManager.Start();

                // Assert
                var isStarted = AzureStorageEmulatorManager.IsStarted();
                Assert.IsTrue(isStarted);
            }

            [TestMethod]
            public void AzureStorageEmulatorIsStarted_AzureStorageEmulatorStaysStarted()
            {
                // Arrange
                AzureStorageEmulatorManager.Start();

                // Act
                AzureStorageEmulatorManager.Start();

                // Assert
                var isStarted = AzureStorageEmulatorManager.IsStarted();
                Assert.IsTrue(isStarted);
            }
        }

        [TestClass]
        [TestCategory("Integration")]
        [TestCategory("Azure Storage Emulator")]
        public class StopMethod
        {
            public StopMethod()
            {
                AzureStorageEmulatorManager.Stop();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                AzureStorageEmulatorManager.Stop();
            }

            [TestMethod]
            public void AzureStorageEmulatorIsStarted_StopsAzureStorageEmulator()
            {
                // Arrange
                AzureStorageEmulatorManager.Start();

                // Act
                AzureStorageEmulatorManager.Stop();


                // Assert
                var isStarted = AzureStorageEmulatorManager.IsStarted();
                Assert.IsFalse(isStarted);
            }

            [TestMethod]
            public void AzureStorageEmulatorIsNotStarted_AzureStorageEmulatorStaysNotStarted()
            {
                // Arrange -> Act
                AzureStorageEmulatorManager.Stop();

                // Assert
                var isStarted = AzureStorageEmulatorManager.IsStarted();
                Assert.IsFalse(isStarted);
            }
        }
    }
}

﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualQNet.Results;
using VirtualQNet.Caller;

namespace VirtualQNet.Tests
{
    [TestClass]
    public class CallersHandlerTests
    {
        [TestMethod]
        public void LineUpCaller_ValidLineId_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                LineUpCallerParameters attributes = new LineUpCallerParameters
                {
                    LineId = 3042,
                    Phone = "+17343305027",
                    Channel = "CallIn",
                    Source = "Phone",
                    Language = "en"
                };

                Result result = client.Callers.LineUpCaller(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void VerifyCaller_ValidLineIdAndPhone_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                CallerParameters attributes = new CallerParameters
                {
                    LineId = 3042,
                    Phone = "+17343305027"
                };

                Result<bool> result = client.Callers.VerifyCaller(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsTrue(result.Value);
            }
        }

        [TestMethod]
        public void VerifyCaller_InvalidPhone_ExpectFailure()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                CallerParameters attributes = new CallerParameters
                {
                    LineId = 3042,
                    Phone = "+17343305000"
                };

                Result<bool> result = client.Callers.VerifyCaller(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
                Assert.IsFalse(result.Value);
            }
        }

        [TestMethod]
        public void NotifyCallerConnected_ValidLineIdAndPhone_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                CallerParameters attributes = new CallerParameters
                {
                    LineId = 3042,
                    Phone = "+17343305027"
                };

                Result result = client.Callers.NotifyCallerConnected(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void NotifyCallerTransferred_ValidLineIdAndPhone_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                NotifyCallerTransferredParameters attributes = new NotifyCallerTransferredParameters
                {
                    LineId = 3042,
                    Phone = "+17343305027",
                    AgentId = "B"
                };

                Result result = client.Callers.NotifyCallerTransferred(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }

        [TestMethod]
        public void UpdateCallerInformation_ValidLineIdAndPhone_ExpectSuccess()
        {
            string apiKey = ConfigurationHelper.GetApiKey();
            VirtualQClientConfiguration configuration = new VirtualQClientConfiguration
            {
                ApiBaseAddress = ConfigurationHelper.GetApiUrl(),
                Timeout = null
            };
            using (VirtualQ client = new VirtualQ(apiKey, configuration))
            {
                UpdateCallerInformationParameters attributes = new UpdateCallerInformationParameters
                {
                    LineId = 3042,
                    Phone = "+17343305027",
                    AgentId = "A345",
                    TalkTime = 518,
                    WaitTimeWhenUp = 30
                };

                Result result = client.Callers.UpdateCallerInformation(attributes).Result;

                Assert.IsTrue(result.RequestWasSuccessful);
            }
        }
    }
}

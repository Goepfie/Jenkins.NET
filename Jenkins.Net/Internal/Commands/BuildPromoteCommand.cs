using JenkinsNET.Models;
using System;

namespace JenkinsNET.Internal.Commands
{
    internal class BuildPromoteCommand : JenkinsHttpCommand
    {
        
        public BuildPromoteCommand(JenkinsClient client, string jobName, string buildNumber, int promotionLevel) : base(client)
        {
            if (string.IsNullOrEmpty(jobName))
                throw new ArgumentException("'jobName' cannot be empty!");

            if (string.IsNullOrEmpty(buildNumber))
                throw new ArgumentException("'buildNumber' cannot be empty!");

            Path = $"job/{jobName}/{buildNumber}/promote/?level={promotionLevel}";

            OnWrite = request => {
                request.Method = "POST";
            };

            OnRead = response => {
                var document = ReadXml(response);
            };

        #if NET_ASYNC
            OnWriteAsync = async (request, token) => {
                request.Method = "POST";
            };
        #endif
        }
    }
}

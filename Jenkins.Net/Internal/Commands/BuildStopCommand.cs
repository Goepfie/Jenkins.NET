using JenkinsNET.Models;
using System;

namespace JenkinsNET.Internal.Commands
{
    internal class BuildStopCommand : JenkinsHttpCommand
    {
        public BuildStopCommand(JenkinsClient client, string jobName, int buildNumber) : base(client)
        {
            if (string.IsNullOrEmpty(jobName))
                throw new ArgumentException("'jobName' cannot be empty!");

            Path = $"job/{jobName}/{buildNumber}/stop";

            OnWrite = request => {
                request.Method = "POST";
            };
            
        #if NET_ASYNC
            OnWriteAsync = async (request, token) => {
                request.Method = "POST";
            };
        #endif
        }
    }
}

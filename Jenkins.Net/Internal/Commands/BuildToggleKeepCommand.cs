using JenkinsNET.Models;
using System;

namespace JenkinsNET.Internal.Commands
{
    internal class BuildToggleKeepCommand : JenkinsHttpCommand
    {
        
        public BuildToggleKeepCommand(JenkinsClient client, string jobName, int buildNumber) : base(client)
        {
            if (string.IsNullOrEmpty(jobName))
                throw new ArgumentException("'jobName' cannot be empty!");

            Path = $"job/{jobName}/{buildNumber}/toggleLogKeep";

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

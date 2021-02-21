﻿using System;
using System.IO;
using System.Text;

namespace JenkinsNET.Internal.Commands
{
    internal class BuildHtmlCommand : JenkinsHttpCommand
    {
        public string Result {get; private set;}


        public BuildHtmlCommand(JenkinsClient client, string jobName, int buildNumber) : base(client)
        {
            if (string.IsNullOrEmpty(jobName))
                throw new ArgumentException("'jobName' cannot be empty!");

            Path = $"job/{jobName}/{buildNumber}/consoleFull";

            OnRead = response => {
                using (var stream = response.GetResponseStream()) {
                    if (stream == null) return;

                    var encoding = TryGetEncoding(response.ContentEncoding, Encoding.UTF8);
                    using (var reader = new StreamReader(stream, encoding)) {
                        Result = reader.ReadToEnd();
                    }
                }
            };

        #if NET_ASYNC
            OnReadAsync = async (response, token) => {
                using (var stream = response.GetResponseStream()) {
                    if (stream == null) return;

                    var encoding = TryGetEncoding(response.ContentEncoding, Encoding.UTF8);
                    Result = await stream.ReadToEndAsync(encoding, token);
                }
            };
        #endif
        }
    }
}

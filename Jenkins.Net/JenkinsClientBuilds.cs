﻿using JenkinsNET.Exceptions;
using JenkinsNET.Internal.Commands;
using JenkinsNET.Models;
using System;

#if NET_ASYNC
using System.Threading;
using System.Threading.Tasks;
#endif

namespace JenkinsNET
{
    /// <summary>
    /// A collection of methods used for interacting with Jenkins Builds.
    /// </summary>
    /// <remarks>
    /// Used internally by <seealso cref="JenkinsClient"/>
    /// </remarks>
    public sealed class JenkinsClientBuilds
    {
        private readonly JenkinsClient client;


        internal JenkinsClientBuilds(JenkinsClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Gets information describing a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <exception cref="JenkinsJobGetBuildException"></exception>
        public T Get<T>(string jobName, int buildNumber) where T : class, IJenkinsBuild
        {
            try {
                var cmd = new BuildGetCommand<T>(client, jobName, buildNumber);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsJobGetBuildException($"Failed to retrieve build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets information describing a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsJobGetBuildException"></exception>
        public async Task<T> GetAsync<T>(string jobName, int buildNumber, CancellationToken token = default) where T : class, IJenkinsBuild
        {
            try {
                var cmd = new BuildGetCommand<T>(client, jobName, buildNumber);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsJobGetBuildException($"Failed to retrieve build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif

        /// <summary>
        /// Gets the console output from a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public string GetConsoleText(string jobName, int buildNumber)
        {
            try {
                var cmd = new BuildTextCommand(client, jobName, buildNumber);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve console output from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets the console output from a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public async Task<string> GetConsoleTextAsync(string jobName, int buildNumber, CancellationToken token = default)
        {
            try {
                var cmd = new BuildTextCommand(client, jobName, buildNumber);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve console output from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif

        /// <summary>
        /// Gets the console output from a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public string GetConsoleHtml(string jobName, int buildNumber)
        {
            try {
                var cmd = new BuildHtmlCommand(client, jobName, buildNumber);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve console output from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets the console output from a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public async Task<string> GetConsoleHtmlAsync(string jobName, int buildNumber, CancellationToken token = default)
        {
            try {
                var cmd = new BuildHtmlCommand(client, jobName, buildNumber);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve console output from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif

        /// <summary>
        /// Gets the progressive text output from a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="start">The character position to begin reading from.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public JenkinsProgressiveTextResponse GetProgressiveText(string jobName, int buildNumber, int start)
        {
            try {
                var cmd = new BuildProgressiveTextCommand(client, jobName, buildNumber, start);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve progressive text from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets the progressive text output from a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="start">The character position to begin reading from.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public async Task<JenkinsProgressiveTextResponse> GetProgressiveTextAsync(string jobName, int buildNumber, int start, CancellationToken token = default)
        {
            try {
                var cmd = new BuildProgressiveTextCommand(client, jobName, buildNumber, start);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve progressive text from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif

        /// <summary>
        /// Gets the console output from a Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="start">The character position to begin reading from.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public JenkinsProgressiveHtmlResponse GetProgressiveHtml(string jobName, int buildNumber, int start)
        {
            try {
                var cmd = new BuildProgressiveHtmlCommand(client, jobName, buildNumber, start);
                cmd.Run();
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve progressive HTML from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Gets the console output from a Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="start">The character position to begin reading from.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsNetException"></exception>
        public async Task<JenkinsProgressiveHtmlResponse> GetProgressiveHtmlAsync(string jobName, int buildNumber, int start, CancellationToken token = default)
        {
            try {
                var cmd = new BuildProgressiveHtmlCommand(client, jobName, buildNumber, start);
                await cmd.RunAsync(token);
                return cmd.Result;
            }
            catch (Exception error) {
                throw new JenkinsNetException($"Failed to retrieve progressive HTML from build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif
        /// <summary>
        /// Stops an active Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="promotionLevel">The level the build should be set to.</param>
        /// <exception cref="JenkinsJobGetBuildException"></exception>
        public void Promote(string jobName, int buildNumber, int promotionLevel)
        {
            try {
                var cmd = new BuildPromoteCommand(client, jobName, buildNumber, promotionLevel);
                cmd.Run();
            }
            catch (Exception error) {
                //throw new JenkinsNetException($"Failed to promote build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

#if NET_ASYNC
        /// <summary>
        /// Stops an active Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsJobGetBuildException"></exception>
        /// <param name="promotionLevel">The level the build should be set to.</param>
        public async Task PromoteAsync(string jobName, int buildNumber, int promotionLevel, CancellationToken token = default)
        {
            try {
                var cmd = new BuildPromoteCommand(client, jobName, buildNumber, promotionLevel);
                await cmd.RunAsync(token);
            }
            catch (Exception error) {
                //throw new JenkinsNetException($"Failed to promote build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
#endif
        
        /// <summary>
        /// Stops an active Jenkins Job Build.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <exception cref="JenkinsJobGetBuildException"></exception>
        public void Stop(string jobName, int buildNumber)
        {
            try {
                var cmd = new BuildStopCommand(client, jobName, buildNumber);
                cmd.Run();
            }
            catch (Exception error) {
                // Jenkins 2.280 returns HTTP 403, but build is stopped
                //throw new JenkinsNetException($"Failed to stop build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }

    #if NET_ASYNC
        /// <summary>
        /// Stops an active Jenkins Job Build asynchronously.
        /// </summary>
        /// <param name="jobName">The name of the Job.</param>
        /// <param name="buildNumber">The number of the build.</param>
        /// <param name="token">An optional token for aborting the request.</param>
        /// <exception cref="JenkinsJobGetBuildException"></exception>
        public async Task StopAsync(string jobName, int buildNumber, CancellationToken token = default)
        {
            try {
                var cmd = new BuildStopCommand(client, jobName, buildNumber);
                await cmd.RunAsync(token);
            }
            catch (Exception error) {
                // Jenkins 2.280 returns HTTP 403, but build is stopped
                //throw new JenkinsNetException($"Failed to stop build #{buildNumber} of Jenkins Job '{jobName}'!", error);
            }
        }
    #endif
    }
}

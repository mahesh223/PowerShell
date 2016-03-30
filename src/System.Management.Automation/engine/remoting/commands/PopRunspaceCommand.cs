/********************************************************************++
Copyright (c) Microsoft Corporation.  All rights reserved.
--********************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Remoting;
using System.Management.Automation.Internal;
using System.Management.Automation.Runspaces;
using Dbg = System.Management.Automation.Diagnostics;

namespace Microsoft.PowerShell.Commands
{
    /// <summary>
    /// Exit-PSSession cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Exit, "PSSession", HelpUri = "http://go.microsoft.com/fwlink/?LinkID=135212")]
    public class ExitPSSessionCommand : PSRemotingCmdlet
    {
        /// <summary>
        /// Process record.
        /// </summary>
        protected override void ProcessRecord()
        {
            // Pop it off the local host.
            IHostSupportsInteractiveSession host = this.Host as IHostSupportsInteractiveSession;
            if (host == null)
            {
                WriteError(
                    new ErrorRecord(
                        new ArgumentException(GetMessage(RemotingErrorIdStrings.HostDoesNotSupportPushRunspace)),
                        PSRemotingErrorId.HostDoesNotSupportPushRunspace.ToString(),
                        ErrorCategory.InvalidArgument,
                        null));
                return;
            }

            host.PopRunspace();
        }
    }
}

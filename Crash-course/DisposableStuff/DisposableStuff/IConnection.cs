//  -----------------------------------------------------------------------
//  <copyright file="IConnection.cs" company="Microsoft">
//       Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
//  -----------------------------------------------------------------------

namespace DisposableStuff
{
    public interface IConnection
    {
        string GetMessageState(string messageId);

        bool SetMessageState(string messageId, string state);

        void Close();
    }
}

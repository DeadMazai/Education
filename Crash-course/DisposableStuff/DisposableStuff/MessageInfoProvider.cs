using System;

namespace DisposableStuff
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class MessageInfoProvider
    {
        private const string SelectMessageStateKey = "SelectMessageState";
        private const string SetMessageStateKey = "SetMessageState";
        private SqlConnection connection;
        private bool isDisposed = false;

        private Dictionary<string, string> commands = new Dictionary<string, string>()
        {
            { "SelectMessageState", "SELECT TOP 1 State FROM Messages WHERE Id = '{0}'" },
            { "SetMessageState", "UPDATE Messages SET State = '{1}' WHERE Id = '{0}'" }
        };

        public MessageInfoProvider(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }

        public string GetMessageState(string messageId)
        {
            this.CheckConnection();
            return this.GetMessageStateCommon(messageId);
        }

        public void SetMessageState(string messageId, string messageState)
        {
            this.CheckConnection();
            this.SetMessageStateCommon(messageId, messageState);
        }

        public string GetMessageStateSafe(string messageId)
        {
            return isDisposed ? this.GetMessageStateCommon(messageId) : string.Empty;
        }

        public void SetMessageStateSafe(string messageId, string messageState)
        {
            if (isDisposed)
            {
                this.SetMessageStateCommon(messageId, messageState);
            }
        }

        private void SetMessageStateCommon(string messageId, string messageState)
        {
            var requestString = string.Format(commands[SetMessageStateKey], messageId, messageState);
            using (var command = new SqlCommand(requestString, this.connection))
            {
                command.ExecuteNonQuery();
            }
        }
        private string GetMessageStateCommon(string messageId)
        {
            var requestString = string.Format(commands[SelectMessageStateKey], messageId);
            using (var command = new SqlCommand(requestString, this.connection))
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                return reader.GetString(0);
            }
        }

        private void CheckConnection()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Provider's connection was disposed.");
            }
            this.OpenConnectionSafe();
        }

        private void OpenConnectionSafe()
        {
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }
        }

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.connection.Close();
            }
        }

        ~MessageInfoProvider()
        {
            this.Dispose();
        }
    }
}

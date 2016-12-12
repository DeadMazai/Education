using System;

namespace DisposableStuff
{
    public class MessageInfoProvider
    {
        private IConnection connection;
        private bool isDisposed = false;

        public MessageInfoProvider(IConnection connection)
        {
            this.connection = connection;
        }

        public string GetMessageState(string messageId)
        {
            this.CheckConnection();

            return this.connection.GetMessageState(messageId);
        }

        public void SetMessageState(string messageId, string messageState)
        {
            this.CheckConnection();

            this.connection.SetMessageState(messageId, messageState);
        }

        public string GetMessageStateSafe(string messageId)
        {
            return isDisposed ? this.connection.GetMessageState(messageId) : string.Empty;
        }

        public void SetMessageStateSafe(string messageId, string messageState)
        {
            if (isDisposed)
            {
                this.connection.SetMessageState(messageId, messageState);
            }
        }

        private void CheckConnection()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Provider's connection was disposed.");
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

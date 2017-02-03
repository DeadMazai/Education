public class MessageInfoProvider : IDisposable
{
    private Connection connection;
    private bool isDisposed = false;
    
    public MessageInfoProvider(Connection connection) 
    {
        this.connection = connection;
    }

    public string GetMessageStatus(string messageId) 
    {
        this.CheckConnection();

        return this.connection.GetMessageStatus(messageId);
    }

    public void SetMessageStatus(string messageStatus) 
    {
        this.CheckConnection();

        this.connection.SetMessageStatus(messageStatus);
    }

    public string GetMessageStatusSafe(string messageId) 
    {
        this.CheckConnection();

        return this.connection.GetMessageStatus(messageId);
    }

    public void SetMessageStatusSafe(string messageStatus) 
    {
        this.InvokeOperation(this.connection.SetMessageStatus, messageId);
    }

    private void InvokeOperation(Func f, string messageId)
    {
        
    }

    private void CheckConnection() 
    {
        if(isDisposed) 
        {
            throw new ObjectDisposedException("Provider's connection was disposed.");
        }
    }

    public void Dispose() 
    {
        if(!this.isDisposed) 
        {
            this.connection.Close();
        }
    }

    ~MessageInfoProvider()
    {
        this.Dispose();
    }
}
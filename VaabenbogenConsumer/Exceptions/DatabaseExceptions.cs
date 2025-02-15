namespace VaabenbogenConsumer.Exceptions
{
    public class DatabaseException(string message) : Exception(message);

    public class RecordAlreadyExistsException(string message) : Exception(message);

    public class RecordNotFoundException(string message) : Exception(message);
}

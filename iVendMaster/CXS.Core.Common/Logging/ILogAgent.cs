using System.Text;

namespace CXS.Core.Common.Logging
{
    public static class ParamHelper
    {
        public static string ToInputMessage(this ParamContainer[] paramContainers)
        {
            return paramContainers.ToMessage("\r\n\tInput parameters:");
        }

        public static string ToOutputMessage(this ParamContainer[] paramContainers)
        {
            return paramContainers.ToMessage("\r\n\tOutput parameters:");
        }

        public static string ToMessage(this ParamContainer[] paramContainers, string prefix)
        {
            if (paramContainers == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder(prefix);

            foreach (ParamContainer param in paramContainers)
                sb.Append("\r\n\t").Append(param);

            return sb.ToString();
        }
    }

    public class ParamContainer
    {
        public ParamContainer(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public object Value { get; set; }

        public override string ToString()
        {
            // Value class should implement proper ToString() method
            return $"{Name}:{Value}";
        }
    }

    public interface ILogAgent
    {
        void Flush();

        // Methods
        void Trace(LogInfo message);

        void Debug(LogInfo message);

        void Info(LogInfo message);

        void Warn(LogInfo message);

        void Error(LogInfo message);

        void Fatal(LogInfo message);

        // Properties
        bool IsTraceEnabled { get; }

        bool IsDebugEnabled { get; }

        bool IsInfoEnabled { get; }

        bool IsWarnEnabled { get; }

        bool IsErrorEnabled { get; }

        bool IsFatalEnabled { get; }
    }
}
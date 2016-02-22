using CXS.Core.Common.Interfaces;
using CXS.Core.Common.Logging;
using System.Runtime.Serialization;

namespace CXS.Core.Common.Utility
{
    //TODO: SerializationHelper should be rewritten using DataContractSerializer
    public  class SerializationHelper<T> where T : new()
    {
        DataContractSerializer dataContractSerializer;
        private Logger logger;
        private IIvendContext ivendContext;

        public SerializationHelper()
        {
            dataContractSerializer = new DataContractSerializer(typeof (T));
            ivendContext = ServiceContainer.Instance.GetInstance<IIvendContext>() as IIvendContext;
            logger = ivendContext.Logger as Logger;
        }

        public void Save(T obj,string filename)
        {
            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodStart();
            }
            //TODO: avoid using file system for PCL
            //TextWriter textWriter = new StreamWriter(filename);
            //dataContractSerializer.Serialize(textWriter, obj);
            //textWriter.Close();

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodEnd("Save",
                    new[] { new ParamContainer("Serialized File Info", filename) });
            }
        }
        public T Load(string filename)
        {
            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodStart();
            }
            //TODO: avoid using file system for PCL
            //TextReader textReader = new StreamReader(filename);
            T newObject = new T();//(T)dataContractSerializer.Deserialize(textReader);
            //textReader.Close();

            if (logger != null && logger.IsMethodLogEnabled)
            {
                logger.MethodEnd("Load",
                    new[] { new ParamContainer("Deserialized Object", newObject) });
            }
            return newObject;

        }
    }
}

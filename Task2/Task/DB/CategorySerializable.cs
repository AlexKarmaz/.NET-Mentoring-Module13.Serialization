using System;
using System.Runtime.Serialization;

namespace Task.DB
{
    [Serializable]
    public partial class Category
    {
        [OnSerializing]
        public void OnSerializing(StreamingContext context)
        {
            SerializationContext serializationContext = context.Context as SerializationContext;

            if (serializationContext != null && serializationContext.TypeToSerialize == typeof(Category))
            {
                serializationContext.ObjectContext.LoadProperty(this, c => c.Products);
            }
        }
    }
}

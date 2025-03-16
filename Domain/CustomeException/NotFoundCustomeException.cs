using System.Net;

namespace ProductCatalog.Domain.CustomeException
{
    public class NotFoundCustomeException : CustomeException
    {
        public NotFoundCustomeException(string _Message) : base(_Message, HttpStatusCode.NotFound) {}
    }

    public class ProductNotFoundCustomeException : NotFoundCustomeException
    {
        public ProductNotFoundCustomeException() : base("Producto NO Encontrado") {}
    }

    public class ProductDetailNotFoundCustomeException : NotFoundCustomeException
    {
        public ProductDetailNotFoundCustomeException() : base("Detalle de Producto NO Encontrado") { }
    }
}

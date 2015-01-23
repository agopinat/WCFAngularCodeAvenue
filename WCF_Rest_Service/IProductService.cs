using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Rest_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the erface name "IProduct" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/GetAllProducts/")]
        List<ProductDataContract> GetAllProducts();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/GetProductDetails/{ProductId}")]
        ProductDataContract GetProductDetails(string ProductId);

        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/AddToCart")]
        bool AddToCart(ProductDataContract Product);

        [OperationContract]
        [WebInvoke(Method = "PUT",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/UpdateProductInCart")]
        void UpdateProductInCart(ProductDataContract Product);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "DeleteProductFromCart/{ProductId}")]
        void DeleteProductFromCart(int ProductId);
    }
}

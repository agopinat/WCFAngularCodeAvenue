using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_Rest_Service.Model;

namespace WCF_Rest_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Product" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Product.svc or Product.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        localEntities ctx;

        public ProductService()
        {
            ctx = new localEntities();
        }

        public List<ProductDataContract> GetAllProducts()
        {
            var query = (from a in ctx.Products
                         select a).Distinct();

            List<ProductDataContract> ProductList = new List<ProductDataContract>();

            query.ToList().ForEach(rec =>
            {
                ProductList.Add(new ProductDataContract
                {
                    ProductID = rec.ProductID,
                    Name = rec.Name,
                    CartID = rec.CartID,
                    Price = rec.Price,
                    Description = rec.Description,
                    Car = rec.Car,
                    Image = rec.Image,
                    QuantityInHand = rec.QuantityInHand
                });
            });
            return ProductList;
        }

        public ProductDataContract GetProductDetails(string ProductID)
        {
            ProductDataContract product = new ProductDataContract();

            try
            {
                int Product_ID = Convert.ToInt32(ProductID);
                var query = (from a in ctx.Products
                             where a.ProductID.Equals(Product_ID)
                             select a).Distinct().FirstOrDefault();

                product.ProductID = query.ProductID;
                product.Name = query.Name;
                product.Price= query.Price;
                product.Description = query.Description;
                product.Image = query.Image;
                product.QuantityInHand = query.QuantityInHand;
                product.Car = query.Car;
                product.CartID = query.CartID;
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return product;
        }

        public bool AddToCart(ProductDataContract product)
        {
            try
            {
                Product prod = ctx.Products.Create();
                
                prod.CartID = product.CartID;
                prod.Name = product.Name;
                prod.Car = product.Car;
                prod.Description = product.Description;
                prod.Image = product.Image;
                prod.ProductID = Convert.ToInt16(product.ProductID);
                prod.QuantityInHand = product.QuantityInHand;

                ctx.Products.Add(prod);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return true;
        }

        public void UpdateProductInCart(ProductDataContract product)
        {
            try
            {
                int Prod_Id = product.ProductID;
                Product prod = ctx.Products.Where(rec => rec.ProductID == Prod_Id).FirstOrDefault();
                
                prod.CartID = product.CartID;
                prod.Name = product.Name;
                prod.Car = product.Car;
                prod.Description = product.Description;
                prod.Image = product.Image;
                prod.QuantityInHand = product.QuantityInHand;

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
        }

        public void DeleteProductFromCart(int ProductID)
        {
            try
            {
                Product prod = ctx.Products.Where(rec => rec.ProductID == ProductID).FirstOrDefault();
                ctx.Products.Remove(prod);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
        }  
    }
}

using MvcSiteMapProvider;
using Pharmacy_Online.Data_Access_Layer;
using Pharmacy_Online.Models;
using System.Collections.Generic;

namespace Pharmacy_Online.Infrastructure
{
    public class ProductsDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {
        private ProductsContext _db = new ProductsContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Product product in _db.Products)
            {
                DynamicNode node = new DynamicNode();
                node.Title = product.Name;
                node.Key = "Products_" + product.ProductId;
                node.ParentKey = "Category_" + product.CategoryId;
                node.RouteValues.Add("id", product.ProductId);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}
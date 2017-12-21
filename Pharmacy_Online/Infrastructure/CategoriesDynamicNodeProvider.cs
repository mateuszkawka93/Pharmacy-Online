using MvcSiteMapProvider;
using Pharmacy_Online.Data_Access_Layer;
using Pharmacy_Online.Models;
using System.Collections.Generic;

namespace Pharmacy_Online.Infrastructure
{
    public class CategoriesDynamicNodeProvider : DynamicNodeProviderBase
    {
        private ProductsContext _db = new ProductsContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Category category in _db.Categories)
            {
                DynamicNode node = new DynamicNode();
                node.Title = category.Name;
                node.Key = "Category_" + category.CategoryId;
                node.RouteValues.Add("categoryname", category.Name);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}
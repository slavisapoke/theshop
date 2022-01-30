using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Common.DTO.Enums
{
    /// <summary>
    /// Just an example states of an article for one supplier
    /// it may not be applicable in a real design where there should be Inventory, shipment, payment services...
    /// </summary>
    public enum ArticleStockState
    {
        OutOfStock = 0,  //default, could be at this supplier but than moved, damaged...
        InStock,     //at the current supplier
        Ordered,     //still at the supplier, not shipped yet but not for selling 
        Departured   //sent to the consumer (generally out of stock)
        //some more...
    }
}

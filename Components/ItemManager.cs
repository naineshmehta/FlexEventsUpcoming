/*
' Copyright (c) 2017 NM
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
using System.Data;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using NM.Modules.FlexEventsUpcoming.Models;

namespace NM.Modules.FlexEventsUpcoming.Components
{
    interface IItemManager
    {
        IEnumerable<Item> GetItems(int moduleId, int portalId, int records);
    }

    class ItemManager : ServiceLocator<IItemManager, ItemManager>, IItemManager
    {
        public IEnumerable<Item> GetItems(int moduleId, int portalId, int recordsToReturn)
        {
            IEnumerable<Item> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                t = ctx.ExecuteQuery<Item>(CommandType.StoredProcedure, "FlexEventsUpcoming_Get", moduleId, portalId, recordsToReturn);
            }
            return t;
        }


        protected override System.Func<IItemManager> GetFactory()
        {
            return () => new ItemManager();
        }
    }
}

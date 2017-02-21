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

using System;
using System.Web.Mvc;
using DotNetNuke.Common;
using DotNetNuke.Entities.Tabs;
using NM.Modules.FlexEventsUpcoming.Components;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using NM.Modules.FlexEventsUpcoming.Models;

namespace NM.Modules.FlexEventsUpcoming.Controllers
{
    [DnnHandleError]
    public class ItemController : DnnController
    {
        public ActionResult Index()
        {
            var records = ModuleContext.Settings["FlexEventsUpcoming_Setting1"];

            var items = ItemManager.Instance.GetItems(ModuleContext.ModuleId, PortalSettings.PortalId, Convert.ToInt32(records));

            foreach (var item in items)
            {
                var urlFormat = "{0}/ctl/ViewEvent/mid/{1}/OccuranceId/{2}";
                item.Url =
                    string.Format(urlFormat, Globals.NavigateURL(TabController.GetTabByTabPath(PortalSettings.PortalId, "//FestivalCalendar",
                        string.Empty)), item.ModuleId, item.ItemId);
            }
            
            return View(items);
        }
    }
}

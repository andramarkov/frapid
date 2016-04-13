﻿using System.Web.Mvc;
using Frapid.ApplicationState.Cache;
using Frapid.Areas;
using Frapid.Areas.Authorization;
using Frapid.Dashboard.DAL;
using Frapid.i18n;

namespace Frapid.Dashboard.Controllers
{
    public class MenuController : FrapidController
    {
        [Route("dashboard/my/menus")]
        [RestrictAnonymous]
        public ActionResult GetMenus()
        {
            int userId = AppUsers.GetCurrent().UserId;
            int officeId = AppUsers.GetCurrent().OfficeId;
            string culture = CultureManager.GetCurrent().TwoLetterISOLanguageName;
            string tenant = AppUsers.GetTenant();

            return this.Ok(Menu.Get(tenant, userId, officeId, culture));
        }
    }
}
using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Frontend.Mvc.Models;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.Mvc.Controllers
{
    /// <summary>
    /// Filtered sessions widget controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [ControllerToolboxItem(Name = "FilteredSessions", Title = "Filtered Sessions", SectionName = "Custom MVC Widgets")]
    public class FilteredSessionsController : Controller
    {
        public Guid ConferenceId { get; set; }

        public Guid SpeakerId { get; set; }

        /// <summary>
        /// This is the default Action.
        /// </summary>
        public ActionResult Index()
        {
            var model = new FilteredSessionsModel();

            string sessionTypeName = "Telerik.Sitefinity.DynamicTypes.Model.Sessions.Session";
            string speakerTypeName = "Telerik.Sitefinity.DynamicTypes.Model.Speakers.Speaker";
            string conferenceTypeName = "Telerik.Sitefinity.DynamicTypes.Model.Conferences.Conference";

            #region Get sessions by speaker

            var speakerProviderName = DynamicModuleManager.GetDefaultProviderName("Speakers");
            DynamicModuleManager speakersManager = DynamicModuleManager.GetManager(speakerProviderName);
            Type speakerType = TypeResolutionService.ResolveType(speakerTypeName);
            DynamicContent speaker = speakersManager.GetDataItems(speakerType).Where(s => s.Id == this.SpeakerId).FirstOrDefault();

            IEnumerable<IDataItem> sessionsBySpeaker = Enumerable.Empty<IDataItem>();
            if (speaker != null)
            {
                model.Speaker = new ItemViewModel(speaker);
                string sessionProviderName = DynamicModuleManager.GetDefaultProviderName("Sessions");
                sessionsBySpeaker = speaker.GetRelatedParentItems(sessionTypeName, sessionProviderName);
            }

            #endregion

            #region Get sessions by conference

            string conferenceProviderName = DynamicModuleManager.GetDefaultProviderName("Conferences");
            DynamicModuleManager conferencesManager = DynamicModuleManager.GetManager(conferenceProviderName);
            IEnumerable<IDataItem> sessionsByConference = Enumerable.Empty<IDataItem>();
            Type conferenceType = TypeResolutionService.ResolveType(conferenceTypeName);
            DynamicContent conference = conferencesManager.GetDataItems(conferenceType).Where(s => s.Id == this.ConferenceId).FirstOrDefault();
            if (conference != null)
            {
                model.Conference = new ItemViewModel(conference);
                sessionsByConference = conference.GetRelatedItems("Sessions");
            }

            #endregion

            #region Extract the resulting collection of speakers

            IEnumerable<IDataItem> result = null;
            if (speaker != null && conference != null)
            {
                result = sessionsBySpeaker.Intersect(sessionsByConference);
            }
            else if (speaker != null)
            {
                result = sessionsBySpeaker;
            }
            else
            {
                result = sessionsByConference;
            }
            
            model.Items = result.Select(s => new ItemViewModel(s));
            
            #endregion

            return View("Default", model);
        }
    }
}
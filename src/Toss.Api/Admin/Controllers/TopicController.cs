using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Topics;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Services.Topics;
using System.Threading.Tasks;
using System.Linq;
using System;
using Nop.Web.Framework.Mvc.Filters;
using Toss.Api.Admin.Models.Topics;
using Toss.Api.Admin.Infrastructure.Mapper.Extensions;
using Toss.Api.Admin.Factories;

namespace Toss.Api.Admin.Controllers
{
    [Route("api/admin/topics")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IStoreService _storeService;
        private readonly ITopicModelFactory _topicModelFactory;
        private readonly ITopicService _topicService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IGenericAttributeService _genericAttributeService;

        #endregion

        #region Ctor

        public TopicController(
            IAclService aclService,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            INotificationService notificationService,
            IPermissionService permissionService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            ITopicModelFactory topicModelFactory,
            ITopicService topicService,
            IUrlRecordService urlRecordService,
            IGenericAttributeService genericAttributeService)
        {
            _aclService = aclService;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _localizationService = localizationService;
            _localizedEntityService = localizedEntityService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _storeMappingService = storeMappingService;
            _storeService = storeService;
            _topicModelFactory = topicModelFactory;
            _topicService = topicService;
            _urlRecordService = urlRecordService;
            _genericAttributeService = genericAttributeService;
        }

        #endregion

        #region Utilities

        private async Task UpdateLocalesAsync(Topic topic, TopicModel model)
        {
            foreach (var localized in model.Locales)
            {
                await _localizedEntityService.SaveLocalizedValueAsync(topic, x => x.Title, localized.Title, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(topic, x => x.Body, localized.Body, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(topic, x => x.MetaKeywords, localized.MetaKeywords, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(topic, x => x.MetaDescription, localized.MetaDescription, localized.LanguageId);
                await _localizedEntityService.SaveLocalizedValueAsync(topic, x => x.MetaTitle, localized.MetaTitle, localized.LanguageId);

                var seName = await _urlRecordService.ValidateSeNameAsync(topic, localized.SeName, localized.Title, false);
                await _urlRecordService.SaveSlugAsync(topic, seName, localized.LanguageId);
            }
        }

        private async Task SaveStoreMappingsAsync(Topic topic, TopicModel model)
        {
            topic.LimitedToStores = model.SelectedStoreIds.Any();
            await _topicService.UpdateTopicAsync(topic);

            var existingStoreMappings = await _storeMappingService.GetStoreMappingsAsync(topic);
            var allStores = await _storeService.GetAllStoresAsync();
            foreach (var store in allStores)
            {
                if (model.SelectedStoreIds.Contains(store.Id))
                {
                    if (!existingStoreMappings.Any(sm => sm.StoreId == store.Id))
                        await _storeMappingService.InsertStoreMappingAsync(topic, store.Id);
                }
                else
                {
                    var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                    if (storeMappingToDelete != null)
                        await _storeMappingService.DeleteStoreMappingAsync(storeMappingToDelete);
                }
            }
        }

        #endregion

        #region List

        [HttpGet("list")]
        [CheckPermission(StandardPermission.ContentManagement.TOPICS_VIEW)]
        public async Task<IActionResult> List()
        {
            var model = await _topicModelFactory.PrepareTopicSearchModelAsync(new TopicSearchModel());
            return Ok(model);
        }

        [HttpPost("list")]
        [CheckPermission(StandardPermission.ContentManagement.TOPICS_VIEW)]
        public async Task<IActionResult> GetTopicList(TopicSearchModel searchModel)
        {
            var model = await _topicModelFactory.PrepareTopicListModelAsync(searchModel);
            return Ok(model);
        }

        #endregion

        #region Create / Edit / Delete

        [HttpPost("create")]
        [CheckPermission(StandardPermission.ContentManagement.TOPICS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Create(TopicModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!model.IsPasswordProtected)
                model.Password = null;

            var topic = model.ToEntity<Topic>();
            await _topicService.InsertTopicAsync(topic);

            model.SeName = await _urlRecordService.ValidateSeNameAsync(topic, model.SeName, topic.Title ?? topic.SystemName, true);
            await _urlRecordService.SaveSlugAsync(topic, model.SeName, 0);

            await SaveStoreMappingsAsync(topic, model);
            await UpdateLocalesAsync(topic, model);

            await _customerActivityService.InsertActivityAsync("AddNewTopic",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.AddNewTopic"), topic.Title ?? topic.SystemName), topic);

            return CreatedAtAction(nameof(GetTopic), new { id = topic.Id }, topic);
        }

        [HttpGet("{id}")]
        [CheckPermission(StandardPermission.ContentManagement.TOPICS_VIEW)]
        public async Task<IActionResult> GetTopic(int id)
        {
            var topic = await _topicService.GetTopicByIdAsync(id);
            if (topic == null)
                return NotFound();

            var model = await _topicModelFactory.PrepareTopicModelAsync(null, topic);
            return Ok(model);
        }

        [HttpPut("{id}")]
        [CheckPermission(StandardPermission.ContentManagement.TOPICS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Edit(int id, TopicModel model)
        {
            var topic = await _topicService.GetTopicByIdAsync(id);
            if (topic == null)
                return NotFound();

            if (!model.IsPasswordProtected)
                model.Password = null;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            topic = model.ToEntity(topic);
            await _topicService.UpdateTopicAsync(topic);

            model.SeName = await _urlRecordService.ValidateSeNameAsync(topic, model.SeName, topic.Title ?? topic.SystemName, true);
            await _urlRecordService.SaveSlugAsync(topic, model.SeName, 0);

            await SaveStoreMappingsAsync(topic, model);
            await UpdateLocalesAsync(topic, model);

            await _customerActivityService.InsertActivityAsync("EditTopic",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditTopic"), topic.Title ?? topic.SystemName), topic);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [CheckPermission(StandardPermission.ContentManagement.TOPICS_CREATE_EDIT_DELETE)]
        public async Task<IActionResult> Delete(int id)
        {
            var topic = await _topicService.GetTopicByIdAsync(id);
            if (topic == null)
                return NotFound();

            await _topicService.DeleteTopicAsync(topic);
            await _customerActivityService.InsertActivityAsync("DeleteTopic",
                string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteTopic"), topic.Title ?? topic.SystemName), topic);

            return NoContent();
        }

        #endregion
    }
}

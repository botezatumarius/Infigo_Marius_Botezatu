using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.CommentModels;
using CMSPlus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using AutoMapper;
using FluentValidation.AspNetCore;
using CMSPlus.Services.Services;

namespace CMSPlus.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;
        private readonly IValidator<CommentCreateModel> _commentCreateModelValidator;

        public CommentController(ICommentService commentService, ITopicService topicService, IMapper mapper, IValidator<CommentCreateModel> commentCreateModelValidator)
        {
            _commentService = commentService;
            _topicService = topicService;
            _mapper = mapper;
            _commentCreateModelValidator = commentCreateModelValidator;
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync(int topicId)
        {
            var topic = await _topicService.GetById(topicId);
            var model = new CommentCreateModel
            {
                TopicId = topicId,
                TopicSystemName = topic.SystemName
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateModel comment)
        {
            var validationResult = await _commentCreateModelValidator.ValidateAsync(comment);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View(comment);
            }

            var commentEntity = _mapper.Map<CommentCreateModel, CommentEntity>(comment);
            await _commentService.Create(commentEntity);

            var topic = await _topicService.GetById(comment.TopicId);
            if (topic == null)
            {
                throw new ArgumentException("Topic not found");
            }
            return RedirectToAction("Details", "Topic", new { systemName = topic.SystemName });
        }

    }
}

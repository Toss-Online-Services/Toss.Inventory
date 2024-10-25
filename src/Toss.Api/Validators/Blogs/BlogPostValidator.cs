using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Toss.Api.Models.Blogs;

namespace Toss.Api.Validators.Blogs;

public partial class BlogPostValidator : BaseNopValidator<BlogPostModel>
{
    public BlogPostValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.AddNewComment.CommentText).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Blog.Comments.CommentText.Required")).When(x => x.AddNewComment != null);
    }
}
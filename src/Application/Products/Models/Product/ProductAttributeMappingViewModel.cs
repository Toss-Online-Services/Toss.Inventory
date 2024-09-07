namespace Application.Products.Models.Product;













//validation fields
/// <summary>
/// Represents a product attribute mapping
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="ProductAttributeId"> Gets or sets the product attribute identifier </param>
/// <param name="TextPrompt"> Gets or sets a value a text prompt </param>
/// <param name="IsRequired"> Gets or sets a value indicating whether the entity is required </param>
/// <param name="AttributeControlTypeId"> Gets or sets the attribute control type identifier </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
/// <param name="ValidationMinLength"> Gets or sets the validation rule for minimum length (for textbox and multiline textbox) </param>
/// <param name="ValidationMaxLength"> Gets or sets the validation rule for maximum length (for textbox and multiline textbox) </param>
/// <param name="ValidationFileAllowedExtensions"> Gets or sets the validation rule for file allowed extensions (for file upload) </param>
/// <param name="ValidationFileMaximumSize"> Gets or sets the validation rule for file maximum size in kilobytes (for file upload) </param>
/// <param name="DefaultValue"> Gets or sets the default value (for textbox and multiline textbox) </param>
/// <param name="ConditionAttributeXml"> Gets or sets a condition (depending on other attribute) when this attribute should be enabled (visible).
/// Leave empty (or null) to enable this attribute.
/// Conditional attributes that only appear if a previous attribute is selected, such as having an option 
/// for personalizing clothing with a name and only providing the text input box if the "Personalize" radio button is checked. </param>
public record ProductAttributeMappingViewModel(int ProductId, int ProductAttributeId, string TextPrompt, bool IsRequired, int AttributeControlTypeId, int DisplayOrder, int? ValidationMinLength, int? ValidationMaxLength, string ValidationFileAllowedExtensions, int? ValidationFileMaximumSize, string DefaultValue, string ConditionAttributeXml);

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Exceptions;
using Pgvector;

namespace Application.Products.Models.Product;
















// Quantity in stock
// Available stock at which we should reorder
// Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Price"></param>
/// <param name="PictureFileName"></param>
/// <param name="CatalogTypeId"></param>
/// <param name="CatalogType"></param>
/// <param name="CatalogBrandId"></param>
/// <param name="CatalogBrand"></param>
/// <param name="AvailableStock"></param>
/// <param name="RestockThreshold"></param>
/// <param name="MaxStockThreshold"></param>
/// <param name="Embedding">Optional embedding for the catalog item's description.</param>
/// <param name="OnReorder"> True if item is on reorder </param>
public record CatalogItemViewModel(int Id, string Name, string Description, decimal Price, string PictureFileName, int CatalogTypeId, CatalogTypeViewModel CatalogType, int CatalogBrandId, CatalogBrandViewModel CatalogBrand, int AvailableStock, int RestockThreshold, int MaxStockThreshold, Vector Embedding, bool OnReorder);

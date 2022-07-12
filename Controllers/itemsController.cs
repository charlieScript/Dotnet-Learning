using System;
using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Dtos;

namespace Catalog.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class itemsController : ControllerBase
  {
    private readonly IItemInterface repository;

    private readonly ILogger<itemsController> _logger;

    public itemsController(ILogger<itemsController> logger, IItemInterface _respository)
    {
      // used in initialisng providers
      _logger = logger;
      this.repository = _respository;
    }

    // public itemsController()
    // {
    //   repository = new ItemRepo();
    // }

    [HttpGet()]
    public IEnumerable<ItemDto> GetItems()
    {
      var items = repository.GetItems().Select(x => new ItemDto(x));
      return items;
    }

    public class NotFoundResponse
    {
      public string? message { get; set; }

      //constructor
      public NotFoundResponse(string _message)
      {
        message = _message;
      }
    }

    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {
      try
      {
        var item = repository.GetItem(id);

        if (item is null)
        {
          return NotFound(new NotFoundResponse("no item was found"));
        }
        return ItemDto.AsDto(item);
      }
      catch (HttpRequestException e)
      {
        _logger.LogInformation(e.Message);
        return BadRequest();
      }

    }

    [HttpPost("")]
    public ActionResult<ItemDto> CreateItem(CreateItemDto _item)
    {
      Item item = new()
      {
        Id = Guid.NewGuid(),
        name = _item.name,
        price = _item.price,
      };

      repository.CreateItem(item);

      return CreatedAtAction(nameof(CreateItem), ItemDto.AsDto(item));
    }

    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateItemDto _item)
    {
      var existingItem = repository.GetItem(id);

      if (existingItem is null)
      {
        return NotFound();
      }

      Item updatedItem = existingItem with
      {
        name = _item.name,
        price = _item.price
      };

      repository.UpdateItem(updatedItem);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteItem(Guid id)
    {
      var existingItem = repository.GetItem(id);
      var error = Convert.ToString(existingItem);
      _logger.LogError(error);
      if (existingItem is null)
      {
        return NotFound();
      }

      repository.DeleteItem(id);

      return NoContent();
    }
  }
}
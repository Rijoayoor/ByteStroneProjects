﻿using service.Core.ContributorAggregate;
using service.SharedKernel.Interfaces;
using FastEndpoints;

namespace service.Web.Endpoints.ContributorEndpoints;

public class Create : Endpoint<CreateContributorRequest, CreateContributorResponse>
{
  private readonly IRepository<Contributor> _repository;

  public Create(IRepository<Contributor> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Post(CreateContributorRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ContributorEndpoints"));
  }
  public override async Task HandleAsync(
    CreateContributorRequest request,
    CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      ThrowError("Name is required");
    }

    var newContributor = new Contributor(request.Name);
    var createdItem = await _repository.AddAsync(newContributor, cancellationToken);
    var response = new CreateContributorResponse
    (
      id: createdItem.Id,
      name: createdItem.Name
    );

    await SendAsync(response);
  }
}
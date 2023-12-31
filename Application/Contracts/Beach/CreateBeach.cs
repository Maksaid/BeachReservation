﻿using Application.Dto;
using MediatR;

namespace Application.Contracts.Beach;

public static class CreateBeach
{
    public record struct Command(Guid CurrentUserId, string Name, string Description, int RowsCount, int ColsCount, List<int> Indexes,string Country, string City, string Longitude, string Latitude) : IRequest<Response>;

    public record struct Response(BeachDto BeachDto);
}
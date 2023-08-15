﻿using Application.Dto;
using Domain.Models;
using MediatR;

namespace Application.Contracts.Beach;

public static class AddImages
{
    public record struct Command(byte[] Data, Guid BeachId, PictureType PictureType) : IRequest<Response>
    {
    }

    public record struct Response(BeachDto UpdatedBeachDto);

}
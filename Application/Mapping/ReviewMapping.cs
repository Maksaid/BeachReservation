using Application.Dto;
using Domain.Entities;

namespace Application.Mapping;

public static class ReviewMapping
{
    public static ReviewDto AsDto(this Review review)
        => new ReviewDto(review.Id, review.Text, review.Score, review.Author.Id, review.Beach.Id);


}
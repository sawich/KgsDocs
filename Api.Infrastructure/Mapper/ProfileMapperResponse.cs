using Api.Domain.Responses;
using Api.Domain.Responses.Tasks;
using Api.Infrastructure.Persistent.Models;
using AutoMapper;

namespace Api.Infrastructure.Mapper;

internal sealed class ProfileMapperResponse : Profile
{
    public ProfileMapperResponse()
    {
        DefineUser();
        DefineTask();
        DefineDiscussion();
    }

    private void DefineUser() => CreateMap<UserModel, UserResponse>()
        .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
        .ForMember(e => e.Name, e => e.MapFrom(e => e.UserName));

    private void DefineTask() => CreateMap<TaskModel, TaskResponse>()
        .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
        .ForMember(e => e.Type, e => e.MapFrom(e => e.Type))
        .ForMember(e => e.Author, e => e.MapFrom(e => e.Author))
        .ForMember(e => e.State, e => e.MapFrom(e => e.State))
        .ForMember(e => e.Until, e => e.MapFrom(e => e.Until));

    private void DefineDiscussion() => CreateMap<DiscussionModel, DiscussionResponse>()
        .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
        .ForMember(e => e.Text, e => e.MapFrom(e => e.Text))
        .ForMember(e => e.Author, e => e.MapFrom(e => e.Author))
        .ForMember(e => e.PostedAt, e => e.MapFrom(e => e.PostedAt));
}

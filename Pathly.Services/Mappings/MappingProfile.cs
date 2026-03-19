using AutoMapper;
using Pathly.DataModels;
using Pathly.ViewModels;
using Pathly.ViewModels.Dashboard;
using Pathly.ViewModels.Goals;
using Pathly.ViewModels.Roadmaps;
using Pathly.ViewModels.Tags;
using Pathly.ViewModels.TasksViewModels;

namespace Pathly.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // --- GOALS ---
            CreateMap<Goal, GoalViewModel>()
                .ForMember(dest => dest.HasRoadmap, opt => opt.MapFrom(src => src.Roadmap != null))
                .ForMember(dest => dest.RoadmapId, opt => opt.MapFrom(src => src.Roadmap != null ? src.Roadmap.Id : (int?)null))
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<Goal, GoalCreateViewModel>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<Goal, GoalEditViewModel>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<GoalDetailsViewModel, GoalEditViewModel>();

            CreateMap<Goal, GoalDetailsViewModel>()
                .ForMember(dest => dest.Actions, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<RoadmapCreateViewModel, Goal>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.NewGoalTitle))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.NewGoalDescription))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // --- ROADMAPS & ACTIONS ---
            CreateMap<Roadmap, RoadmapDetailsViewModel>()
                .ForMember(dest => dest.GoalTitle, opt => opt.MapFrom(src => src.Goal.Title))
                .ForMember(dest => dest.GoalDescription, opt => opt.MapFrom(src => src.Goal.ShortDescription))
                .ForMember(dest => dest.Actions, opt => opt.MapFrom(src => src.Actions))
                .ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.GoalId, opt => opt.Ignore());

            CreateMap<Roadmap, RoadmapCreateViewModel>()
                .ForMember(dest => dest.RoadmapId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SelectedGoalId, opt => opt.MapFrom(src => src.GoalId))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.GoalId, opt => opt.Ignore());

            CreateMap<RoadmapPlannerViewModel, RoadmapPlannerViewModel>();

            CreateMap<ActionItem, ActionsDisplayViewModel>()
                .ForMember(dest => dest.ActionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AssignedTasks, opt => opt.MapFrom(src => src.Tasks))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.RoadmapId, opt => opt.Ignore());

            CreateMap<ActionItemCreateViewModel, ActionItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.RoadmapId, opt => opt.Ignore());

            CreateMap<ActionItem, ActionItemCreateViewModel>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.RoadmapId, opt => opt.Ignore());

            // --- TASKS ---

            CreateMap<TaskItem, TaskViewModel>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src =>
                    src.TaskTags.Select(tt => tt.Tag.Name).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.TaskTags, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.ActionId, opt => opt.Ignore());

            CreateMap<TaskItem, TaskSummaryViewModel>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.ActionId, opt => opt.Ignore());

            CreateMap<TaskItem, TaskCreateViewModel>().ReverseMap()
                 .ForMember(dest => dest.TaskTags, opt => opt.Ignore())
                 .ForMember(dest => dest.UserId, opt => opt.Ignore())
                 .ForMember(dest => dest.ActionId, opt => opt.Ignore())
                 .ForMember(dest => dest.Action, opt => opt.Ignore());

            CreateMap<TaskItem, TaskEditViewModel>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.ActionId, opt => opt.Ignore());

            CreateMap<TaskDetailsViewModel, TaskEditViewModel>();

            CreateMap<TaskItem, TaskDetailsViewModel>()
                .IncludeBase<TaskItem, TaskViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.ActionId, opt => opt.Ignore());

            CreateMap<TaskItem, TaskDeleteViewModel>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // --- TAGS ---
            CreateMap<Tag, TagViewModel>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // --- DASHBOARD ---
            CreateMap<TaskItem, TaskSummaryViewModel>().ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<DashboardFocusListsViewModel, DashboardFocusListsViewModel>();
        }
    }
}
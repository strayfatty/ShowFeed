namespace ShowFeed.App_Start
{
    using System.Linq;

    using AutoMapper;

    using ShowFeed.Models;
    using ShowFeed.Services;
    using ShowFeed.ViewModels;

    using WebMatrix.WebData;

    /// <summary>
    /// The AutoMapper configuration class.
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Registers all mappings.
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.CreateMap<IBaseSeriesRecord, Series>();
            Mapper.CreateMap<IBaseEpisodeRecord, Episode>();

            Mapper.CreateMap<Series, SeriesDetailsViewModel>()
                .ForMember(dest => dest.Episodes, opt => opt.Ignore());
        }
    }
}
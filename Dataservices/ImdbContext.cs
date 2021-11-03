using System;
using System.Linq;
using System.Text;
using Dataservices.Domain;
using Dataservices.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql;

namespace Dataservices
{
    public class ImdbContext : DbContext
    {
        public DbSet<ImdbGenre> ImdbGenre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("host=localhost;db=northwindfinalfinal;uid=postgres;pwd=Pedal14;Encoding=UTF-8;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            
            //Imdb Related Mapping
            //ImdbGenre TODO: Missing foreign key notation for Tconst
            modelBuilder.Entity<ImdbGenre>().ToTable("imdb_genre");
            modelBuilder.Entity<ImdbGenre>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbGenre>().Property(x => x.Genre).HasColumnName("genre");
            modelBuilder.Entity<ImdbGenre>().HasKey(x => x.Tconst);
            
            //ImdbCrew TODO: 
            modelBuilder.Entity<ImdbCrew>().ToTable("imdb_crew");
            modelBuilder.Entity<ImdbCrew>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbCrew>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbCrew>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<ImdbCrew>().Property(x => x.Job).HasColumnName("job");
            //TODO: Needs composite key
            modelBuilder.Entity<ImdbCrew>().HasKey(x => x.Tconst);
            
            //ImdbCast TODO:
            modelBuilder.Entity<ImdbCast>().ToTable("imdb_cast");
            modelBuilder.Entity<ImdbCast>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbCast>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbCast>().Property(x => x.CharacterName).HasColumnName("charachtername");
            modelBuilder.Entity<ImdbCast>().Property(x => x.Rating).HasColumnName("rating");
            //TODO: Needs composite key
            modelBuilder.Entity<ImdbCast>().HasKey(x => x.Tconst);
            
            //ImdbKnowFor TODO:
            modelBuilder.Entity<ImdbKnownFor>().ToTable("imdb_known_for");
            modelBuilder.Entity<ImdbKnownFor>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbKnownFor>().Property(x => x.Tconst).HasColumnName("tconst");
            //TODO: Needs composite key
            modelBuilder.Entity<ImdbKnownFor>().HasKey(x => x.Tconst);

            //ImdbNameBasics TODO:
            modelBuilder.Entity<ImdbNameBasics>().ToTable("imdb_name_basics");
            modelBuilder.Entity<ImdbNameBasics>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbNameBasics>().Property(x => x.Name).HasColumnName("name");
            modelBuilder.Entity<ImdbNameBasics>().Property(x => x.BirthYear).HasColumnName("birthyear");
            modelBuilder.Entity<ImdbNameBasics>().Property(x => x.DeathYear).HasColumnName("deathyear");
            modelBuilder.Entity<ImdbNameBasics>().HasKey(x => x.Nconst);
            
            //ImdbPrimeProfession TODO:
            modelBuilder.Entity<ImdbPrimeProfession>().ToTable("imdb_prime_profession");
            modelBuilder.Entity<ImdbPrimeProfession>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbPrimeProfession>().Property(x => x.Profession).HasColumnName("profession");
            modelBuilder.Entity<ImdbPrimeProfession>().HasKey(x => x.Nconst);
            
            //ImdbTitleAkas TODO:
            modelBuilder.Entity<ImdbTitleAkas>().ToTable("imdb_title_akas");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Title).HasColumnName("title");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.IsOriginalTitle).HasColumnName("is_original_title");
            modelBuilder.Entity<ImdbTitleAkas>().HasKey(x => x.Tconst);

            //ImdbTitleBasics TODO:
            modelBuilder.Entity<ImdbTitleBasics>().ToTable("imdb_title_basics");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.TitleType).HasColumnName("titletype");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.IsAdult).HasColumnName("isadult");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.StartYear).HasColumnName("startyear");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.RunTime).HasColumnName("runtime");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.Plot).HasColumnName("plot");
            modelBuilder.Entity<ImdbTitleBasics>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<ImdbTitleBasics>().HasKey(x => x.Tconst);

            //ImdbTitleEpisode TODO:
            modelBuilder.Entity<ImdbTitleEpisode>().ToTable("imdb_title_episode");
            modelBuilder.Entity<ImdbTitleEpisode>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbTitleEpisode>().Property(x => x.EpisodeTconst).HasColumnName("episode_tconst");
            modelBuilder.Entity<ImdbTitleEpisode>().Property(x => x.SeasonNumber).HasColumnName("season_number");
            modelBuilder.Entity<ImdbTitleEpisode>().Property(x => x.EpisodeNumber).HasColumnName("episode_number");
            //TODO: Need composite key
            modelBuilder.Entity<ImdbTitleEpisode>().HasKey(x => x.Tconst);
            
            //ImdbTitleRatings TODO:
            modelBuilder.Entity<ImdbTitleRatings>().ToTable("imdb_title_ratings");
            modelBuilder.Entity<ImdbTitleRatings>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbTitleRatings>().Property(x => x.SumRating).HasColumnName("sum_rating");
            modelBuilder.Entity<ImdbTitleRatings>().Property(x => x.NumVotes).HasColumnName("numvotes");
            modelBuilder.Entity<ImdbTitleRatings>().HasKey(x => x.Tconst);

            
            //User Related Mapping
            //CBookMarkPerson
            modelBuilder.Entity<CBookmarkPerson>().ToTable("c_bookmark_person");
            modelBuilder.Entity<CBookmarkPerson>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<CBookmarkPerson>().Property(x => x.UserId).HasColumnName("user_id");
            //TODO: Need composite key 
            modelBuilder.Entity<CBookmarkPerson>().HasKey(x => x.Nconst);
            
            //CBookmarkTitle
            modelBuilder.Entity<CBookmarkTitle>().ToTable("c_bookmark_title");
            modelBuilder.Entity<CBookmarkTitle>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<CBookmarkTitle>().Property(x => x.UserId).HasColumnName("user_id");
            //TODO: Need composite key 
            modelBuilder.Entity<CBookmarkTitle>().HasKey(x => x.Tconst);

            //CRatingHistory
            modelBuilder.Entity<CRatingHistory>().ToTable("c_rating_history");
            modelBuilder.Entity<CRatingHistory>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<CRatingHistory>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<CRatingHistory>().Property(x => x.Rating).HasColumnName("rating");
            modelBuilder.Entity<CRatingHistory>().Property(x => x.RatingTimeStamp).HasColumnName("rating_time_stamp");
            //TODO: Need composite key 
            modelBuilder.Entity<CRatingHistory>().HasKey(x => x.Tconst);
            
            //CReviews
            modelBuilder.Entity<CReviews>().ToTable("c_reviews");
            modelBuilder.Entity<CReviews>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<CReviews>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<CReviews>().Property(x => x.Review).HasColumnName("Review");
            modelBuilder.Entity<CReviews>().Property(x => x.ReviewTimpStamp).HasColumnName("review_time_stamp");
            //TODO: Need composite key 
            modelBuilder.Entity<CReviews>().HasKey(x => x.Tconst);

            //CSearchHistory
            modelBuilder.Entity<CSearchHistory>().ToTable("c_search_history");
            modelBuilder.Entity<CSearchHistory>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<CSearchHistory>().Property(x => x.SearchPhrase).HasColumnName("search_phrase");
            modelBuilder.Entity<CSearchHistory>().Property(x => x.SearchHistoryTimeStamp).HasColumnName("sh_time_stamp");
            //TODO: Need composite key 
            modelBuilder.Entity<CSearchHistory>().HasKey(x => x.UserId);

            //CUser
            modelBuilder.Entity<CUser>().ToTable("c_user");
            modelBuilder.Entity<CUser>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<CUser>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<CUser>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<CUser>().Property(x => x.Password).HasColumnName("password");
            //TODO: Need composite key 
            modelBuilder.Entity<CSearchHistory>().HasKey(x => x.UserId);

        }

    }
    
}
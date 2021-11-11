using Dataservices.Domain;
using Dataservices.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Dataservices
{
    using Domain.FunctionObjects;

    public class ImdbContext : DbContext
    {
        public DbSet<ImdbGenre> ImdbGenre { get; set; }
        public DbSet<ImdbCrew> ImdbCrew { get; set; }
        public DbSet<ImdbCast> ImdbCast { get; set; }
        public DbSet<ImdbKnownFor> ImdbKnownFor { get; set; }
        public DbSet<ImdbNameBasics> ImdbNameBasics { get; set; }
        public DbSet<ImdbPrimeProfession> ImdbPrimeProfession { get; set; }
        public DbSet<ImdbTitleAkas> ImdbTitleAkas { get; set; }
        public DbSet<ImdbTitleBasics> ImdbTitleBasics { get; set; }
        public DbSet<ImdbTitleEpisode> ImdbTitleEpisode { get; set; }
        public DbSet<ImdbTitleRatings> ImdbTitleRatings { get; set; }
        public DbSet<CBookmarkPerson> CBookmarkPerson { get; set; }
        public DbSet<CBookmarkTitle> CBookmarkTitle { get; set; }
        public DbSet<CRatingHistory> CRatingHistory { get; set; }
        public DbSet<CReviews> CReviews { get; set; }
        public DbSet<CSearchHistory> CSearchHistory { get; set; }
        public DbSet<CUser> CUser { get; set; }
        
        //Functions
        public DbSet<MoviesByGenre> MoviesByGenres { get; set; }
        public DbSet<CoActors> CoActors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("host=rawdata.ruc.dk;port=5432;db=raw3;uid=raw3;pwd=UGiCUSoX;Encoding=UTF-8;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Imdb Related Mapping
            //ImdbNameBasics
            modelBuilder.Entity<ImdbNameBasics>().ToTable("imdb_name_basics");
            modelBuilder.Entity<ImdbNameBasics>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbNameBasics>().Property(x => x.Name).HasColumnName("name");
            modelBuilder.Entity<ImdbNameBasics>().Property(x => x.BirthYear).HasColumnName("birthyear");
            modelBuilder.Entity<ImdbNameBasics>().Property(x => x.DeathYear).HasColumnName("deathyear");
            modelBuilder.Entity<ImdbNameBasics>().HasKey(x => x.Nconst);
            modelBuilder.Entity<ImdbNameBasics>()
                .HasMany(x => x.BookmarkPersons)
                .WithOne(x => x.Name).HasForeignKey(x => x.Nconst);

            //ImdbGenre
            modelBuilder.Entity<ImdbGenre>().ToTable("imdb_genre");
            modelBuilder.Entity<ImdbGenre>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbGenre>().Property(x => x.Genre).HasColumnName("genre");
            modelBuilder.Entity<ImdbGenre>().HasKey(x => new {x.Tconst, x.Genre});
            
            //ImdbCrew
            modelBuilder.Entity<ImdbCrew>().ToTable("imdb_crew");
            modelBuilder.Entity<ImdbCrew>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbCrew>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbCrew>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<ImdbCrew>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<ImdbCrew>().HasKey(x => new {x.Nconst, x.Tconst});
            
            //ImdbCast
            modelBuilder.Entity<ImdbCast>().ToTable("imdb_cast");
            modelBuilder.Entity<ImdbCast>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbCast>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbCast>().Property(x => x.CharacterName).HasColumnName("charactername");
            modelBuilder.Entity<ImdbCast>().Property(x => x.Rating).HasColumnName("rating");
            modelBuilder.Entity<ImdbCast>().HasKey(x => new {x.Nconst, x.Tconst});
            
            //ImdbKnowFor
            modelBuilder.Entity<ImdbKnownFor>().ToTable("imdb_known_for");
            modelBuilder.Entity<ImdbKnownFor>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbKnownFor>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbKnownFor>().HasKey(x => new {x.Nconst, x.Tconst});

            //ImdbPrimeProfession
            modelBuilder.Entity<ImdbPrimeProfession>().ToTable("imdb_prime_profession");
            modelBuilder.Entity<ImdbPrimeProfession>().Property(x => x.Nconst).HasColumnName("nconst");
            modelBuilder.Entity<ImdbPrimeProfession>().Property(x => x.Profession).HasColumnName("profession");
            modelBuilder.Entity<ImdbPrimeProfession>().HasKey(x => new {x.Nconst, x.Profession});
            
            //ImdbTitleBasics
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
            modelBuilder.Entity<ImdbTitleBasics>().
                HasOne(x => x.Rating)
                .WithOne(x => x.Title)
                .HasForeignKey<ImdbTitleRatings>(x => x.Tconst);
            modelBuilder.Entity<ImdbTitleBasics>()
                .HasMany(x => x.Cast)
                .WithOne()
                .HasForeignKey(x => x.Tconst);
            modelBuilder.Entity<ImdbTitleBasics>()
                .HasMany(x => x.Episodes)
                .WithOne(x => x.MainTitle)
                .HasForeignKey(x => x.Tconst);
            modelBuilder.Entity<ImdbTitleBasics>()
                .HasMany(x => x.Crew)
                .WithOne()
                .HasForeignKey(x => x.Tconst);
            modelBuilder.Entity<ImdbTitleBasics>()
                .HasMany(x => x.Reviews)
                .WithOne(x => x.ReviewFor)
                .HasForeignKey(x => x.Tconst);
            modelBuilder.Entity<ImdbTitleBasics>()
                .HasOne(x => x.Rating)
                .WithOne(x => x.Title);
            modelBuilder.Entity<ImdbTitleBasics>()
                .HasMany(x => x.BeenBookmarkedBy)
                .WithOne(x => x.Title).HasForeignKey(x => x.Tconst);
            

            //ImdbTitleAkas
            modelBuilder.Entity<ImdbTitleAkas>().ToTable("imdb_title_akas");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Title).HasColumnName("title");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<ImdbTitleAkas>().Property(x => x.IsOriginalTitle).HasColumnName("is_original_title");
            modelBuilder.Entity<ImdbTitleAkas>().HasKey(x => new {x.Tconst, x.Ordering});

            //ImdbTitleEpisode
            modelBuilder.Entity<ImdbTitleEpisode>().ToTable("imdb_title_episode");
            modelBuilder.Entity<ImdbTitleEpisode>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<ImdbTitleEpisode>().Property(x => x.EpisodeTconst).HasColumnName("episode_tconst");
            modelBuilder.Entity<ImdbTitleEpisode>().Property(x => x.SeasonNumber).HasColumnName("season_number");
            modelBuilder.Entity<ImdbTitleEpisode>().Property(x => x.EpisodeNumber).HasColumnName("episode_number");
            modelBuilder.Entity<ImdbTitleEpisode>().HasKey(x => x.EpisodeTconst);
            
            //ImdbTitleRatings
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
            modelBuilder.Entity<CBookmarkPerson>().HasKey(x => new { x.Nconst, x.UserId });
            
            //CBookmarkTitle
            modelBuilder.Entity<CBookmarkTitle>().ToTable("c_bookmark_title");
            modelBuilder.Entity<CBookmarkTitle>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<CBookmarkTitle>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<CBookmarkTitle>().HasKey(x => new { x.Tconst, x.UserId });
            
            //CRatingHistory
            modelBuilder.Entity<CRatingHistory>().ToTable("c_rating_history");
            modelBuilder.Entity<CRatingHistory>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<CRatingHistory>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<CRatingHistory>().Property(x => x.Rating).HasColumnName("rating");
            modelBuilder.Entity<CRatingHistory>().Property(x => x.RatingTimeStamp).HasColumnName("rating_time_stamp");
            modelBuilder.Entity<CRatingHistory>().HasKey(x => new { x.Tconst, x.UserId });
            
            //CReviews
            modelBuilder.Entity<CReviews>().ToTable("c_reviews");
            modelBuilder.Entity<CReviews>().Property(x => x.Tconst).HasColumnName("tconst");
            modelBuilder.Entity<CReviews>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<CReviews>().Property(x => x.Review).HasColumnName("review");
            modelBuilder.Entity<CReviews>().Property(x => x.ReviewTimeStamp).HasColumnName("review_time_stamp");
            modelBuilder.Entity<CReviews>().HasKey(x => new { x.Tconst, x.UserId });

            //CSearchHistory
            modelBuilder.Entity<CSearchHistory>().ToTable("c_search_history");
            modelBuilder.Entity<CSearchHistory>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<CSearchHistory>().Property(x => x.SearchPhrase).HasColumnName("search_phrase");
            modelBuilder.Entity<CSearchHistory>().Property(x => x.SearchHistoryTimeStamp).HasColumnName("sh_time_stamp");
            modelBuilder.Entity<CSearchHistory>().HasKey(x => new { x.UserId, x.SearchPhrase });

            //CUser
            modelBuilder.Entity<CUser>().ToTable("c_user");
            modelBuilder.Entity<CUser>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<CUser>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<CUser>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<CUser>().Property(x => x.Password).HasColumnName("password");
            modelBuilder.Entity<CUser>().HasKey(x => x.UserId);
            modelBuilder.Entity<CUser>()
                .HasMany(x => x.Reviews)
                .WithOne(x => x.ReviewBy)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<CUser>()
                .HasMany(x => x.Ratings)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<CUser>()
                .HasMany(x => x.SearchHistories)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<CUser>()
                .HasMany(x => x.BookmarkedTitles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<CUser>()
                .HasMany(x => x.BookmarkedPersons)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            
            //Function mapping
            modelBuilder.Entity<MoviesByGenre>().Property(x => x.Tconst).HasColumnName("m_tconst");
            modelBuilder.Entity<MoviesByGenre>().Property(x => x.GenreCount).HasColumnName("genre_count");
            modelBuilder.Entity<MoviesByGenre>().HasNoKey();
            
            modelBuilder.Entity<CoActors>().Property(x => x.CoActorNconst).HasColumnName("co_actor_nconst");
            modelBuilder.Entity<CoActors>().Property(x => x.CoActorName).HasColumnName("co_actor_name");
            modelBuilder.Entity<CoActors>().Property(x => x.ActCount).HasColumnName("act_count");
            modelBuilder.Entity<CoActors>().HasNoKey();
            
            /*modelBuilder.HasDbFunction(typeof(ImdbContext)
                    .GetMethod(nameof(GetMoviesByGenre)
                        , new[] {typeof(string)}) ?? throw new InvalidOperationException())
                .HasName("similar_movies_genre");*/
            
            
            /*modelBuilder.HasDbFunction(typeof(ImdbContext)
                    .GetMethod(nameof(Rate)) ?? throw new InvalidOperationException())
                .HasName("rate");*/
        } 
        
        /*
        DONE public IQueryable<MoviesByGenre> GetMoviesByGenre(string movie) => FromExpression(() => GetMoviesByGenre(movie));
        DONE public void Rate(string genre) => throw new NotSupportedException();
        DONE public void AddReview(string genre) => throw new NotSupportedException();
        DONE public void AddToSearchHistory(string genre) => throw new NotSupportedException();
        DONE public void BookmarkTitle(string genre) => throw new NotSupportedException();
        DONE public void BookmarkPerson(string genre) => throw new NotSupportedException();
        public void GetTitleBookmarksByUser
        public void GetPersonBookmarksByUser
        */
        
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpeakersInc.Web.Api.Models
{
    public partial class SpeakersIncContext : DbContext
    {
        public virtual DbSet<AgendaCategory> AgendaCategory { get; set; }
        public virtual DbSet<AgendaRelatedField> AgendaRelatedField { get; set; }
        public virtual DbSet<AgendaRelatedIndustry> AgendaRelatedIndustry { get; set; }
        public virtual DbSet<AgendaRelatedSkill> AgendaRelatedSkill { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventAgenda> EventAgenda { get; set; }
        public virtual DbSet<EventCategory> EventCategory { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<EventVenue> EventVenue { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<IndustryField> IndustryField { get; set; }
        public virtual DbSet<OccupationLevel> OccupationLevel { get; set; }
        public virtual DbSet<RecordStatus> RecordStatus { get; set; }
        public virtual DbSet<SecretQuestion> SecretQuestion { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SpeakerProfile> SpeakerProfile { get; set; }
        public virtual DbSet<SpeakerRelatedField> SpeakerRelatedField { get; set; }
        public virtual DbSet<SpeakerRelatedIndustry> SpeakerRelatedIndustry { get; set; }
        public virtual DbSet<SpeakerRelatedSkill> SpeakerRelatedSkill { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<UserDetail> UserDetail { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=cxresearch.database.windows.net;Database=Speakers_DB;User Id=cxdbadmin; Password=7102CxResearch");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_AgendaCategory");

                entity.ToTable("AgendaCategory", "EventManagement");

                entity.Property(e => e.CategoryId).HasColumnType("varchar(45)");

                entity.Property(e => e.CategoryTitle)
                    .IsRequired()
                    .HasColumnType("varchar(150)");
            });

            modelBuilder.Entity<AgendaRelatedField>(entity =>
            {
                entity.HasKey(e => e.RelatedFieldId)
                    .HasName("PK_AgendaRelatedField");

                entity.ToTable("AgendaRelatedField", "EventManagement");

                entity.Property(e => e.RelatedFieldId).HasColumnType("varchar(45)");

                entity.Property(e => e.AgendaId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.FieldId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Agenda)
                    .WithMany(p => p.AgendaRelatedField)
                    .HasForeignKey(d => d.AgendaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AgendaRelatedField_EventAgenda");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.AgendaRelatedField)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AgendaRelatedField_IndustryField");
            });

            modelBuilder.Entity<AgendaRelatedIndustry>(entity =>
            {
                entity.HasKey(e => e.RelatedIndustryId)
                    .HasName("PK_AgendaRelatedIndustry");

                entity.ToTable("AgendaRelatedIndustry", "EventManagement");

                entity.Property(e => e.RelatedIndustryId).HasColumnType("varchar(45)");

                entity.Property(e => e.AgendaId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.IndustryId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Agenda)
                    .WithMany(p => p.AgendaRelatedIndustry)
                    .HasForeignKey(d => d.AgendaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AgendaRelatedIndustry_EventAgenda");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.AgendaRelatedIndustry)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AgendaRelatedIndustry_Industry");
            });

            modelBuilder.Entity<AgendaRelatedSkill>(entity =>
            {
                entity.HasKey(e => e.RelatedSkillId)
                    .HasName("PK_AgendaRelatedSkill");

                entity.ToTable("AgendaRelatedSkill", "EventManagement");

                entity.Property(e => e.RelatedSkillId).HasColumnType("varchar(45)");

                entity.Property(e => e.AgendaId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SkillId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Agenda)
                    .WithMany(p => p.AgendaRelatedSkill)
                    .HasForeignKey(d => d.AgendaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AgendaRelatedSkill_EventAgenda");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.AgendaRelatedSkill)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AgendaRelatedSkill_Skill");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City", "GeneralConfiguration");

                entity.Property(e => e.CityId).HasColumnType("varchar(45)");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnType("varchar(350)");

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "GeneralConfiguration");

                entity.Property(e => e.CountryId).HasColumnType("varchar(45)");

                entity.Property(e => e.CountryTitle)
                    .IsRequired()
                    .HasColumnType("varchar(300)");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event", "EventManagement");

                entity.Property(e => e.EventId).HasColumnType("varchar(45)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.EventCategoryId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.EventEndDate).HasColumnType("date");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.EventStartDate).HasColumnType("date");

                entity.Property(e => e.EventTypeId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.EventVenueId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.IsOneDayEvent).HasDefaultValueSql("0");

                entity.Property(e => e.OrganizerUserId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.RecordStatusId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.EventCategory)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Event_EventCategory");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Event_EventType");

                entity.HasOne(d => d.RecordStatus)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.RecordStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Event_RecordStatus");
            });

            modelBuilder.Entity<EventAgenda>(entity =>
            {
                entity.HasKey(e => e.AgendaId)
                    .HasName("PK_EventAgenda");

                entity.ToTable("EventAgenda", "EventManagement");

                entity.Property(e => e.AgendaId).HasColumnType("varchar(45)");

                entity.Property(e => e.AgendaDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.AgendaTitle)
                    .IsRequired()
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.EventId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.RecordStatusId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SpeakerId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TimeSlotEndTime).HasColumnType("datetime");

                entity.Property(e => e.TimeSlotStartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.EventAgenda)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EventAgenda_AgendaCategory");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventAgenda)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EventAgenda_Event");

                entity.HasOne(d => d.RecordStatus)
                    .WithMany(p => p.EventAgenda)
                    .HasForeignKey(d => d.RecordStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EventAgenda_RecordStatus");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.EventAgenda)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EventAgenda_SpeakerProfile");
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_EventCategory");

                entity.ToTable("EventCategory", "EventManagement");

                entity.Property(e => e.CategoryId).HasColumnType("varchar(45)");

                entity.Property(e => e.CategoryTitle)
                    .IsRequired()
                    .HasColumnType("varchar(350)");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK_EventType");

                entity.ToTable("EventType", "EventManagement");

                entity.Property(e => e.TypeId).HasColumnType("varchar(45)");

                entity.Property(e => e.TypeTitle)
                    .IsRequired()
                    .HasColumnType("varchar(350)");
            });

            modelBuilder.Entity<EventVenue>(entity =>
            {
                entity.HasKey(e => e.VenueId)
                    .HasName("PK_EventVenue");

                entity.ToTable("EventVenue", "EventManagement");

                entity.Property(e => e.VenueId).HasColumnType("varchar(45)");

                entity.Property(e => e.BuildingName).HasColumnType("varchar(350)");

                entity.Property(e => e.BuildingNo)
                    .IsRequired()
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.EventId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Latitude).HasColumnType("decimal");

                entity.Property(e => e.Longitude).HasColumnType("decimal");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.RecordStatusId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnType("varchar(350)");

                entity.Property(e => e.UnitNo).HasColumnType("varchar(10)");

                entity.Property(e => e.VenueTitle)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventVenue)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EventVenue_Event");

                entity.HasOne(d => d.RecordStatus)
                    .WithMany(p => p.EventVenue)
                    .HasForeignKey(d => d.RecordStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_EventVenue_RecordStatus");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("Industry", "GeneralConfiguration");

                entity.Property(e => e.IndustryId).HasColumnType("varchar(45)");

                entity.Property(e => e.IndustryTitle)
                    .IsRequired()
                    .HasColumnType("varchar(350)");
            });

            modelBuilder.Entity<IndustryField>(entity =>
            {
                entity.HasKey(e => e.FieldId)
                    .HasName("PK_IndustryField");

                entity.ToTable("IndustryField", "GeneralConfiguration");

                entity.Property(e => e.FieldId).HasColumnType("varchar(45)");

                entity.Property(e => e.FieldTitle)
                    .IsRequired()
                    .HasColumnType("varchar(350)");

                entity.Property(e => e.IndustryId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.IndustryField)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_IndustryField_Industry");
            });

            modelBuilder.Entity<OccupationLevel>(entity =>
            {
                entity.ToTable("OccupationLevel", "UserManagement");

                entity.Property(e => e.OccupationLevelId).HasColumnType("varchar(45)");

                entity.Property(e => e.LevelTitle)
                    .IsRequired()
                    .HasColumnType("varchar(150)");
            });

            modelBuilder.Entity<RecordStatus>(entity =>
            {
                entity.ToTable("RecordStatus", "GeneralConfiguration");

                entity.Property(e => e.RecordStatusId).HasColumnType("varchar(45)");

                entity.Property(e => e.StatusDescription).HasColumnType("varchar(500)");

                entity.Property(e => e.StatusText)
                    .IsRequired()
                    .HasColumnType("varchar(25)");
            });

            modelBuilder.Entity<SecretQuestion>(entity =>
            {
                entity.ToTable("SecretQuestion", "UserManagement");

                entity.Property(e => e.SecretQuestionId).HasColumnType("varchar(45)");

                entity.Property(e => e.SecretQuestionText)
                    .IsRequired()
                    .HasColumnType("varchar(500)");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill", "GeneralConfiguration");

                entity.Property(e => e.SkillId).HasColumnType("varchar(45)");

                entity.Property(e => e.SkillTitle)
                    .IsRequired()
                    .HasColumnType("varchar(250)");
            });

            modelBuilder.Entity<SpeakerProfile>(entity =>
            {
                entity.HasKey(e => e.SpeakerId)
                    .HasName("PK_SpeakerProfile");

                entity.ToTable("SpeakerProfile", "SpeakerManagement");

                entity.Property(e => e.SpeakerId).HasColumnType("varchar(45)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.RecordStatusId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SpeakerRating).HasDefaultValueSql("0.00");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.RecordStatus)
                    .WithMany(p => p.SpeakerProfile)
                    .HasForeignKey(d => d.RecordStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpeakerProfile_RecordStatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SpeakerProfile)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpeakerProfile_UserAccount");
            });

            modelBuilder.Entity<SpeakerRelatedField>(entity =>
            {
                entity.HasKey(e => e.RelatedFieldId)
                    .HasName("PK_SpeakerRelatedField");

                entity.ToTable("SpeakerRelatedField", "SpeakerManagement");

                entity.Property(e => e.RelatedFieldId).HasColumnType("varchar(45)");

                entity.Property(e => e.FieldId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SpeakerId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.SpeakerRelatedField)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpeakerRelatedField_IndustryField");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.SpeakerRelatedField)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpeakerRelatedField_SpeakerProfile");
            });

            modelBuilder.Entity<SpeakerRelatedIndustry>(entity =>
            {
                entity.HasKey(e => e.RelatedIndustryId)
                    .HasName("PK_SpeakerRelatedIndustry");

                entity.ToTable("SpeakerRelatedIndustry", "SpeakerManagement");

                entity.Property(e => e.RelatedIndustryId).HasColumnType("varchar(45)");

                entity.Property(e => e.IndustryId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SpeakerId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.SpeakerRelatedIndustry)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpeakerRelatedIndustry_Industry");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.SpeakerRelatedIndustry)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpeakerRelatedIndustry_SpeakerProfile");
            });

            modelBuilder.Entity<SpeakerRelatedSkill>(entity =>
            {
                entity.HasKey(e => e.RelatedSkillId)
                    .HasName("PK_SpeakerRelatedSkill");

                entity.ToTable("SpeakerRelatedSkill", "SpeakerManagement");

                entity.Property(e => e.RelatedSkillId).HasColumnType("varchar(45)");

                entity.Property(e => e.SkillId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SpeakerId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.SpeakerRelatedSkill)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpeakerRelatedSkill_Skill");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.SpeakerRelatedSkill)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SpeakerRelatedSkill_SpeakerProfile");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserAccount");

                entity.ToTable("UserAccount", "UserManagement");

                entity.Property(e => e.UserId).HasColumnType("varchar(45)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.IsActivated).HasDefaultValueSql("0");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.RecordStatusId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SecretAnswer1)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SecretAnswer2).HasColumnType("varchar(255)");

                entity.Property(e => e.SecretAnswer3).HasColumnType("varchar(255)");

                entity.Property(e => e.SecretQuestion1Id)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SecretQuestion2Id).HasColumnType("varchar(45)");

                entity.Property(e => e.SecretQuestion3Id).HasColumnType("varchar(45)");

                entity.Property(e => e.UserTypeId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.RecordStatus)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.RecordStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserAccount_RecordStatus");

                entity.HasOne(d => d.SecretQuestion1)
                    .WithMany(p => p.UserAccountSecretQuestion1)
                    .HasForeignKey(d => d.SecretQuestion1Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserAccount_SecretQuestion");

                entity.HasOne(d => d.SecretQuestion2)
                    .WithMany(p => p.UserAccountSecretQuestion2)
                    .HasForeignKey(d => d.SecretQuestion2Id)
                    .HasConstraintName("FK_UserAccount_SecretQuestion2");

                entity.HasOne(d => d.SecretQuestion3)
                    .WithMany(p => p.UserAccountSecretQuestion3)
                    .HasForeignKey(d => d.SecretQuestion3Id)
                    .HasConstraintName("FK_UserAccount_SecretQuestion3");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserAccount_UserType");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId)
                    .HasName("PK_UserDetail");

                entity.ToTable("UserDetail", "UserManagement");

                entity.Property(e => e.DetailId).HasColumnType("varchar(45)");

                entity.Property(e => e.AboutMeDescription).HasColumnType("varchar(2000)");

                entity.Property(e => e.CityId).HasColumnType("varchar(45)");

                entity.Property(e => e.CompanyName).HasColumnType("varchar(350)");

                entity.Property(e => e.CountryId).HasColumnType("varchar(45)");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EducationInstitutionName).HasColumnType("varchar(350)");

                entity.Property(e => e.Occupation).HasColumnType("varchar(350)");

                entity.Property(e => e.OccupationLevelId).HasColumnType("varchar(45)");

                entity.Property(e => e.RecordStatusId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.UserDetail)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_UserDetail_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.UserDetail)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_UserDetail_Country");

                entity.HasOne(d => d.OccupationLevel)
                    .WithMany(p => p.UserDetail)
                    .HasForeignKey(d => d.OccupationLevelId)
                    .HasConstraintName("FK_UserDetail_OccupationLevel");

                entity.HasOne(d => d.RecordStatus)
                    .WithMany(p => p.UserDetail)
                    .HasForeignKey(d => d.RecordStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserDetail_RecordStatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDetail)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserDetail_UserAccount");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK_UserType");

                entity.ToTable("UserType", "UserManagement");

                entity.Property(e => e.TypeId).HasColumnType("varchar(45)");

                entity.Property(e => e.TypeDescription).HasColumnType("varchar(500)");

                entity.Property(e => e.TypeText)
                    .IsRequired()
                    .HasColumnType("varchar(25)");
            });
        }
    }
}